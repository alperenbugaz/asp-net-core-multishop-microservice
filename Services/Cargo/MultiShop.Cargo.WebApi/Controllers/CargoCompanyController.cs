using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyName = createCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TAdd(cargoCompany);

            return Ok("Kargo Şirketi Başarı ile Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi Başarı ile Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyId = updateCargoCompanyDto.CargoCompanyId;
            cargoCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo Şirketi Başarı ile Güncellendi");
        }

    }
}
