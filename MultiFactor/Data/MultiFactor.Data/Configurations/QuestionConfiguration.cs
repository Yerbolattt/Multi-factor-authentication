namespace MultiFactor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MultiFactor.Data.Models;

    using MultiFactor.Data.Validations;

    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> question)
        {
            question.HasMany(q => q.Answers)
                .WithOne(q => q.Question)
                .HasForeignKey(q => q.QuestionId);

            question.Property(q => q.Text)
                .HasMaxLength(DataValidation.Question.TextMaxLength)
                .IsRequired();
        }
    }
}
