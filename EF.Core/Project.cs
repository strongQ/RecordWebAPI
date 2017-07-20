using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    /// <summary>
    /// 项目
    /// </summary>
    public class Project:BaseEntity
    {
       
        /// <summary>
        /// 项目名称
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 导航属性--Module
        /// </summary>
        public virtual ICollection<Module> Modules { get; set; }
    }
}
