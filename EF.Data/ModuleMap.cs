﻿using EF.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class ModuleMap: EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            //fields  
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           
           
            Property(t => t.ProjectID).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.IP);

            ////配置关系【一个用户有多个订单，外键是CusyomerId】
            //this.HasRequired(s => s.Project).WithMany(s => s.Modules).HasForeignKey(s => s.ProjectID).WillCascadeOnDelete(true);

            ////多对多关系实现要领，hasmany,然后映射生成第三个表，最后映射leftkey,rightkey
            //this.HasMany(s => s.Demands).WithMany(s => s.Modules).Map(s => s.ToTable("ModuleDemand").MapLeftKey("MODULEID").MapRightKey("DEMANDID"));
            //table  
            ToTable("MODULES");
        }
    }
}
