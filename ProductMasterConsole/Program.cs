﻿using System;
using System.Linq;
using ProductMasterConsole.Model;
using ProductMasterConsole.Repository;

namespace ProductMasterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your selection:");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ReadDataUsingADO();
                    break;
                case "2":
                    ReadDataUsingEfCore();
                    break;
                case "3":
                    ReadDataUsingEfCoreIEnumerable();
                    ReadDataUsingEfCoreIQueryable();
                    break;
                case "4":
                    ReadDataUsingStoredProcedure();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void ReadDataUsingStoredProcedure()
        {
            var service = new StoredProcedureWithEFCore();
            var result = service.GetProductName();
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void ReadDataUsingADO()
        {
            Console.WriteLine("Retrive data using ADO.Net.");
            var productRepositoryUsingAdo = new ProductRepositoryUsingADO();
            var result = productRepositoryUsingAdo.AllProducts();
            PrintProduct(result);
        }

        private static void ReadDataUsingEfCore()
        {
            var productREpoositoryUsingEFCore = new ProductREpoositoryUsingEFCore();
            var result = productREpoositoryUsingEFCore.AllProducts();
            PrintProduct(result);
        }
        
        private static void ReadDataUsingEfCoreIEnumerable()
        {
            var repository = new ProductRetrievalUsingIEnumerable();
            var result = repository.ProductByNameLike("Mobile").Count();
            Console.WriteLine($@"Total Result retrieved using IEnumerable : {result}");
        }
        private static void ReadDataUsingEfCoreIQueryable()
        {
            var repository = new ProductRetrievalUsingIQueryable();
            var result = repository.ProductByNameLike("Mobile").Count();
            Console.WriteLine($@"Total Result retrieved using IQueryable : {result}");
        }

        private static void PrintProduct(Product[] result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($@"Id : {item.Id}; Name: {item.ProductName}");
            }
        }
    }
}