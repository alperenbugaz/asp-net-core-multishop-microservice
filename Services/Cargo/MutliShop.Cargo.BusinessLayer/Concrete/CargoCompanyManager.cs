using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;
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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanylDal;
        public CargoCompanyManager(ICargoCompanyDal cargoDetailDal)
        {
            _cargoCompanylDal = cargoDetailDal;   
        }

        public void TAdd(CargoCompany entity)
        {
            _cargoCompanylDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _cargoCompanylDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            var values = _cargoCompanylDal.GetAll();
            return values;
        }

        public CargoCompany TGetById(int id)
        {
            var value = _cargoCompanylDal.GetById(id); ;
            return value;
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanylDal.Update(entity);
        }
    }
}
