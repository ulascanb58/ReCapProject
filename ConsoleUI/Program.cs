using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           CarManager carManager = new CarManager(new EfCarDAL());
/*
           foreach (var items in carManager.GetAll())
           {
               Console.WriteLine(items.Description);
               
           }*/

/*
           foreach (var items in carManager.GetCarsByBrandId(3))
           {    
               Console.WriteLine(items.Description);
           }
          */


            /*foreach (var items in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("Renk ID : " +items.ColorId + " - " + items.Description);
            }*/
            /*
            NCar araba1 = new NCar();
          
            araba1.BrandId = 5;
            araba1.ColorId = 2;
            araba1.ModelYear = 2017;
            araba1.Description = "Bentley 3";
            araba1.DailyPrice = 95000;
            carManager.AddCar(araba1);
            */

            foreach (var items in carManager.GetAll())
            {
                Console.WriteLine(items.Description);

            }
          

            Console.Read();
        }
    }
}
