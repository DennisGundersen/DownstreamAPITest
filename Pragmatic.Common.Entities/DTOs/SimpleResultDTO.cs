using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pragmatic.Common.Entities.DTOs
{
    public class SimpleResultDTO<T>
    {
        public T Result { get; set; }
    }
}
