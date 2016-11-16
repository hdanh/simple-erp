using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleERP.Infrastructure.Models
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<T> : BaseEntity, IEntity<T>, IAuditableEntity, IConcurrencyEntity
	{
        public virtual T Id { get; protected set; }

		#region Auditable Fields

		public virtual DateTime CreatedDate { get; set; }

		public virtual string CreatedBy { get; set; }

		public virtual DateTime UpdatedDate { get; set; }

		public virtual string UpdatedBy { get; set; }

		#endregion

		#region Concurrency Fields
		public virtual byte[] Tstamp { get; set; }

		#endregion
	}
}