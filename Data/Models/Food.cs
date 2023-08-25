namespace CoreAndFood.Data.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        //İLİŞKİ KURMA
        public int CategoryID { get; set; } //Bir foodun sadece bir kategorisi olucağını belirler.
        public virtual Category Category { get; set; }// ve üstteki olguyu kategori sınıfına belirttik.
    }
}
