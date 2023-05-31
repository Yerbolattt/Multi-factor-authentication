namespace MultiFactor.Web.ViewModels.Events
{
    using System;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;
    using MultiFactor.Web.ViewModels.Results;

    public class StudentEndedEventViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string QuizName { get; set; }

        public DateTime ActivationDateAndTime { get; set; }

        public string Date { get; set; }

        public ScoreViewModel Score { get; set; }
    }
}
