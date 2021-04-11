using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsolUI
{
    //SOLID
    //Open Closed Principle sen sisteme yeni birşey ekliyorsan mevcuttaki hiçbir koda dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            ProductByCategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), 
                new CategoryManager(new EfCategoryDal()));

            foreach (var item in productManager.GetAll().Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void ProductByCategoryTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),
                new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + "/" + item.CategoryName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
