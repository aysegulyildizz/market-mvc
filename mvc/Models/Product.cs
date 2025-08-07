using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required( ErrorMessage = " İsim alanı boş olamaz .")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = " Fiyatı alanını doldurun . ")]
        [Range(0.01,Double.MaxValue, ErrorMessage = " Fiyat sıfırdan büyük olmalıdır . ")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = " Stock alanını doldurun . ")]
        [Range (0,int.MaxValue,ErrorMessage = " Stock sıfırdan büyük olmalı . ")]
        public int Stock { get; set; }
        
        [Required(ErrorMessage = "Lütfen bir kategori seçin.")]

        public int KategoriId { get; set; } 


    }
    
}

