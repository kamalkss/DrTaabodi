using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrTaabodi.Data.ExtraCode;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.QnATable;

public interface IQnA
{
    public Task<bool> SaveChanges();
    public Task<IEnumerable<QnATbl>> GetAllQnATbls(QnAParametes qnAParametes);
    public Task<QnATbl> GetQnATblById(Guid id);
    public Task<ServiceResponse<QnATbl>> CreateQnATbl(QnATbl WebPost);

    public Task<ServiceResponse<bool>> UpdateQnATblQuestion(Guid id, QnATbl WebPost);
    //public ServiceResponse<bool> UpdateQnATblAnswer(Guid id, string Answer);
    //public ServiceResponse<bool> UpdateQnATblAnswerOrAnswer(Guid id, string Answer, string Question);
    //public IEnumerable<QnATbl>
}