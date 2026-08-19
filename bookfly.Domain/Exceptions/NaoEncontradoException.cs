using System;

namespace bookfly.Domain.Exceptions
{
    public class NaoEncontradoException : DomainException
    {
        public NaoEncontradoException(string entidade) : base($"{entidade} não encontrado(a).") {}
    }
}