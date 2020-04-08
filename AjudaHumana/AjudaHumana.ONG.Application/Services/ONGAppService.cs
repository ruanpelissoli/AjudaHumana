using AjudaHumana.Core.Utils;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.Contracts;
using AjudaHumana.ONG.Domain.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Services
{
    public class ONGAppService : IONGAppService
    {
        private readonly IONGRepository _ongRepository;
        private readonly IMapper _mapper;

        public ONGAppService(IONGRepository ongRepository,
                             IMapper mapper)
        {
            _ongRepository = ongRepository;
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

            if (ongViewModel.Approved)
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

        public void Dispose()
        {
            _ongRepository?.Dispose();
        }
    }
}
