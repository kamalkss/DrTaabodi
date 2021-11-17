using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrTaabodi.Services.QnATable
{
    public class SqlQna : IQnA
    {
        private readonly DrTaabodiDbContext _context;
        private readonly ILogger<SqlQna> _logger;


        public SqlQna(DrTaabodiDbContext _db, ILogger<SqlQna> logger)
        {
            _context = _db;
            _logger = logger;

        }
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<QnATbl>> GetAllQnATbls(QnAParametes qnAParametes)
        {
            return await _context.QnATbl.Include(c => c.UserTable).OrderBy(on => on.QnAId)
                .Skip((qnAParametes.PageNumber - 1) * qnAParametes.PageSize).Take(qnAParametes.PageSize).ToListAsync();
        }

        public async Task<QnATbl> GetQnATblById(Guid id)
        {
            return await _context.QnATbl.Include(u => u.UserTable)
                .FirstOrDefaultAsync(q => q.QnAId == id);
        }

        public async Task<ServiceResponse<QnATbl>> CreateQnATbl(QnATbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow; ;
                await _context.QnATbl.AddAsync(WebPost);
                await SaveChanges();
                return new ServiceResponse<QnATbl>
                {
                    Data = WebPost,
                    IsSucceess = true,
                    Messege = "Qna Created",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<QnATbl>
                {
                    Data = null,
                    IsSucceess = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public async Task<ServiceResponse<bool>> UpdateQnATblQuestion(Guid id, QnATbl WebPost)
        {
            var UpdatedPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {

                WebPost.UpdatedData = DateTime.UtcNow;
                _context.Entry(UpdatedPost).CurrentValues.SetValues(WebPost);
                await SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucceess = true,
                    Data = true,
                    Messege = " Qna Updated",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucceess = false,
                    Data = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public async Task<ServiceResponse<bool>> UpdateQnATblAnswer(Guid id, string Answer)
        {
            var WebPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {
                WebPost.Answer = Answer;
                WebPost.UpdatedData = DateTime.UtcNow;
                await _context.QnATbl.AddAsync(WebPost);
                await SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucceess = true,
                    Data = true,
                    Messege = " Qna Updated",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucceess = false,
                    Data = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }

        public async Task<ServiceResponse<bool>> UpdateQnATblAnswerOrAnswer(Guid id, string Answer, string Question)
        {
            var WebPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {
                WebPost.Answer = Answer;
                WebPost.Question = Question;
                WebPost.UpdatedData = DateTime.UtcNow;
                await _context.QnATbl.AddAsync(WebPost);
                await SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucceess = true,
                    Data = true,
                    Messege = " Qna Updated",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucceess = false,
                    Data = false,
                    Messege = e.Message,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
