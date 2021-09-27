using DrTaabodi.Data.Models;
using System;
using System.Collections.Generic;

namespace DrTaabodi.Services.QnATable
{
    public interface IQnA
    {
        public bool SaveChanges();
        public List<QnATbl> GetAllQnATbls();
        public QnATbl GetQnATblById(Guid id);
        public ServiceResponse<QnATbl> CreateQnATbl(QnATbl WebPost);
        public ServiceResponse<bool> UpdateQnATblQuestion(Guid id, string Question);
        public ServiceResponse<bool> UpdateQnATblAnswer(Guid id, string Answer);
        public ServiceResponse<bool> UpdateQnATblAnswerOrAnswer(Guid id, string Answer, string Question);
    }
}
