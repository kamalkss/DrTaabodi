using System;

namespace DrTaabodi.Services.FileSystemService.Formatter;

public static class FormatterFactory
{
    public static IFileSystemFormatter CreateInstance(string Formatter = null)
    {
        Formatter = Formatter ?? "Default";

        var type = Type.GetType($"DrTaabodi.Services.FileSystemService.Formatter.{Formatter}FileSystemFormatter");
        return Activator.CreateInstance(type) as IFileSystemFormatter;
    }
}