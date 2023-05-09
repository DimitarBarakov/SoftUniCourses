using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportBMWCarsDto>();
        }
    }
}
