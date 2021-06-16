using System.Threading;
using System.Threading.Tasks;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.Commands;
using MediatR;

namespace LapTopShop.Service.CommandHandlers
{
    public class CreateLaptopCommandHandler : IRequestHandler<CreateLaptopCommand, Laptop>
    {
        private readonly ILaptopRepository _laptopRepository;

        public CreateLaptopCommandHandler(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public async Task<Laptop> Handle(CreateLaptopCommand request, CancellationToken cancellationToken)
        {
            return await _laptopRepository.AddAsync(request.Laptop);
        }
    }
}
