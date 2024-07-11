using SqlSugar;

namespace MyBlog.Model;


public class Author:BaseId
{
    [SugarColumn(ColumnDataType = "nvarchar(12)")]
    public string Name {get; set;}

    [SugarColumn(ColumnDataType = "nvarchar(16)")]
    public string AccountNumber {get; set;}

    [SugarColumn(ColumnDataType = "nvarchar(64)")]
    public string Password {get; set;}
}
