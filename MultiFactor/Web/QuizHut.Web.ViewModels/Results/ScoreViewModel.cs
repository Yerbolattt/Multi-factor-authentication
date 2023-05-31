namespace MultiFactor.Web.ViewModels.Results
{
    using AutoMapper;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class ScoreViewModel : IMapFrom<Result>, IHaveCustomMappings
    {
        public string EventId { get; set; }

        public string Score { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Result, ScoreViewModel>()
               .ForMember(
                   x => x.Score,
                   opt => opt.MapFrom(x => $"{x.Points}/{x.MaxPoints}"));
        }
    }
}
