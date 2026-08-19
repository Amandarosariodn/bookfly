using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookfly.Domain.Exceptions
{
    public class RegraDeNegocioException : DomainException
    {
        public RegraDeNegocioException(string regra) : base($"{regra}") {}
    }
}