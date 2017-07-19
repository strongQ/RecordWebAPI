using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 导航属性--用户详情
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }
    }
}
