using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleERP.Infrastructure.Models
{
    public interface IConcurrencyEntity
    {
        byte[] Tstamp { get; set; }
    }
}