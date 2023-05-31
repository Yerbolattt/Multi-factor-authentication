namespace MultiFactor.Web.ViewModels.Events
{
    using System;

    using MultiFactor.Data.Models;
    using MultiFactor.Services.Mapping;

    public class StudentPendingEventViewModel : IMapFrom<Event>
    {
        public string Name { get; set; }

        public string QuizName { get; set; }

        public string Date { get; set; }

        public string Duration { get; set; }

        public DateTime ActivationDateAndTime { get; set; }

        public TimeSpan DurationOfActivity { get; set; }
    }
}
