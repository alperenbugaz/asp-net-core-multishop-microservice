using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutliShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {   
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }
        public void TAdd(CargoDetail entity)
        {
            _cargoDetailDal.Add(entity);    
        }

        public void TDelete(int id)
        {
            _cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            var values =  _cargoDetailDal.GetAll();
            return values;
        }

        public CargoDetail TGetById(int id)
        {
            var value = _cargoDetailDal.GetById(id);
            return value;
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity); 
        }
    }
}
