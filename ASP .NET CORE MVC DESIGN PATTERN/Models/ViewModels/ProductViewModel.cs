using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EFCORE_VERİALMA.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Remote(action: "HasProdyctName","controller:Products")] //AJAX TABANLI OLARAK BACKEND İLE HABERLEŞİYOR
        [Required(ErrorMessage ="İSİM ALANI BOŞ OLAMAZ")]
        [StringLength(50,ErrorMessage ="EN FALZA 50 OLABİLİR")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "FİYAT ALANI BOŞ OLAMAZ")]
        [Range(1,1000, ErrorMessage = "fiyat ALANI 1 ile 200 arasında olmalı")]
        public int Price { get; set; }
        [Required(ErrorMessage = "STOK ALANI BOŞ OLAMAZ")]
        [Range(1,200,ErrorMessage = "STOK ALANI 1 ile 200 arasında olmalı")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "AÇIKLAMA ALANI BOŞ OLAMAZ")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "EN FALZA 50 OLABİLİR")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "RENK ALANI BOŞ OLAMAZ")]
        public string? Colour { get; set; }
        [Required(ErrorMessage = "YAYNINLANMA TARİHİ ALANI BOŞ OLAMAZ")]
        public DateTime? PublishDate { get; set; }

        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "YAYNINLANMA SÜRESİ ALANI BOŞ OLAMAZ")]
        public int Expire { get; set; }

    }
}
