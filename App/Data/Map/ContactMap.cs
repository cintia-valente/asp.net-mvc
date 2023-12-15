using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace App.Data.Map
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            //builder.HasKey(x => x.Id);
            // builder.HasOne<UserModel>(x => x.User).WithMany().HasForeignKey(x => x.IdUser);
            builder.HasOne(c => c.User)                 // Navigation property on ContactModel entity
             .WithMany(u => u.Contacts)           // Navigation property on UserModel entity
             .HasForeignKey(c => c.UserId)   // Foreign key property (column) on ContactModel entity
             .IsRequired();                       // Optional: Ensure the foreign key is required
        }
    }
}
