using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllBizz.Core.Entities;

namespace AllBizz.Data.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.FullName)
                    .IsRequired()
                    .HasMaxLength(50);
            
            builder.Property(x => x.InstaUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            
            builder.Property(x => x.TwitUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.FaceUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.HasOne(x => x.Profession).WithMany(p => p.Members);

        }
    }
}
