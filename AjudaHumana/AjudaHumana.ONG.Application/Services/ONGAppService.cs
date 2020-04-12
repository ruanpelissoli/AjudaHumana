using AjudaHumana.Core.Domain;
using AjudaHumana.Core.Utils;
using AjudaHumana.Core.ViewModels;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.Contracts;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Services
{
    public class ONGAppService : IONGAppService
    {
        private readonly IONGRepository _ongRepository;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        public readonly IGoogleMapsService _googleMapsService;

        public ONGAppService(IONGRepository ongRepository,
                             IUser user,
                             IMapper mapper,
                             IGoogleMapsService googleMapsService)
        {
            _ongRepository = ongRepository;
            _user = user;
            _mapper = mapper;
            _googleMapsService = googleMapsService;
        }

        public async Task Create(ONGViewModel ongViewModel)
        {
            var ong = _mapper.Map<NonGovernamentalOrganization>(ongViewModel);
            ong.CNPJ = ongViewModel.CNPJ.RemoveSpecialCharacters();

            var responsible = ong.Responsible;
            _ongRepository.CreateResponsible(responsible);

            var address = ong.Address;
            var latlong = _googleMapsService.GetLocation(AddressToViewModel(address));
            address.Latitude = latlong.Latitude;
            address.Longitude = latlong.Longitude;

            _ongRepository.CreateAddress(address);

            ong.SetResponsible(responsible);
            ong.SetAddress(address);

            _ongRepository.Create(ong);

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task Update(ONGViewModel ongViewModel)
        {
            Guid ongId;

            if (ongViewModel.Id == Guid.Empty)
                ongId = GetCurrentLoggedONG().Result.Id;
            else
                ongId = ongViewModel.Id;

            var ong = await _ongRepository.GetById(ongId);

            if (!ong.Approved.HasValue)
            {
                if (ongViewModel.Approved == "Sim")
                    ong.Approve();
                else
                    ong.Disapprove();
            }
            else
            {
                var address = ong.Address;

                address.State = ongViewModel.AddressState;
                address.City = ongViewModel.AddressCity;
                address.ZipCode = ongViewModel.AddressZipCode;
                address.Street = ongViewModel.AddressStreet;
                address.Number = ongViewModel.AddressNumber;
                address.Neighborhood = ongViewModel.AddressNeighborhood;
                address.Complement = ongViewModel.AddressComplement;

                var latlong = _googleMapsService.GetLocation(AddressToViewModel(address));
                address.Latitude = latlong.Latitude;
                address.Longitude = latlong.Longitude;

                var responsible = ong.Responsible;
                responsible.PhoneNumber = ongViewModel.ResponsiblePhoneNumber;
            }

            _ongRepository.Update(ong);

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task<ONGViewModel> Find(Guid id)
        {
            return _mapper.Map<ONGViewModel>(await _ongRepository.GetById(id));
        }

        public async Task<IEnumerable<ONGViewModel>> GetAll(Expression<Func<NonGovernamentalOrganization, bool>> filter = null)
        {
            return _mapper.Map<IEnumerable<ONGViewModel>>(await _ongRepository.GetAll(filter));
        }

        public async Task<ONGViewModel> GetCurrentLoggedONG()
        {
            var query = await GetAll(w => w.ApplicationUserId == _user.Id);

            return _mapper.Map<ONGViewModel>(query.FirstOrDefault());
        }

        public async Task UpdateUserId(ONGViewModel ongViewModel, Guid userId)
        {
            var ong = await _ongRepository.GetById(ongViewModel.Id);
            ong.SetUserId(userId);

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<RequestViewModel>> GetRequests()
        {
            return _mapper.Map<IEnumerable<RequestViewModel>>(await _ongRepository.GetRequests());
        }

        public async Task<IEnumerable<RequestViewModel>> GetNearestRequests()
        {
            var requests = await _ongRepository.GetNearestRequests();

            var requestsViewModels = requests.Select(r => new RequestViewModel
            {
                Id = r.Id,
                ONGId = r.ONGId,
                ONGName = r.ONG.Name,
                Goals = _mapper.Map<List<GoalViewModel>>(r.Goals),
                CreatedAt = r.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                Description = r.Description,
                Finished = r.Finished ? "Sim" : "Não",
                Latitude = r.ONG.Address.Latitude,
                Longitude = r.ONG.Address.Longitude,
                Address = new AddressViewModel
                {
                    City = r.ONG.Address.City,
                    Number = r.ONG.Address.Number,
                    State = r.ONG.Address.State,
                    Street = r.ONG.Address.Street,
                    ZipCode = r.ONG.Address.ZipCode,
                    Complement = r.ONG.Address.Complement,
                    Neighbourhood = r.ONG.Address.Neighborhood
                }
            });

            return requestsViewModels;
        }

        public async Task<RequestViewModel> GetRequest(Guid requestId)
        {
           var request = await _ongRepository.GetRequest(requestId);

            var requestsViewModels = new RequestViewModel {
                Id = request.Id,
                ONGId = request.ONGId,
                ONGName = request.ONG.Name,
                Goals = _mapper.Map<List<GoalViewModel>>(request.Goals),
                CreatedAt = request.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                Description = request.Description,
                Finished = request.Finished ? "Sim" : "Não",
                Latitude = request.ONG.Address.Latitude,
                Longitude = request.ONG.Address.Longitude,
                Address = new AddressViewModel
                {
                    City = request.ONG.Address.City,
                    Number = request.ONG.Address.Number,
                    State = request.ONG.Address.State,
                    Street = request.ONG.Address.Street,
                    ZipCode = request.ONG.Address.ZipCode,
                    Complement = request.ONG.Address.Complement,
                    Neighbourhood = request.ONG.Address.Neighborhood
                }
            };

            return requestsViewModels;
        }

        public async Task CreateRequest(RequestViewModel requestViewModel)
        {
            var request = new Request(requestViewModel.Description, await GetLoggedUserONGId());

            _ongRepository.CreateRequest(request);

            foreach (var goal in requestViewModel.Goals)
            {
                request.AddGoal(new Goal(goal.ItemName, 0, goal.FinishedGoal, request.Id));
            }

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task UpdateRequest(RequestViewModel requestViewModel)
        {
            var request = await _ongRepository.GetRequest(requestViewModel.Id);

            foreach (var goal in request.Goals)
                goal.UpdateCurrentGoal(requestViewModel.Goals.FirstOrDefault(w => w.GoalId == goal.Id).CurrentGoal);

            request.IsFinished();
            _ongRepository.UpdateRequest(request);

            await _ongRepository.UnitOfWork.Commit();
        }

        private async Task<Guid> GetLoggedUserONGId()
        {
            var ongs = await _ongRepository.GetAll(w => w.ApplicationUserId == _user.Id);
            return ongs.FirstOrDefault().Id;
        }

        private AddressViewModel AddressToViewModel(Address address)
        {
            return new AddressViewModel
            {
                Street = address.Street,
                Number = address.Number,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode
            };
        }

        public void Dispose()
        {
            _ongRepository?.Dispose();
        }
    }
}
