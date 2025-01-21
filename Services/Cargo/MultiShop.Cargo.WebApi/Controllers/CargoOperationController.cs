using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation.Barcode = createCargoOperationDto.Barcode;
            cargoOperation.Description = createCargoOperationDto.Description;
            cargoOperation.OperationDate = createCargoOperationDto.OperationDate;
            _cargoOperationService.TAdd(cargoOperation);
            return Ok("Kargo Operasyonu Başarı ile Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Operasyonu Başarı ile Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation.CargoOperationId = updateCargoOperationDto.CargoOperationId;
            cargoOperation.Barcode = updateCargoOperationDto.Barcode;
            cargoOperation.Description = updateCargoOperationDto.Description;
            cargoOperation.OperationDate = updateCargoOperationDto.OperationDate;
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Operasyonu Başarı ile Güncellendi");
        }

    }
}
