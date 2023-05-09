using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Castle.Core.Resource;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext carDealerContext = new CarDealerContext();
            string inputXML = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(GetCarsFromMakeBmw(carDealerContext));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XMLHelper helper = new XMLHelper();
            ImportSuppliersDto[] suppliersDtos = helper.Deserialize<ImportSuppliersDto[]>("Suppliers", inputXml);
            List<Supplier> validSuppliers = new List<Supplier>();
            foreach (var supplierDto in suppliersDtos)
            {
                if (String.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }
                Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter,
                };
               validSuppliers.Add(supplier);
            }
            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XMLHelper xmlHelper = new XMLHelper();
            ImportPartsDto[] importPartsDtos = xmlHelper.Deserialize<ImportPartsDto[]>("Parts", inputXml);
            List<Part> validParts = new List<Part>();
            foreach (var partDto in importPartsDtos)
            {
                if (String.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }
                Part part = new Part()
                {
                    Name = partDto.Name,
                    Quantity = partDto.Quantity,
                    Price = partDto.Price,
                    SupplierId = partDto.SupplierId
                };
                validParts.Add(part);
            }
            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XMLHelper xmlHelper = new XMLHelper();
            ImportCarsDto[] importCarsDtos = xmlHelper.Deserialize<ImportCarsDto[]>("Cars", inputXml);
            List<Car> validCars = new List<Car>();
            foreach (var carDto in importCarsDtos)
            {
                List<PartCar> validParts = new List<PartCar>();
                foreach(var partCarDto in carDto.Parts.DistinctBy(p=>p.PartId))
                {
                    if (!context.Parts.Any(p=>p.Id == partCarDto.PartId))
                    {
                        continue;
                    }
                    PartCar partCar = new PartCar()
                    {
                        PartId = partCarDto.PartId
                    };
                    validParts.Add(partCar);
                }

                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                    PartsCars = validParts
                };
                validCars.Add(car);
            }
            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";

        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XMLHelper xmlHelper = new XMLHelper();
            ImportCustomersDto[] customersDtos = xmlHelper.Deserialize<ImportCustomersDto[]>("Customers",inputXml);
            List<Customer> validCustomers = new List<Customer>();
            foreach (var customerDto in customersDtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };
                validCustomers.Add(customer);
            }
            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XMLHelper xmlHelper = new XMLHelper();
            ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>("Sales", inputXml);
            List<Sale> validSales = new List<Sale>();

            foreach (var saleDto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }
                Sale sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };
                validSales.Add(sale);
            }
            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XMLHelper helper = new XMLHelper();

            ExportCarDto[] carsWithAlotOfDistance = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarDto[]>("cars", carsWithAlotOfDistance);
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XMLHelper helper = new XMLHelper();

            ExportBMWCarsDto[] BMWCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c=>c.TraveledDistance)
                .Take(10)
                .ProjectTo<ExportBMWCarsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportBMWCarsDto[]>("cars", BMWCars);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XMLHelper helper = new XMLHelper();


        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}