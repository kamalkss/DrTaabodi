using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Data.Models;
using DrTaabodi.Services.PostTable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<QnATbl> GetAllQnATbls()
        {
            return _context.QnATbl.Include(c => c.UsrTbl).ToList();
        }

        public QnATbl GetQnATblById(Guid id)
        {
            return _context.QnATbl.Include(u => u.UsrTbl)
                .FirstOrDefault(q => q.QnAId == id);
        }

        public ServiceResponse<QnATbl> CreateQnATbl(QnATbl WebPost)
        {
            _logger.LogInformation("Log for Create Post");
            try
            {
                WebPost.UpdatedData = DateTime.UtcNow;
                WebPost.CreatedDate = DateTime.UtcNow; ;
                _context.QnATbl.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdateQnATblQuestion(Guid id, string Question)
        {
            var WebPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {
                WebPost.Question = Question;
                WebPost.UpdatedData = DateTime.UtcNow;
                _context.QnATbl.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdateQnATblAnswer(Guid id, string Answer)
        {
            var WebPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {
                WebPost.Answer = Answer;
                WebPost.UpdatedData = DateTime.UtcNow;
                _context.QnATbl.Add(WebPost);
                SaveChanges();
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

        public ServiceResponse<bool> UpdateQnATblAnswerOrAnswer(Guid id, string Answer, string Question)
        {
            var WebPost = _context.QnATbl.Find(id);
            _logger.LogInformation("Log For Update Qna");
            try
            {
                WebPost.Answer = Answer;
                WebPost.Question = Question;
                WebPost.UpdatedData = DateTime.UtcNow;
                _context.QnATbl.Add(WebPost);
                SaveChanges();
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
