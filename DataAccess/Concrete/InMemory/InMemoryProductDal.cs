using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // Oracle, Sql, Postgres, MongoDb
            _products = new List<Product>();
            _products.Add(new Product { ProductName="Iphone telefon"});
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /* new Product() dersen heap ten referasn alırsın sonra bulduğun 
             * dataya atadağında referasn yok olur gereksiz yani */
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);

            /* eğer gelen product ı direk remove a koysaydık gelenin heap 
             * te bir ıd si olmıyacağı için listeden bulunup silinemeyecekti*/
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            // Gelen ürün ıd sine göre listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
