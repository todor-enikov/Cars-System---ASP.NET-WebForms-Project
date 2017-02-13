﻿using CarsSystem.Data.Models;
using System.Collections.Generic;

namespace CarsSystem.Services.Data.Contracts
{
    public interface IFilterService
    {
        IEnumerable<Car> FilterExpiringVignetteCars();
        IEnumerable<Car> FilterExpiringInsurance();
        IEnumerable<Car> FilterExpiringAnnualCheckUp();
    }
}
