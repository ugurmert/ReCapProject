using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brand.Id);
            var result2 = _brandDal.GetAll().Any(b => b.Name.ToLower() == brand.Name.ToLower());
            if (result == false)
            {
                if (result2 == false)
                {
                    if (brand.Name.Length >= 2)
                    {
                        _brandDal.Add(brand);
                        Console.WriteLine("Added!");
                    }
                    else
                    {
                        Console.WriteLine("Hata! Araba markasının adı minimum 2 karakter olmalı.");
                    }
                }
                else
                {
                    Console.WriteLine("Hata! Eklemeye çalıştığınız marka adı mevcut");
                }
            }
            else
            {
                Console.WriteLine("Hata! Eklemeye çalıştığınız marka id'si mevcut");
            }
        }

        public void Delete(Brand brand)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brand.Id);
            if (result)
            {
                _brandDal.Delete(brand);
            }
            else
            {
                Console.WriteLine("Hata! Silmek istediğiniz marka mevcut değil");
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.Id == brandId);
        }

        public void Update(Brand brand)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brand.Id);
            if (result)
            {
                _brandDal.Update(brand);
            }
            else
            {
                Console.WriteLine("Hata! Güncellemek istediğiniz marka mevcut değil");
            }
        }
    }
}

/* Düzeltilmesi Gerekenler:
 * 
 * - GetById metoduna mevcut olmayan Id girilmesi
 * - Update ve Delete metodların mevcut olmayan Id ile işlem yapamaması
 * - Add metodunda marka adının boşluk karakteri ile girilmesi problemi
 * - Hali hazırda Models tablosunda kullanılan BrandId'ye sahip markalarda silme işlemi yapılamamsı
 * 
 */
