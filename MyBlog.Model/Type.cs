using SqlSugar;

namespace MyBlog.Model;

public class Type:BaseId
{
    [SugarColumn(ColumnDataType = "nvarchar(12)")]
    public string Name {get; set;}
}
