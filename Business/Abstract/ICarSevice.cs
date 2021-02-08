using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarSevice
    {
        List<Car> GetAll();
        List<Car> GetById(int id);
    }
}
