using SqlSugar;

namespace MyBlog.Model;

public class Article:BaseId
{
    [SugarColumn(ColumnDataType = "nvarchar(30)")]
    public string Title {get; set;}

    [SugarColumn(ColumnDataType = "text")]
    public string Content {get; set;}

    public DateTime createdTime {get; set;}
    public int ArticleType {get; set;}
    public int ViewAmount {get; set;}
    public int LikeCount {get; set;}
    public int AuthorId {get; set;}

    [SugarColumn(IsIgnore = true)]
    public Type TypeID {get; set;}

    [SugarColumn(IsIgnore = true)]
    public Author NewAuthorID {get; set;}
}
