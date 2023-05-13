namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XMLhelper helper = new XMLhelper();

            ImportDespatcherDto[] importDespatcherDtos = helper.Deserialize<ImportDespatcherDto[]>("Despatchers", xmlString);

            List<Despatcher> validDespatchers = new List<Despatcher>();
            foreach (var despatcherDto in importDespatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                List<Truck> validTrucks = new List<Truck>();
                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };
                    validTrucks.Add(truck);
                }
                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };
                validDespatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher,despatcher.Name,validTrucks.Count));
            }
            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            List<Client> validClients = new List<Client>();
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,

                };
                List<ClientTruck> validTrucks = new List<ClientTruck>();
                foreach (var truckId in clientDto.TruckIds.Distinct())
                {
                    if (!context.Trucks.Any(t=>t.Id == truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    ClientTruck ct = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId
                    };
                    validTrucks.Add(ct);
                }
                client.ClientsTrucks = validTrucks;
                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, validTrucks.Count));
            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();
            
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}