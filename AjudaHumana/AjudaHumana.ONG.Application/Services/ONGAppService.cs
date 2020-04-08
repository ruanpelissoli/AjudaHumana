using AjudaHumana.Core.Domain;
using AjudaHumana.Core.Utils;
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

        public ONGAppService(IONGRepository ongRepository,
                             IUser user,
                             IMapper mapper)
        {
            _ongRepository = ongRepository;
            _user = user;
            _mapper = mapper;
        }

        public async Task Create(ONGViewModel ongViewModel)
        {
            var ong = _mapper.Map<NonGovernamentalOrganization>(ongViewModel);
            ong.CNPJ = ongViewModel.CNPJ.RemoveSpecialCharacters();

            var responsible = ong.Responsible;
            _ongRepository.CreateResponsible(responsible);

            var address = ong.Address;
            _ongRepository.CreateAddress(address);

            ong.SetResponsible(responsible);
            ong.SetAddress(address);

            _ongRepository.Create(ong);

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task Update(ONGViewModel ongViewModel)
        {
            var ong = await _ongRepository.GetById(ongViewModel.Id);

            if (ongViewModel.Approved == "Sim")
                ong.Approve();
            else
                ong.Disapprove();

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

        public async Task<RequestViewModel> GetRequest(Guid requestId)
        {
            return _mapper.Map<RequestViewModel>(await _ongRepository.GetRequest(requestId));
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

        public void Dispose()
        {
            _ongRepository?.Dispose();
        }
    }
}
