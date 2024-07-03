using Finshark.API.Models;

namespace Finshark.API.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> CreateAsysnc(Comment commentModel);
        Task<Comment?> UpdateAsysnc(int id, Comment commentModel);
        Task<Comment?> DeleteAsync(int id);
    }
}
