﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using SimpleERP.Infrastructure.Models;

namespace SimpleERP.Infrastructure.Data
{
    public interface IRepository<T>
		where T : BaseEntity
    {
        IQueryable<T> Query();

        void Add(T entity);

        IDbContextTransaction BeginTransaction();

        void SaveChange();

        void Remove(T entity);
    }
}