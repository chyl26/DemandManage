using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class UserService
    {
        private SqlMapper sqlMapper = null;

        public UserService()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }

        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Create(User user)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertUser", user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return false;
        }
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool VerifyUser(string UserName)
        {
            if (sqlMapper.QueryForObject<User>("SelectUserByUserName", UserName) == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过用户Id获取用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User GetUserById(string userID)
        {
            User user = sqlMapper.QueryForObject<User>("SelectUserById", userID);
            return user;
        }
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public User CheckUser(User user)
        {
            User user1 = sqlMapper.QueryForObject<User>("CheckUser", user);
            return user1;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IList<User> GetUsers()
        {
            IList<User> users = sqlMapper.QueryForList<User>("SelectAllUser", null);
            return users;
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<User> GetUsers(int index, int size)
        {
            IList<User> userList = sqlMapper.QueryForList<User>("SelectAllUser", null, index, size);
            return userList;
        }

        /// <summary>
        /// 用户信息更新
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            int result = sqlMapper.Update("UpdateUser", user);
            return result > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool Delete(string userID)
        {
            int result = sqlMapper.Delete("DeleteUser", userID);
            return result > 0;
        }
    }
}