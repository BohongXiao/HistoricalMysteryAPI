using AutoMapper;
using HistoricalMysteryAPI.Contracts;
using HM.DataAccess.DB.Models;

namespace HistoricalMysteryAPI.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticleItemDto, ArticleItem>().ReverseMap();
            CreateMap<ArticleContentDto, ArticleContent>().ReverseMap();
            CreateMap<ArticleContentRequest, NewArticleContentRequest>().ReverseMap();
        }
    }
}
