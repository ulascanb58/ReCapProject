using System;
using System.Collections.Generic;
using System.Linq;
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
            // BrandTest();
            // CarDetails();
             ///AddCar();
           //  GetCarDescription();
            //BrandTest();
            ColorTest();
            //GetCarByBrandId(1);
           // GetCarByColorId(1);

           //GetCarById(1);

         

          // GetCarByPrice(5,950000);

          //RenkSilmeTesti();



          Console.Read();
        }

        
        private static void RenkSilmeTesti()
        {
            NColor color = new NColor();
            color.ColorName = "SİLİNECEK OLAN RENK";
            ColorManager colorManager = new ColorManager(new EfColorDAL());
            colorManager.AddColor(color);
            ColorTest();
            Console.WriteLine("----SİLME İŞLEMİ DEVREYE SOKULUYOR---");
            colorManager.DeleteColor(color);
            ColorTest();
        }


        private static void CarDetails()
        {

           CarManager carmanager2 = new CarManager(new EfCarDAL());
           var result = carmanager2.GetCarDetails();

           if (result.Success == true)
           {
               foreach (var items in result.Data)
               {
                   
                  Console.WriteLine("Arabanın Id'si : " + items.CarId + "\n" + "Arabanın adı  : " + items.CarDescription + "\n" + "Arabanın modeli : " + items.BrandName + "\n" + "Arabanın rengi : " + items.ColorName);
                   Console.WriteLine("***********************************");
                   
                }
           }
           else
           {
               {
                   Console.WriteLine(result.Message);
               }
              
           }
           
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDAL());
            var result = colorManager.GetAll();
            foreach (var items in result.Data)
            {
                Console.WriteLine(items.ColorName+" "+result.Message);
                
            }
        }

        private static void DeleteColor(NColor color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDAL());
            colorManager.DeleteColor(color);
        }
        private static void AddColor(NColor color)
        {
            ColorManager colorManager=new ColorManager(new EfColorDAL());
            colorManager.AddColor(color);
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDAL());
            foreach (var items in brandManager.GetAll().Data)
            {
                Console.WriteLine(items.BrandName);
            }
        }

        // ARABALAR İÇİN ---------------------------
        private static void GetCarDescription()
        {
            CarManager carManager = new CarManager(new EfCarDAL());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var items in result.Data)
                {
                    Console.WriteLine("Araba adı : {0}", items.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar()
        {
            CarManager Carmanager = new CarManager(new EfCarDAL());
            
           
           var result= Carmanager.AddCar(new NCar{BrandId = 1,ColorId = 2,DailyPrice = 8000,Description ="Yeni araba5"});
           Console.WriteLine(result.Message);
           
            
        }

        private static void GetCarByBrandId(int id)
        {
            CarManager carManager = new CarManager(new EfCarDAL());
            var result = carManager.GetCarsByBrandId(id);

            foreach (var itemsCar in result.Data)
            {
                Console.WriteLine(itemsCar.Description);
            }

        }

        private static void GetCarByColorId(int id)
        {
            CarManager carManager = new CarManager(new EfCarDAL());
            foreach (var items in carManager.GetCarsByColorId(id).Data)
            {
                Console.WriteLine(items.Description+"renk id si : "+items.ColorId);
            }

        }

        private static void GetCarById(int id)
        {
            CarManager carManager = new CarManager(new EfCarDAL());
           Console.WriteLine(carManager.GetCarsById(id).Data);
        }

        private static void GetCarByPrice(decimal min, decimal max)
        {
            CarManager carManager = new CarManager(new EfCarDAL());
            Console.WriteLine("Girilen aralık : " + min + "-" + max);
            foreach (var items in carManager.GetByDailyPrice(min,max).Data)
            {
               // Console.WriteLine("Araba adı :{0} - Fiyatı : {1}"+items.Description,items.DailyPrice);
               Console.WriteLine(items.Description+" - "+items.DailyPrice);
            }
        
        }
    }
}
