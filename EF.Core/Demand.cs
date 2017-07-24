using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    /// <summary>
    /// 需求
    /// </summary>
    public class Demand:BaseEntity
    {
        /// <summary>
        /// 需求名称
        /// </summary>
        public string DName { get; set; }
        /// <summary>
        /// 需求描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public virtual ICollection<Module> Modules { get; set; }
    }
}
