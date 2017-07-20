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
    public class ProjectMap:EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            this.HasKey(s => s.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PName).HasMaxLength(100).HasColumnType("varchar2").IsRequired();

            ToTable("PROJECT");

        }
    }
}
