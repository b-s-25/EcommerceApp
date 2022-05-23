using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interface
{
    public interface IProductCatagory
    {
        IEnumerable<Product> index();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product Details(int id);
        void Save();
    }
}
