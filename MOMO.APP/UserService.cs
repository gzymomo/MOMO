using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Lifestyle.Pool;
using MOMO.Domain;
using MOMO.Domain.IRepository;
using MOMO.Infrastructure.Autofac;
using MOMO.Respository.EFCore;

namespace MOMO.APP
{
    [DependencyRegister]
    public class UserService
    {
        protected IUserRespository _userRespository;

        public UserService(IUserRespository userRespository)
        {
            _userRespository = userRespository;
        }

        public IList<User> GetUserList()
        {
            return _userRespository.Find(null).ToList();
        }
    }
}
