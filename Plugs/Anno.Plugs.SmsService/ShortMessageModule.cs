using Anno.EngineData;
using Anno.Plugs.SmsService.Dto;
using Anno.Plugs.SmsService.DyRepositories;
using Anno.Plugs.SmsService.Entities;
using Anno.Plugs.SmsService.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 命名空间需要和程序集名称一致（为了自动扫描功能插件）
/// 命名规范Anno.Plugs.XXXService
/// </summary>
namespace Anno.Plugs.SmsService
{
    /// <summary>
    /// 模块结尾需为Module 且集成 BaseModule
    /// </summary>
    public class ShortMessageModule : BaseModule
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public ShortMessageModule(IUserRepository userRepository
            , UserService userService)
        {

            _userRepository = userRepository;
            _userService = userService;
        }

        // GET api/values
        public long AddWithTranWrap(User user)
        {
            var id = _userService.AddWithTranWrap(user);
            return id;
        }

        public long AddWithTran(User user)
        {
            var id = _userService.AddWithTran(user);
            return id;
        }
        public User GetById(long id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }
        public int UpdateTrack(long id)
        {
            var user = _userRepository.GetById(id);
            user.UserName = "Updated";
            return _userRepository.Update(user);
        }
        public int Update(User user)
        {
            return _userRepository.Update(user);
        }

        public  GetByPageResponse<User> GetByPage(int pageIndex = 1)
        {
            return _userRepository.GetByPage<GetByPageResponse<User>>(new
            {
                PageSize = 10,
                PageIndex = pageIndex
            }).Result;
        }

        public IEnumerable<User> Query(int taken = 10)
        {
            return _userRepository.Query(taken);
        }

        public  IEnumerable<User> QueryAsync(int taken = 10)
        {
            return _userRepository.QueryAsync(taken).Result;
        }
        public void Mt(int id)
        {
            try
            {
                _userRepository.SqlMapper.BeginTransaction();
                _userRepository.InsertAsync(new User
                {
                    Id = id,
                    UserName = "SmartSql"
                }).Wait();
                var task1 = _userRepository.QueryAsync(10);
                var task2 = _userRepository.QueryAsync(10);
                Task.WhenAll(task1, task2).Wait();
                _userRepository.SqlMapper.CommitTransaction();
            }
            catch (Exception e)
            {
                _userRepository.SqlMapper.RollbackTransaction();
                throw;
            }
        }

    }
}
