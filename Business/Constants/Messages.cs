using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //Constants klasörü sabit yapıların oldu yerlerdir.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün eklendi";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde başka bir ürün vardır";

        public static string CategoryLimitExceded = "Kategori limit aşıldığı için yeni ürün eklenemiyor";

        public static string AuthorizationDenied = "Yekiniz yok.";

        public static string UserRegistered = "";
        public static string UserNotFound = "";
        public static string PasswordError = "";
        public static string SuccessfulLogin = "";
        public static string UserAlreadyExists = "";
        public static string AccessTokenCreated = "";
    }
}
