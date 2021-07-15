using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuestionaryApp.Core.Domain;


namespace QuestionaryApp.Infrastructure.Data.Mappings
{
    class ChoiceMap : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {

        }
    }
}
