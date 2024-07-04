namespace SimpleETicketPlatform.Infrastructure.Data.Constants
{
    public static class ModelConstants
    {
        public static class Actor
        {
            public const int FullNameMaxLength = 100;
            public const int FullNameMinLength = 0;
            public const int BiographyMaxLength = 800;
            public const int BiographyMinLength = 0;
            public const int ProfilePictureURLMaxLength = 255;
            public const int ProfilePictureURLMinLength = 0;
        }
        public static class Cinema
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 0;
            public const int LogoMaxLength = 255;
            public const int LogoMinLength = 0;
            public const int DescriptionMaxLength = 800;
            public const int DescriptionMinLength = 0;
        }
        public static class Movie
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 0;
            public const int PhotoURLMaxLength = 255;
            public const int PhotoURLMinLength = 0;
            public const int DescriptionMaxLength = 800;
            public const int DescriptionMinLength = 0;
            public const string PriceMinValue = "0.0";
            public const string PriceMaxValue = "100.0";
        }
        public static class Producer
        {
            public const int FullNameMaxLength = 100;
            public const int FullNameMinLength = 0;
            public const int BiographyMaxLength = 800;
            public const int BiographyMinLength = 0;
            public const int ProfilePictureURLMaxLength = 255;
            public const int ProfilePictureURLMinLength = 0;
        }
    }
}
