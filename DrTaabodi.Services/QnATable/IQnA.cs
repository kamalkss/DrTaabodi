using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrTaabodi.Data.Models;

namespace DrTaabodi.Services.QnATable
{
    public interface IQnA
    {
        public bool SaveChanges();
        public List<QnATbl> GetAllQnATbls();
        public QnATbl GetQnATblById(Guid id);
        public ServiceResponse<QnATbl> CreateQnATbl(QnATbl WebPost);
        public ServiceResponse<bool> UpdateQnATblQuestion(Guid id, string Question);
        public ServiceResponse<bool> UpdateQnATblAnswer(Guid id, string  Answer);
    }
}
