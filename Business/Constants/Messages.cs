using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarAlreadyExists = "The car with this name already exists";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageMaxAdded = "Hata! Bir araba için en fazla 5 resim yüklenebilir";
        public static string CarDailyPriceInvalid = "Hata! Araba günlük fiyatı 0'dan büyük olmalıdır";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string ModelAdded = "Model eklendi";
        public static string ModelDeleted = "Model silindi";
        public static string ModelUpdated = "Model güncellendi";

        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string AuthorizationDenied = "Token oluşturuldu";

        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "You entered the password incorrectly";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exist";
        public static string AccessTokenCreated = "Created Token";
        public static string Updated = "Update completed successfully";
    }
}
