using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursework_Models
{
    public class Product
    {
        public Product() { TempCount = 1; }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ShortDesc {  get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; } //Связь с таблицей категорий
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; } //Cвязь с таблицей производителей
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }
        [NotMapped]
        [Range(1,100, ErrorMessage ="Кол-во товара должно быть больше 0")] //Минимальное кол-во товаров 1, максимум 100
        public int TempCount { get; set; }
    }
}
