using EF.Core;
using EF.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RecordWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Test();
        }

        private void Test()
        {
            //配置数据库初始化策略
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
            using (var db = new EFDbContext())
            {
                //创建数据库
                db.Database.Create();

                MyUser userModel = new MyUser()
                {
                    UserName = "Daniel",
                    Password = "123456",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IP = "1.1.1.1",
                    Email = "Daniel@163.com",
                    //一个用户，只有一个用户详情
                    UserProfile = new MyUserProfile()
                    {
                        FirstName = "曹",
                        LastName = "操",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IP = "1.2.3.45",
                        Address = "宝安区 深圳 中国",
                    }

                };
                //设置用户示例状态为Added
                db.Entry(userModel).State = System.Data.Entity.EntityState.Added;
                //保存到数据库中
                db.SaveChanges();
            }
        }
    }
}
