using AutoMapper;
using DrTaabodi.Data.Models;
using DrTaabodi.WebApi.DTO.FileSystemDTO;

namespace DrTaabodi.WebApi.Profiles;

public class FileSystemProfile : Profile
{
    public FileSystemProfile()
    {
        CreateMap<CreateFileSystem, FileSystemTbl>();
        CreateMap<ReadFileSystem, FileSystemTbl>();
        CreateMap<FileSystemTbl, CreateFileSystem>();
        CreateMap<FileSystemTbl, ReadFileSystem>();

        CreateMap<CreateFileSystem, FileSystemTbl>().ReverseMap();
        CreateMap<ReadFileSystem, FileSystemTbl>().ReverseMap();
        CreateMap<FileSystemTbl, CreateFileSystem>().ReverseMap();
        CreateMap<FileSystemTbl, ReadFileSystem>().ReverseMap();
    }
}