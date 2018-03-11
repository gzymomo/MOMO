using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MOMO.Domain;
using MOMO.Domain.IRepository;

namespace MOMO.Respository.EFCore
{
	public class BaseRepository<T> : IRepository<T> where T : Entity
	{
		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public void BatchAdd(T[] entities)
		{
			throw new NotImplementedException();
		}

		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Expression<Func<T, bool>> exp)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> Find(int pageindex = 1, int pagesize = 10, string orderby = "", Expression<Func<T, bool>> exp = null)
		{
			throw new NotImplementedException();
		}

		public T FindSingle(Expression<Func<T, bool>> exp = null)
		{
			throw new NotImplementedException();
		}

		public int GetCount(Expression<Func<T, bool>> exp = null)
		{
			throw new NotImplementedException();
		}

		public bool IsExist(Expression<Func<T, bool>> exp)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Expression<Func<T, object>> identityExp, T entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
		{
			throw new NotImplementedException();
		}
	}
}
