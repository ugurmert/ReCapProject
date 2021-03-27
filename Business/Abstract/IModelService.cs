﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<Model>> GetAll();
        IDataResult<List<Model>> GetModelsByBrandId(int id);
        IDataResult<Model> GetById(int modelId);
        IResult Add(Model model);
        IResult Delete(Model model);
        IResult Update(Model model);
    }
}
