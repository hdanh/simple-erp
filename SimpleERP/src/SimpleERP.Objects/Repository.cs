using SimpleERP.Infrastructure.Data;
using SimpleERP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace SimpleERP.Objects
{
	public class Repository<T> : IRepository<T>
		where T : BaseEntity
	{
		
		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public IDbContextTransaction BeginTransaction()
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> Query()
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		public void SaveChange()
		{
			throw new NotImplementedException();
		}
	}
}
