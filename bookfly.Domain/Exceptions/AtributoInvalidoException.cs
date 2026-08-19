using System;

namespace bookfly.Domain.Exceptions
{
    public class AtributoInvalidoException : DomainException
    {
        public AtributoInvalidoException(string atributo) : base($"O atributo {atributo} é inválido(a).") {}

        public AtributoInvalidoException(string atributo, string motivo) : base($"O atributo {atributo} é inválido(a): {motivo}") {}
    }
}