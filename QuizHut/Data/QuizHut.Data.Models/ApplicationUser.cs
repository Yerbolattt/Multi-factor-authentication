﻿// ReSharper disable VirtualMemberCallInConstructor

namespace QuizHut.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using QuizHut.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.ParticipantInGroups = new HashSet<ParticipantGroup>();
            this.Participants = new HashSet<ApplicationUser>();
            this.CreatedQuizzes = new HashSet<Quiz>();
            this.CreatedGroups = new HashSet<Group>();
            this.QuizResults = new HashSet<QuizResult>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string ManagerId { get; set; }

        public virtual ApplicationUser Manager { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<ParticipantGroup> ParticipantInGroups { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }

        public virtual ICollection<Quiz> CreatedQuizzes { get; set; }

        public virtual ICollection<QuizResult> QuizResults { get; set; }

        public virtual ICollection<Group> CreatedGroups { get; set; }
    }
}
