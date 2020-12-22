using Anno.Plugs.SmsService.DyRepositories;
using Anno.Plugs.SmsService.Entities;
using SmartSql.AOP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.SmsService.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Transaction]
        public virtual long AddWithTranWrap(User user)
        {
            return AddWithTran(user);
        }
        [Transaction]
        public virtual long AddWithTran(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}
