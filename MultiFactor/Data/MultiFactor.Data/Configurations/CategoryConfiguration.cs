namespace MultiFactor.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MultiFactor.Data.Models;

    using MultiFactor.Data.Validations;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasMany(c => c.Quizzes)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.CategoryId);

            category.Property(c => c.Name)
                .HasMaxLength(DataValidation.Category.NameMaxLength)
                .IsRequired();
        }
    }
}
