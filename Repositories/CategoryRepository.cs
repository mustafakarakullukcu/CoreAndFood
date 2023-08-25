using CoreAndFood.Data.Models;

namespace CoreAndFood.Repositories
{
    //CRUD İŞLEMLERİ
    public class CategoryRepository:GenericRepository<Category>
    {
        //Context c = new Context();
        //public List<Category> CategoryList() //Listeleme metodu.
        //{
        //    return c.Categories.ToList();
        //}
        //public void CategoryAdd(Category ct)// Ekleme metodu.
        //{
        //    c.Categories.Add(ct);
        //    c.SaveChanges();
        //}
        //public void CategoryRemove(Category ct)//Silme metodu.
        //{
        //    c.Categories.Remove(ct);
        //    c.SaveChanges() ;
        //}
        //public void CategoryUpdate(Category ct)//Güncelleme metodu.
        //{
        //    c.Categories.Update (ct);
        //    c.SaveChanges() ;
        //}
        //public void GetCategory(int id)//bulma metodu.
        //{
        //    c.Categories.Find (id);
        //}
    }
}
