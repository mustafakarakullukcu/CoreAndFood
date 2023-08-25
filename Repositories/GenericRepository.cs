using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        Context c = new Context();
        public List<T> TList() //Listeleme metodu.
        {
            return c.Set<T>().ToList();
        }
        public void TAdd(T p)// Ekleme metodu.
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void TRemove(T p)//Silme metodu.
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void TUpdate(T p)//Güncelleme metodu.
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public T TGet(int id)//bulma metodu.
        {
            return c.Set<T>().Find(id);
        }
        //INCLUDE İŞLEMİ
        public List<T> Tlist(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
