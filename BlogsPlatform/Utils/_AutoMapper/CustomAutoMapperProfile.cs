using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;

namespace BlogsPlatform.Utils._AutoMapper;

public class CustomAutoMapperProfile : Profile
{
    public CustomAutoMapperProfile()
    {
        base.CreateMap<Author, AuthorDTO>();
        base.CreateMap<Article, ArticleDTO>();
    }
}
