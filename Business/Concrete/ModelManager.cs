using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Model model)
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
                        return new SuccessResult(Messages.ModelAdded);
                    }
                    else
                    {
                        return new ErrorResult(Messages.ModelNameInvalid);
                    }
                }
                else
                {
                    return new ErrorResult(Messages.ModelNameAvailable);
                }
            }
            else
            {
                return new ErrorResult(Messages.ModelIdAvailable);
            }
        }

        public IResult Delete(Model model)
        {
            var result = _modelDal.GetAll().Any(m => m.Id == model.Id);
            if (result)
            {
                _modelDal.Delete(model);
                return new SuccessResult(Messages.ModelDeleted);
            }
            else
            {
                return new ErrorResult(Messages.ModelNotFound);
            }
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IDataResult<Model> GetById(int modelId)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m => m.Id == modelId));
        }

        public IDataResult<List<Model>> GetModelsByBrandId(int id)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.BrandId == id));
        }

        public IResult Update(Model model)
        {
            var result = _modelDal.GetAll().Any(m => m.Id == model.Id);
            if (result)
            {
                _modelDal.Update(model);
                return new SuccessResult(Messages.ModelUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ModelNotFound);
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
