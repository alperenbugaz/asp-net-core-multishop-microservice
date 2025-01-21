using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using MutliShop.Cargo.BusinessLayer.Abstract;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail();
            cargoDetail.CargoCompanyId = createCargoDetailDto.CargoCompanyId;
            cargoDetail.SenderCustomer = createCargoDetailDto.SenderCustomer;
            cargoDetail.RecieverCustomer = createCargoDetailDto.RecieverCustomer;
            cargoDetail.Barcode = createCargoDetailDto.Barcode;


            _cargoDetailService.TAdd(cargoDetail);
            return Ok("Kargo Detayı Başarı ile Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayı Başarı ile Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail();
            cargoDetail.CargoDetailId = updateCargoDetailDto.CargoDetailId;
            cargoDetail.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;
            cargoDetail.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            cargoDetail.RecieverCustomer = updateCargoDetailDto.RecieverCustomer;
            cargoDetail.Barcode = updateCargoDetailDto.Barcode;
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Detayı Başarı ile Güncellendi");
        }

    }
}
