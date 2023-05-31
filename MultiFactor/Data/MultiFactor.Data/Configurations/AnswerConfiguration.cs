namespace MultiFactor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MultiFactor.Data.Models;

    using MultiFactor.Data.Validations;

    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> answer)
        {
            answer.Property(a => a.Text)
                .HasMaxLength(DataValidation.Answer.TextMaxLength)
                .IsRequired();

            answer.Property(a => a.IsRightAnswer)
                .HasDefaultValue(false);
        }
    }
}
