using AutoMapper;
using Direct4Me_Test.Entities;
using Direct4Me_Test.Models.Articles;
using Direct4Me_Test.Models.DeliveryServiceModel;
using Direct4Me_Test.Models.Users;

namespace Direct4Me_Test.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Article, ArticleModel>();
            CreateMap<SaveArticleModel, Article>();
            CreateMap<SaveWithCodeMode, Article>();
            CreateMap<DeliveryServiceModel, DeliveryService>();
        }
    }
}