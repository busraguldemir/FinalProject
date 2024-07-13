using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Crop",UnitsPrice=250,UnitsInStock=1},
                new Product{ProductId=2, CategoryId=1, ProductName="Şort",UnitsPrice=250,UnitsInStock=1},
                new Product{ProductId=3, CategoryId=2, ProductName="Etek",UnitsPrice=250,UnitsInStock=1},
                new Product{ProductId=4, CategoryId=2, ProductName="Elbise",UnitsPrice=450,UnitsInStock=1},
                new Product{ProductId=5, CategoryId=2, ProductName="Çanta",UnitsPrice=250,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query 

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }


        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsPrice = product.UnitsPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();                      
        }

    }
}
