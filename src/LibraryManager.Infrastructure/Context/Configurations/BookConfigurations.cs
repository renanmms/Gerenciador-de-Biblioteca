using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Context.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(b => b.User)
                   .WithMany(b => b.Books)
                   .HasForeignKey(b => b.UserId)
                   .HasPrincipalKey(b => b.Id);
        }
    }
}