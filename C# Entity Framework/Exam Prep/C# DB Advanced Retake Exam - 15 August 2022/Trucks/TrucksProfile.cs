namespace Trucks
{
    using AutoMapper;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ExportDto;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            this.CreateMap<Despatcher, ExportDespatcherDto>()
                .ForMember(d => d.Trucks,
                    opt => opt.MapFrom(s =>
                        s.Trucks
                            .Select(pc => pc)
                            //.OrderByDescending(p => p.Price)
                            .ToArray()));
        }
    }
}
