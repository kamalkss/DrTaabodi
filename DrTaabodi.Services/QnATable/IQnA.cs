using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DrTaabodi.Services.QnATable
{
    public interface IQnA
    {
        
        public bool SaveChanges();
        public IEnumerable<QnATbl> GetAllQnATbls(QnAParametes qnAParametes);
        public QnATbl GetQnATblById(Guid id);
        public ServiceResponse<QnATbl> CreateQnATbl(QnATbl WebPost);
        public ServiceResponse<bool> UpdateQnATblQuestion(Guid id, QnATbl WebPost);
        //public ServiceResponse<bool> UpdateQnATblAnswer(Guid id, string Answer);
        //public ServiceResponse<bool> UpdateQnATblAnswerOrAnswer(Guid id, string Answer, string Question);
        //public IEnumerable<QnATbl>
    }
}
