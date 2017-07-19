using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class UserProfileMap: EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            this.HasKey(s => s.ID);

            this.Property(s => s.FirstName).IsRequired();
            this.Property(s => s.LastName).IsRequired();
            this.Property(s => s.Address).HasMaxLength(100).HasColumnType("nvarchar2").IsRequired();
            this.Property(s => s.PhoneNumber);
            this.Property(s => s.AddedDate);
            this.Property(s => s.ModifiedDate);
            this.Property(s => s.IP);

            //配置关系[一个用户只能有一个用户详情！！！]
            this.HasRequired(s => s.User).WithRequiredDependent(s => s.UserProfile);

            this.ToTable("USERPROFILE");

        }
    }
}
