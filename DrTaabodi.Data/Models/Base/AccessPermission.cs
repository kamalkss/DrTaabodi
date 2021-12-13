namespace DrTaabodi.Data.Models.Base;

public class AccessPermission
{
    public bool Copy = true;
    public bool Download = true;
    public string Message = string.Empty;
    public bool Read = true;
    public bool Upload = true;
    public bool Write = true;
    public bool WriteContents = true;
}