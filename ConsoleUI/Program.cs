using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ColorTest();

            //BrandTest();

            //ModelTest();

            //Cartest();

            //RentalTest();
        }
        
        private static void RentalTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Uğur", LastName = "Mert", Email = "ugur@gmail.com" });
            userManager.Add(new User { FirstName = "Burak", LastName = "Seçginer", Email = "burak@gmail.com"});

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 2, CompanyName = "B Şirketi" });
            customerManager.Add(new Customer { UserId = 1, CompanyName = "U Şirketi" });

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 2, 10), ReturnDate = new DateTime(2021, 2, 15) });
            Console.WriteLine(result.Message);
        }

        private static void Cartest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { ModelId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 445.28, Description = "Audi A6 Kırmızı" });
            carManager.Add(new Car { ModelId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 438.50, Description = "Mercedes A200 Beyaz" });
            carManager.Add(new Car { ModelId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 475.32, Description = "Audi A6 Beyaz" });
            carManager.Add(new Car { ModelId = 4, ColorId = 1, ModelYear = 2020, DailyPrice = 448.97, Description = "Fiat Linea Kırmızı" });
            carManager.Add(new Car { ModelId = 4, ColorId = 2, ModelYear = 2018, DailyPrice = 344.10, Description = "Fiat Linea Beyaz" });
            carManager.Add(new Car { ModelId = 5, ColorId = 2, ModelYear = 2021, DailyPrice = 481.76, Description = "Renault Megane Beyaz" });
            carManager.Add(new Car { ModelId = 6, ColorId = 2, ModelYear = 2020, DailyPrice = 459.51, Description = "Renault Clio Beyaz" });

            Console.WriteLine("\n--- Ekleme sonrası detaylı araba listesi ---\n");

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka: {0} - Model: {1} - Renk: {2} - Günlük Fiyat: {3}", car.BrandName, car.ModelName, car.ColorName, car.DailyPrice);
            }

            Console.WriteLine("\n--- Modeli Linea olan arabaların listesi ---\n");

            foreach (var car in carManager.GetCarsByModelId(4).Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", car.Id, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("\n--- Rengi Beyaz olan arabaların listesi ---\n");

            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine("{0} {1} {2} {3}", car.Id, car.ModelYear, car.DailyPrice, car.Description);
            }

            var tempUpdate = carManager.GetById(5).Data;
            tempUpdate.ModelYear = 2019;
            carManager.Update(tempUpdate);

            var tempUpdate2 = carManager.GetById(6).Data;
            tempUpdate2.DailyPrice = 465.75;
            carManager.Update(tempUpdate2);

            Console.WriteLine("\n--- Güncelleme sonrası araba listesi ---\n");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.Id, car.ModelYear, car.DailyPrice, car.Description);
            }

            var result = carManager.Delete(carManager.GetById(2).Data);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            carManager.Delete(carManager.GetById(4).Data);

            Console.WriteLine("\n--- Silme sonrası araba listesi ---\n");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.Id, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void ModelTest()
        {
            ModelManager modelManager = new ModelManager(new EfModelDal());

            modelManager.Add(new Model { Id = 1, BrandId = 1, Name = "A6" });
            modelManager.Add(new Model { Id = 2, BrandId = 2, Name = "A 200" });
            modelManager.Add(new Model { Id = 3, BrandId = 5, Name = "Egea" });
            modelManager.Add(new Model { Id = 4, BrandId = 5, Name = "Linea" });
            modelManager.Add(new Model { Id = 5, BrandId = 7, Name = "Megane" });
            modelManager.Add(new Model { Id = 6, BrandId = 7, Name = "Clio" });
            modelManager.Add(new Model { Id = 7, BrandId = 2, Name = "A7" });
            modelManager.Add(new Model { Id = 7, BrandId = 3, Name = "i10" });       //BrandId=3 mevcut olmadığından hata mesajı verecektir

            Console.WriteLine("\n--- Ekleme sonrası model listesi ---\n");

            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Model: {1}", model.Id, model.Name);
            }

            var result = modelManager.GetById(2).Data;
            result.Name = "A200";
            modelManager.Update(result);

            var result2 = modelManager.GetById(3).Data;
            result2.BrandId = 1;
            modelManager.Update(result2);

            Console.WriteLine("\n--- Güncelleme sonrası model listesi ---\n");

            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Model: {1}", model.Id, model.Name);
            }

            modelManager.Delete(modelManager.GetById(3).Data);

            Console.WriteLine("\n--- Silme sonrası model listesi ---\n");

            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Model: {1}", model.Id, model.Name);
            }

            Console.WriteLine("\n--- BrandId=7 olan model listesi ---\n");

            foreach (var model in modelManager.GetModelsByBrandId(7).Data)
            {
                Console.WriteLine("id: {0} Model: {1}", model.Id, model.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { Id = 1, Name = "Audi" });
            brandManager.Add(new Brand { Id = 1, Name = "Renault" });       //Id=1 mevcut olduğundan hata mesajı verecektir
            brandManager.Add(new Brand { Id = 2, Name = "Mercedes" });
            brandManager.Add(new Brand { Id = 3, Name = "Hundai" });
            brandManager.Add(new Brand { Id = 4, Name = "Opel" });
            brandManager.Add(new Brand { Id = 5, Name = "Fiat" });
            brandManager.Add(new Brand { Id = 6, Name = "Nissan" });
            brandManager.Add(new Brand { Id = 7, Name = "Citroen" });
            brandManager.Add(new Brand { Id = 8, Name = "OPEL" });          //OPEL ve Opel isimleri aynı olduğundan hata mesajı verecektir

            Console.WriteLine("\n--- Ekleme sonrası marka listesi ---\n");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Marka: {1}", brand.Id, brand.Name);
            }

            var result = brandManager.GetById(7).Data;
            result.Name = "Renault";
            brandManager.Update(result);

            var result2 = brandManager.GetById(3).Data;
            result2.Name = "Hyundai";
            brandManager.Update(result2);

            Console.WriteLine("\n--- Güncelleme sonrası marka listesi ---\n");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Marka: {1}", brand.Id, brand.Name);
            }

            brandManager.Delete(brandManager.GetById(3).Data);
            brandManager.Delete(brandManager.GetById(4).Data);
            brandManager.Delete(brandManager.GetById(6).Data);

            Console.WriteLine("\n--- Silme sonrası marka listesi ---\n");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Marka: {1}", brand.Id, brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { Id = 1, Name = "Mavi" });
            colorManager.Add(new Color { Id = 2, Name = "Beyaz" });
            colorManager.Add(new Color { Id = 3, Name = "SIYAH" });
            colorManager.Add(new Color { Id = 1, Name = "Gri" });           //Id=1 mevcut olduğundan hata mesajı verecektir
            colorManager.Add(new Color { Id = 4, Name = "Gri" });

            Console.WriteLine("\n--- Ekleme sonrası renk listesi ---\n");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Renk: {1}", color.Id, color.Name);
            }

            var result1 = colorManager.GetById(1).Data;
            result1.Name = "Kırmızı";
            colorManager.Update(result1);

            var result2 = colorManager.GetById(3).Data;
            result2.Name = "Siyah";
            colorManager.Update(result2);

            Console.WriteLine("\n--- Güncelleme sonrası renk listesi ---\n");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Renk: {1}", color.Id, color.Name);
            }

            colorManager.Delete(colorManager.GetById(3).Data);
            colorManager.Delete(colorManager.GetById(4).Data);

            Console.WriteLine("\n--- Silme sonrası renk listesi ---\n");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("id: {0} Renk: {1}", color.Id, color.Name);
            }
        }

    }
}
