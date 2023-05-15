namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XMLhelper helper = new XMLhelper();

            ImportCreatorDto[] creatorDtos = helper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");
            List<Creator> validCreators = new List<Creator>();

            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                List<Boardgame> validBoardgames = new List<Boardgame>();
                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (string.IsNullOrEmpty(boardgameDto.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    };
                    validBoardgames.Add(boardgame);
                }
                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = validBoardgames
                };
                validCreators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }
            context.Creators.AddRange(validCreators);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            IMportSellerDto[] sellerDtos = JsonConvert.DeserializeObject<IMportSellerDto[]>(jsonString);
            List<Seller> validSellers = new List<Seller>();

            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(sellerDto.Country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(sellerDto.Address))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(sellerDto.Website))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                List<BoardgameSeller> boardgamesSellers = new List<BoardgameSeller>();
                foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(b=>b.Id == boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boardgameId
                    };
                    boardgamesSellers.Add(boardgameSeller);
                }
                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                    BoardgamesSellers = boardgamesSellers
                };
                validSellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }
            context.Sellers.AddRange(validSellers);
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
