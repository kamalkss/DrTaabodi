using System.Threading;
using System.Threading.Tasks;

namespace DrTaabodi.WebApi.Generics
{
    public interface Ifaq
    {
        Task<GetFaqResponse> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);

    }
}
