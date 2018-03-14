using System;
using MOMO.Domain;
using MOMO.Domain.IRepository;

namespace MOMO.Respository.EFCore
{
    public class UserRepository:BaseRepository<User>,IUserRespository
	{
    }
}
