﻿using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutliShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        CargoCustomer TGetCargoCustomerById(string id);

    }
}
