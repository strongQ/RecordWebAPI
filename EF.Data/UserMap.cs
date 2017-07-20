using EF.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //配置主键
            this.HasKey(s => s.ID);

            //给ID配置自动增长
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.UserName).IsRequired().HasColumnType("varchar2").HasMaxLength(25);
            this.Property(s => s.Email).IsRequired().HasColumnType("varchar2").HasMaxLength(25);
            this.Property(s => s.AddedDate);
            this.Property(s => s.ModifiedDate);
            this.Property(s => s.IP).HasColumnType("varchar2").HasMaxLength(25);

            //配置表
            this.ToTable("USER");
        }
    }
}
