using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class DemandMap: EntityTypeConfiguration<Demand>
    {
        public DemandMap()
        {
            //配置主键
            this.HasKey(s => s.ID);

           
            this.Property(s => s.DName).IsRequired().HasColumnType("varchar2").HasMaxLength(25);
            this.Property(s => s.Description).IsRequired().HasColumnType("varchar2").HasMaxLength(25);
          

            //配置表
            this.ToTable("DEMAND");
        }
    }
}
