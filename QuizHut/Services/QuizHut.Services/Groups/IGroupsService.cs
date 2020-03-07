﻿namespace QuizHut.Services.Groups
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using QuizHut.Web.ViewModels.Events;
    using QuizHut.Web.ViewModels.Groups;
    using QuizHut.Web.ViewModels.Students;

    public interface IGroupsService
    {
        Task<IList<T>> GetAllByCreatorIdAsync<T>(string id, string eventId = null);

        Task<string> CreateAsync(string name, string creatorId);

        Task<GroupWithEventsViewModel> GetGroupModelAsync(string groupId, string creatorId, IList<EventsAssignViewModel> events);

        Task<GroupDetailsViewModel> GetGroupDetailsModelAsync(string groupId);

        Task AssignEventsToGroupAsync(string groupId, List<string> eventsIds);

        Task AssignStudentsToGroupAsync(string groupId, IList<string> studentsIds);

        Task DeleteAsync(string groupId);

        Task UpdateNameAsync(string groupId, string newName);

        Task DeleteEventFromGroupAsync(string groupId, string eventId);

        Task DeleteStudentFromGroupAsync(string groupId, string studentId);

        Task<IList<EventsAssignViewModel>> FilterEventsThatAreNotAssignedToThisGroup(string qroupId, IList<EventsAssignViewModel> events);

        Task<IList<StudentViewModel>> FilterStudentsThatAreNotAssignedToThisGroup(string qroupId, IList<StudentViewModel> students);
    }
}
