using MOMO.Domain;
using MOMO.Domain.IRepository;
using MOMO.Infrastructure.Autofac;

namespace MOMO.Respository.EFCore.Respository
{
    [DependencyRegister("MOMO.Domain.IRepository.IUserRespository")]
    public class UserRepository:BaseRepository<User>,IUserRespository
	{
    }
}
