namespace MultiFactor.Web.ViewModels.Categories
{
    using System;

    using AutoMapper;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string QuizzesCount { get; set; }

        public string CreatedOnDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(
                    x => x.QuizzesCount,
                    opt => opt.MapFrom(x => x.Quizzes.Count));
        }
    }
}
