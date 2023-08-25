using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Cant be null.")] //Boş kalınca engeller
        [StringLength(20, ErrorMessage = "Please use between 3-20 characthers.",MinimumLength =3)] //Miktarı sınırlar.
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        //İLİŞKİLENDİRME
        public List<Food> Foods { get; set;} //Bir category içinde birden fazla food yer almasını sağlar.
    }
}
