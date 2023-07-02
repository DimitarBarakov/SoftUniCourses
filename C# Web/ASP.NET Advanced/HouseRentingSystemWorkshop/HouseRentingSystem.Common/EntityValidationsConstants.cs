namespace HouseRentingSystem.Common
{
    public static class EntityValidationsConstants
    {
        public static class Category
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 2;
        }
        public static class House
        {
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            public const int AddressMaxLength = 150;
            public const int AddressMinLength = 30;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 50;

            public const double PriceMax = 2000;
            public const double PriceMin = 0;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Agent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
