using System.Collections.Generic;

namespace DrTaabodi.Services.FileSystemService;

public interface ISelectRepository<FileTModel>
{
    FileTModel SelectOne(
        string id);

    IEnumerable<FileTModel> SelectMany(
        string id);
}