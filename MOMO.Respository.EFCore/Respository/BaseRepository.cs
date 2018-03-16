using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MOMO.Domain;
using MOMO.Domain.IRepository;
using MOMO.Respository.EFCore.Context;

namespace MOMO.Respository.EFCore
{
	public class BaseRepository<T> : IRepository<T> where T : Entity
	{
	    protected DbSet<T> dbSet;

	    public BaseRepository(MoMoDbMsSqlContext context)
	    {
	        dbSet = context.Set<T>();
        }

	    public void Add(T entity)
	    {
	        dbSet.Add(entity);
	    }

		public void BatchAdd(T[] entities)
		{
		    dbSet.AddRange(entities);
        }

		public void Delete(T entity)
		{
		    dbSet.Remove(entity);

		}

		public void Delete(Expression<Func<T, bool>> exp)
		{
		    var toDele = dbSet.Where(exp).ToList();
            dbSet.RemoveRange(toDele);

        }

		public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
		{
		   return dbSet.Where(exp);
        }

		public IQueryable<T> Find(int pageindex = 1, int pagesize = 10, Expression<Func<T, object>> orderBy= null, Expression<Func<T, bool>> exp = null)
		{
		    return dbSet.Where(exp).OrderBy(orderBy).Skip((pageindex - 1) * pagesize).Take(pagesize);
		}

		public T FindSingle(Expression<Func<T, bool>> exp = null)
		{
		    return dbSet.FirstOrDefault(exp);
		}

		public int GetCount(Expression<Func<T, bool>> exp = null)
		{
		    return dbSet.Count(exp);
		}

		public bool IsExist(Expression<Func<T, bool>> exp)
		{
		    return dbSet.Any(exp);
		}

		public void Save()
		{

        }

		public void Update(T entity)
		{
		    dbSet.Update(entity);

		}

		public void Update(Expression<Func<T, object>> identityExp, T entity)
		{
		    
        }

		public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
		{

        }
	}
}
