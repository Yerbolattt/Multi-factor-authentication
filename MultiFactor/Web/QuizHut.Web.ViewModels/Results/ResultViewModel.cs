namespace MultiFactor.Web.ViewModels.Results
{
    using AutoMapper;
    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class ResultViewModel : IMapFrom<Result>, IHaveCustomMappings
    {
        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public string Score { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Result, ResultViewModel>()
               .ForMember(
                   x => x.StudentName,
                   opt => opt.MapFrom(x => $"{x.Student.FirstName} {x.Student.LastName}"))
               .ForMember(
                   x => x.StudentEmail,
                   opt => opt.MapFrom(x => x.Student.Email))
               .ForMember(
                   x => x.Score,
                   opt => opt.MapFrom(x => $"{x.Points}/{x.MaxPoints}"));
        }
    }
}
