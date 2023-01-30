using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;
using MvcCvSon.Models.entity; 
namespace MvcCvSon.repositories
{
    public class GenericRepository<t> where t:class,new() /*t degeri sınıflar*/
    {
        dbcvEntities db=new dbcvEntities();

        public List<t> list()
        {
            return db.Set<t>().ToList();
        }
        public void tadd(t p)
        {
            db.Set<t>().Add(p);
            db.SaveChanges();
        }
        public void tdelete(t p)
        {
            db.Set<t>().Remove(p);
            db.SaveChanges();
        }
        public t tget(int id)
        {
            return db.Set<t>().Find(id);
        }
        public void tupdate(t p) 
        {
            db.SaveChanges();
        }
        public t find(Expression<Func<t,bool>> where) //silinecek olan değeri bulma
        {
            return db.Set<t>().FirstOrDefault(where); //ilk değeri döndür where göre 
        }
    }
}