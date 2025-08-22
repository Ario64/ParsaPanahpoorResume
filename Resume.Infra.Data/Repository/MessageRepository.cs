using Resume.Domain.IRepository.Message;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;

namespace Resume.Infra.Data.Repository;

public class MessageRepository : GenericRepository<Message>, IMessageRepository
{
    #region ctor

    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}