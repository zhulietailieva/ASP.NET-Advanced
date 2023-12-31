﻿namespace TrailVenturesSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Trip
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 8000;

            public const string PricePerPersonMinValue = "0";
            public const string PricePerPersonMaxValue = "100";

            public const int GroupMinSizePeople = 2;
            public const int GroupsMaxSizePeople = 50;
        }

        public static class Guide
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

            public const int YearsOfExperienceMinValue = 1;
            public const int YearsOfExperienceMaxValue = 80;
        }

        public static class Mountain
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 20;

            public const int PersonalInfoMaxLength = 1500;
        }

        public static class Hut
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

            public const string pricePerPersonMinValue = "1";
            public const string pricePerPersonMaxValue = "200";

            public const int altitudeMinValue = 100;
            public const int altitudeMaxValue = 4000;
        }
    }
}
