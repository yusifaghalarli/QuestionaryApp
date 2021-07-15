using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionaryApp.Core.Domain;


namespace QuestionaryApp.Infrastructure.Data.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasMany(x => x.Choices).WithOne().HasForeignKey(x => x.QuestionId);
        }
    }
}
