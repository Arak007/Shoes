  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_1_Shoes_200364251.Models
{
    public class EFBrands : IbrandsMock
    {

        //db connection

        private ShoesModel db = new ShoesModel();
        public ShoesModel Db { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IQueryable<brand> Brands => throw new NotImplementedException();

        public void Delete(brand brand)
        {
            throw new NotImplementedException();
        }

        public brand Save(brand brand)
        {
            throw new NotImplementedException();
        }
    }
}

  