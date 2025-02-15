using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {   
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createUserMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createUserMessageDto);
            await _context.UserMessages.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            _context.UserMessages.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllUserMessagesAsync()
        {
            var value = await _context.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            return  _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInBoxMessageAsync(string id)
        {
            var value = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(value);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendBoxMessageAsync(string id)
        {
            var value = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(value);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateUserMessageDto)
        {
            var value = _mapper.Map<UserMessage>(updateUserMessageDto);
            _context.UserMessages.Update(value);
            await _context.SaveChangesAsync();

        }
    }
}
