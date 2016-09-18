using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleERP.Infrastructure.Models
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; protected set; }

        public virtual byte[] Tstamp { get; set; }
    }
}