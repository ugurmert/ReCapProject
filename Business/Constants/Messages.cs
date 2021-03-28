using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Hata! Renk adı en az 2 karakter olmalı";
        public static string ColorNameAvailable = "Hata! Renk adı mevcut";
        public static string ColorIdAvailable = "Hata! Renk id'si mevcut";
        public static string ColorNotFound = "Hata! Renk mevcut değil";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Hata! Marka adı en az 2 karakter olmalı";
        public static string BrandNameAvailable = "Hata! Marka adı mevcut";
        public static string BrandIdAvailable = "Hata! Marka id'si mevcut";
        public static string BrandNotFound = "Hata! Marka mevcut değil";

        public static string ModelAdded = "Model eklendi";
        public static string ModelDeleted = "Model silindi";
        public static string ModelUpdated = "Model güncellendi";
        public static string ModelNameInvalid = "Hata! Model adı en az 2 karakter olmalı";
        public static string ModelNameAvailable = "Hata! Model adı mevcut";
        public static string ModelIdAvailable = "Hata! Model id'si mevcut";
        public static string ModelNotFound = "Hata! Model mevcut değil";

        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDailyPriceInvalid = "Hata! Araba günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarIdAvailable = "Hata! Araba id'si mevcut";
        public static string CarNotFound = "Hata! Araba mevcut değil";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserAvailable = "Hata! Kullanıcı mevcut";
        public static string UserNotFound = "Hata! Kullanıcı mevcut değil";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerAvailable = "Hata! Müşteri mevcut";
        public static string CustomerNotFound = "Hata! Müşteri mevcut değil";

        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string RentalAvailable = "Hata! Kiralama işlemi mevcut";
        public static string RentalNotFound = "Hata! Kiralama işlemi mevcut değil";
        public static string RentalCarBusy = "Hata! Arabanın kiralama süresi devam ediyor";
    }
}
