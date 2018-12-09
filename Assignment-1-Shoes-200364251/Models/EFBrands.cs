  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_1_Shoes_200364251.Models
{
    public class EFBrands : IBrandsMock
    {

        //db connection

        private ShoesModel db = new ShoesModel();

        public IQueryable<brand> Brands { get {return db.brands; } }

        

        public void Delete(brand brand)
        {
            db.brands.Remove(brand);
            db.SaveChanges();
        }
         
        public brand Save(brand brand)
        {
            if (brand.brandId == 0)
            {
                db.brands.Add(brand);
            
            }

            else
            {
                db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return brand;
        }
    }
}

  