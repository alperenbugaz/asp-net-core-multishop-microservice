using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInBoxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendBoxMessageAsync(string id);
        //Task CreateMessageAsync(CreateMessageDto createUserMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateUserMessageDto);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        //Task DeleteUserMessageAsync(int id);
    }
}
