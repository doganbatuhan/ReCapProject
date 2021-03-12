using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDeleted = "Araba silindi";
        public static string CarIdInvalid = "Listede o id'de araba yok";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarCountOfBrandError = "Bir markadan en fazla 10 araba olabilir";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string ImageCountOfCarError = "Bir arabanın en fazla 5 resmi olabilir";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccesfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated="Access Token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string CustomersListed = "Müşteriler Listelendi";
    }
}
