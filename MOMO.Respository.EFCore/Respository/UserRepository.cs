using MOMO.Domain;
using MOMO.Domain.IRepository;
using MOMO.Infrastructure.Autofac;
using MOMO.Respository.EFCore.Context;

namespace MOMO.Respository.EFCore.Respository
{
    [DependencyRegister(typeof(IUserRespository))]
    public class UserRepository:BaseRepository<User>,IUserRespository
	{
	    public UserRepository(MoMoDbMsSqlContext context) : base(context)
	    {
	    }
	}
}
