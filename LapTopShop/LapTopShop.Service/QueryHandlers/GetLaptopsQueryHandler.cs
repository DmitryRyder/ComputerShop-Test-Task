using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Queries;
using MediatR;

namespace LapTopShop.Service.QueryHandlers
{
    public class GetLaptopsQueryHandler : IRequestHandler<GetLaptopsQuery, List<Laptop>>
    {
        private readonly ILaptopRepository _laptopRepository;

        public GetLaptopsQueryHandler(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public async Task<List<Laptop>> Handle(GetLaptopsQuery request, CancellationToken cancellationToken)
        {
            return await _laptopRepository.GetListAsync();
        }
    }
}
