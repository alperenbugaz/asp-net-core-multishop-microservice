using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllUserMessagesAsync();
        Task <List<ResultInboxMessageDto>> GetInBoxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendBoxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createUserMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateUserMessageDto);
        Task <GetByIdMessageDto>GetByIdMessageAsync(int id);
        Task DeleteUserMessageAsync(int id);
        Task<int> GetMessageCount();
    }
}
