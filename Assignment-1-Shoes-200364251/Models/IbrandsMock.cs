using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Shoes_200364251.Models
{
    interface IbrandsMock
    {
        IQueryable Brands { get; }
        brand Save(brand brand);

        void Delete(brand brand);

        

    }
}
