using System;

namespace bookfly.Domain.Exceptions
{
    public class TamanhoInvalidoException : DomainException
    {
        public TamanhoInvalidoException(string atributo, int tamanhoMinimo, int tamanhoMaximo) 
            : base($"O atributo {atributo} deve ter entre {tamanhoMinimo} e {tamanhoMaximo} caracteres.") {}

    }
}