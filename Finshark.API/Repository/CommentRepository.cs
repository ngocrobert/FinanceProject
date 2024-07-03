using Finshark.API.Data;
using Finshark.API.Interfaces;
using Finshark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Finshark.API.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsysnc(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(commentModel == null)
            {
                return null;
            }
            _context.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;

        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            // var comment = await _context.Comments.Include(c => 
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsysnc(int id, Comment commentModel)
        {
            var existngComment = await _context.Comments.FindAsync(id);
            if (existngComment == null)
            {
                return null;
            }

            existngComment.Title = commentModel.Title;
            existngComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return existngComment;

        }
    }
}
