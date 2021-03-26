using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == color.Id);
            var result2 = _colorDal.GetAll().Any(c => c.Name.ToLower() == color.Name.ToLower());
            if (result == false)
            {
                if (result2 == false)
                {
                    if (color.Name.Length >= 2)
                    {
                        _colorDal.Add(color);
                        Console.WriteLine("Added!");
                    }
                    else
                    {
                        Console.WriteLine("Hata! Araba rengi minimum 2 karakter olmalı.");
                    }
                }
                else
                {
                    Console.WriteLine("Hata! Eklemeye çalıştığınız renk adı mevcut");
                }
            }
            else
            {
                Console.WriteLine("Hata! Eklemeye çalıştığınız renk id'si mevcut");
            }
        }

        public void Delete(Color color)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == color.Id);
            if (result)
            {
                _colorDal.Delete(color);
            }
            else
            {
                Console.WriteLine("Hata! Silmek istediğiniz renk mevcut değil");
            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.Id == colorId);
        }

        public void Update(Color color)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == color.Id);
            if (result)
            {
                _colorDal.Update(color);
            }
            else
            {
                Console.WriteLine("Hata! Güncellemek istediğiniz renk mevcut değil");
            }
        }
    }
}

/* Düzeltilmesi Gerekenler:
 * 
 * - GetById metoduna mevcut olmayan Id girilmesi
 * - Update ve Delete metodların mevcut olmayan Id ile işlem yapamaması
 * - Add metodunda renklerin adının boşluk karakteri ile girilmesi problemi
 * - Hali hazırda Cars tablosunda kullanılan ColorId'ye sahip renklerde silme işlemi yapılamamsı
 * 
 */
