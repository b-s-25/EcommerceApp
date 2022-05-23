using BusinesLogic.Interface;
using DomainLayer;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic
{
    public class ProductCatagory : IProductCatagory
    {

        ProductDbContext _Context;
        IRepositryOperation<Product> _repo;
        public ProductCatagory(ProductDbContext Context)
        {
            _Context = Context;
            _repo = new RepositryOperation<Product>(_Context);
        }

        public void Create(Product entity)
        {
            _repo.Create(entity);
            _repo.Save();
        }


        public void Delete(Product entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

        public Product Details(int id)
        {
            return _repo.Details(id);
        }

        public IEnumerable<Product> index()
        {
            return _repo.Index();
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update(Product entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
    }
}

