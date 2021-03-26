using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public void Add(Model model)
        {
            var result = _modelDal.GetAll().Any(m => m.Id == model.Id);
            var result2 = _modelDal.GetAll().Any(m => m.Name.ToLower() == model.Name.ToLower() && m.BrandId == model.BrandId);
            if (result == false)
            {
                if (result2 == false)
                {
                    if (model.Name.Length >= 2)
                    {
                        _modelDal.Add(model);
                        Console.WriteLine("Added!");
                    }
                    else
                    {
                        Console.WriteLine("Hata! Araba modelinin adı minimum 2 karakter olmalı.");
                    }
                }
                else
                {
                    Console.WriteLine("Hata! Marka ve model bilgilerini kontrol edin");
                }
            }
            else
            {
                Console.WriteLine("Hata! Eklemeye çalıştığınız model id'si mevcut");
            }
        }

        public void Delete(Model model)
        {
            var result = _modelDal.GetAll().Any(m => m.Id == model.Id);
            if (result)
            {
                _modelDal.Delete(model);
            }
            else
            {
                Console.WriteLine("Hata! Silmek istediğiniz model mevcut değil");
            }
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public Model GetById(int modelId)
        {
            return _modelDal.Get(m => m.Id == modelId);
        }

        public List<Model> GetModelsByBrandId(int id)
        {
            return _modelDal.GetAll(m => m.BrandId == id);
        }

        public void Update(Model model)
        {
            var result = _modelDal.GetAll().Any(m => m.Id == model.Id);
            if (result)
            {
                _modelDal.Update(model);
            }
            else
            {
                Console.WriteLine("Hata! Güncellemek istediğiniz model mevcut değil");
            }
        }
    }
}

/* Düzeltilmesi Gerekenler:
 * 
 * - GetById metoduna mevcut olmayan Id girilmesi
 * - Update ve Delete metodların mevcut olmayan Id ile işlem yapamaması
 * - Add metodunda model adının boşluk karakteri ile girilmesi problemi
 * - Hali hazırda Cars tablosunda kullanılan ModelId'ye sahip modellerde silme işlemi yapılamamsı
 * 
 */
