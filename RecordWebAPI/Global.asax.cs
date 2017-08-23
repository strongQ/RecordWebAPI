using EF.Core;
using EF.Data;
using System;
using System.Web.Http;


namespace RecordWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
           // Test();
        }
        
        private void Test()
        {
           
            using (var db = new EFDbContext())
            {
              

                MyUser userModel = new MyUser()
                {
                    UserName = "zhanqqi",
                    Password = "1",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IP = "1.1.1.1",
                    Email = "Daniel@163.com",
                    //一个用户，只有一个用户详情
                    UserProfile = new MyUserProfile()
                    {
                        FirstName = "张",
                        LastName = "奇",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IP = "1.2.3.45",
                        Address = "中国荆门",
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
