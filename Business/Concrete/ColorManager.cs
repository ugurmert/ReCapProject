using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Business.Constants;
using Core.CrossCuttingConcerns.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == color.Id);
            if (result == true)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            else
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            var result = _colorDal.GetAll().Any(c => c.Id == color.Id);
            if (result)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ColorNotFound);
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
