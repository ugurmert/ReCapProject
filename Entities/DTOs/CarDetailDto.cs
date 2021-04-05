﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
