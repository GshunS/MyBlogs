namespace MyBlog.Model.DTO;

public class ArticleDTO
{
    public string Title {get; set;}
    public string Content {get; set;}
    public DateTime createdTime {get; set;}
    public int ArticleType {get; set;}
    public int ViewAmount {get; set;}
    public int LikeCount {get; set;}
    public int AuthorId {get; set;}

    public Type TypeID {get; set;}

    public AuthorDTO NewAuthorID {get; set;}
}
