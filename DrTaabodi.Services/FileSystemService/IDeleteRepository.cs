namespace DrTaabodi.Services.FileSystemService;

public interface IDeleteRepository<TModel>
{
    bool Delete(
        string id);
}