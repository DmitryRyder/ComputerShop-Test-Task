using LapTopShop.Models.DataModels;
using MediatR;

namespace LapTopShop.Service.Commands
{
    public class CreateLaptopCommand : IRequest<Laptop>
    {
        public Laptop Laptop { get; set; }
    }
}
