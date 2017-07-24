using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    /// <summary>
    /// 模块
    /// </summary>
    public class Module:BaseEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string MName { get; set; }

        /// <summary>
        /// 导航属性--项目
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// 需求
        /// </summary>
        public virtual ICollection<Demand> Demands { get; set; }
    }
}
