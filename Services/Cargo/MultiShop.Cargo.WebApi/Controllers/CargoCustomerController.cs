using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer.Name = createCargoCustomerDto.Name;
            cargoCustomer.Surname = createCargoCustomerDto.Surname;
            cargoCustomer.Email = createCargoCustomerDto.Email;
            cargoCustomer.Phone = createCargoCustomerDto.Phone;
            cargoCustomer.District = createCargoCustomerDto.District;
            cargoCustomer.City = createCargoCustomerDto.City;
            cargoCustomer.Address = createCargoCustomerDto.Address;

            _cargoCustomerService.TAdd(cargoCustomer);
            return Ok("Kargo Müşterisi Başarı ile Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo Müşterisi Başarı ile Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer.CargoCustomerId = updateCargoCustomerDto.CargoCustomerId;
            cargoCustomer.Name = updateCargoCustomerDto.Name;
            cargoCustomer.Surname = updateCargoCustomerDto.Surname;
            cargoCustomer.Email = updateCargoCustomerDto.Email;
            cargoCustomer.Phone = updateCargoCustomerDto.Phone;
            cargoCustomer.District = updateCargoCustomerDto.District;
            cargoCustomer.City = updateCargoCustomerDto.City;
            cargoCustomer.Address = updateCargoCustomerDto.Address;

            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo Müşterisi Başarı ile Güncellendi");
        }

    }
}
