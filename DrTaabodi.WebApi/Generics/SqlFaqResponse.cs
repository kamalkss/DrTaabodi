using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.WebApi.DTO.QnAs;
using DrTaabodi.WebApi.Extentions;
using Microsoft.EntityFrameworkCore;

namespace DrTaabodi.WebApi.Generics
{
    public class SqlFaqResponse:Ifaq
    {
        private readonly DrTaabodiDbContext _dbContext;

        public SqlFaqResponse(DrTaabodiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetFaqResponse> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
        {
            var hobbies = await _dbContext.QnATbl
                .AsNoTracking()
                .OrderBy(p=>p.CreatedDate)
                .PaginateAsync(page, limit, cancellationToken);

            return new GetFaqResponse()
            {
                CurrentPage = hobbies.CurrentPage,
                TotalPages = hobbies.TotalPages,
                TotalItems = hobbies.TotalItems,
                Items = hobbies.Items.Select(p => new ReadQnAs()
                {
                    QnAId = p.QnAId,
                    Question = p.Question,
                    Answer = p.Answer
                }).ToList()
            };
        }
    }
}
