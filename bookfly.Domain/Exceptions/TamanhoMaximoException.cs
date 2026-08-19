using System;

namespace bookfly.Domain.Exceptions
{
    public class TamanhoMaximoException : DomainException
    {
        
        public TamanhoMaximoException(string atributo, int tamanhoMaximo) 
            : base($"O atributo {atributo} deve ter o tamanho máximo de {tamanhoMaximo} caracteres.") {}
    }
}