using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProducListed = "Ürünler Listelendi";
        public static string ProductCountOfcategoryError = "Bir Kategori de En Fazla 10 Ürün Olabilir";
        public static string ProductNameAlreadyExist = "Aynı İsimde Ürün Eklenemez";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldığı için Yeni Ürün Eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz Yok";
        public static string UserRegistered="Kayıt Olundu";
        public static string UserNotFound= "Kullanıcı Bulunamadı";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı zaten Ekli";
        public static string AccessTokenCreated="Token Oluşturuldu";
        public static string CategoryListed="Kategori Listelendi";
    }
}
