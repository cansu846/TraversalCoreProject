using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            //Context: EF Core veri tabanı bağlantısını yöneten sınıftır.
            using (var c = new Context()) 
            {
                //Set<T>() → T türündeki varlık için veri tabanı tablosunu temsil eden bir nesne döndürür.
                return c.Set<T>().Find(id);
            }
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context()) 
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);   
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context(); 
            c.Update(t);
            c.SaveChanges();
        }
    }
}
