﻿using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        //Task<List<ResultOrderAddressDto>> GetAllOrderAddressAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateOrderAddressAsync(EditOrderAddressDto updateOrderAddressDto);
        //Task DeleteOrderAddressAsync(string id);
        //Task<EditOrderAddressDto> GetByIdOrderAddressAsync(string id);
    }
}
