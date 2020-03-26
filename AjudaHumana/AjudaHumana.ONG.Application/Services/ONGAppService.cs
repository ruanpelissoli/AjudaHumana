using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Domain.Contracts;
using System.Threading.Tasks;

namespace AjudaHumana.ONG.Application.Services
{
    public class ONGAppService : IONGAppService
    {
        private readonly IONGRepository _ongRepository;

        public ONGAppService(IONGRepository ongRepository)
        {
            _ongRepository = ongRepository;
        }

        public async Task Create(NonGovernamentalOrganization ong)
        {
            //var produto = _mapper.Map<Produto>(produtoViewModel);
            _ongRepository.Create(ong);

            await _ongRepository.UnitOfWork.Commit();
        }

        public async Task Update(NonGovernamentalOrganization ong)
        {
            //var produto = _mapper.Map<Produto>(produtoViewModel);
            _ongRepository.Update(ong);

            await _ongRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _ongRepository?.Dispose();
        }
    }
}
