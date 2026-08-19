using System;

namespace bookfly.Domain.Exceptions
{
    public class TamanhoMinimoException : DomainException
    {
        public TamanhoMinimoException(string atributo, int tamanhoMinimo) 
            : base($"O atributo {atributo} deve ter o tamanho mínimo de {tamanhoMinimo} caracter(es).") {}
    }
}