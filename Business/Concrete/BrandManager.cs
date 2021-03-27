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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
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
                        return new SuccessResult(Messages.BrandAdded);
                    }
                    else
                    {
                        return new ErrorResult(Messages.BrandNameInvalid);
                    }
                }
                else
                {
                    return new ErrorResult(Messages.BrandNameAvailable);
                }
            }
            else
            {
                return new ErrorResult(Messages.BrandIdAvailable);
            }
        }

        public IResult Delete(Brand brand)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brand.Id);
            if (result)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            else
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.GetAll().Any(b => b.Id == brand.Id);
            if (result)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            else
            {
                return new ErrorResult(Messages.BrandNotFound);
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
