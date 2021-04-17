using System;
using System.Collections.Generic;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryCarDAL memoryCarDal = new InMemoryCarDAL();
            CarManager carManager=new CarManager(memoryCarDal);

            

           NCar car1 = new NCar();
           car1.Description = "test";
           car1.Id = 6;
           car1.ModelYear = 1500;
            carManager.Add(car1);

            
           
         // carManager.Delete(car1);

           foreach (var items in carManager.GetAll())
           {
               Console.WriteLine(items.Description);
           }
           Console.WriteLine("-------get by id----------");
           foreach (var itemsCar in carManager.GetById(6))
           {
            Console.WriteLine(itemsCar.Description);   
           }

           car1.ModelYear = 1890;
            carManager.Update(car1);
          
       

            Console.Read();
        }
    }
}
