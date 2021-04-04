﻿using Business.Concrete;
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

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
