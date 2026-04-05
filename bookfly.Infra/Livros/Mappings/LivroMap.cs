using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookfly.Domain.Enums;
using bookfly.Domain.Livros.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Livros.Mappings
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Table("livro");

            Id(livro => livro.Id).Column("ID").GeneratedBy.Identity();
            Map(livro => livro.GoogleBooksId).Column("google_books_id").Nullable();
            Map(livro => livro.Titulo).Column("titulo").Nullable();
            Map(livro => livro.Autor).Column("autor").Nullable();
            Map(livro => livro.Sinopse).Column("sinopse").Nullable();
            Map(livro => livro.TotalPaginas).Column("total_paginas").Nullable();
            Map(livro => livro.DataLancamento).Column("data_lancamento").Nullable();
            Map(livro => livro.UrlImagem).Column("url_imagem").Nullable();
            Map(livro => livro.Situacao).Column("ativo_inativo").CustomType<AtivoInativoEnum>().Nullable();
            Map(livro => livro.CategoriaId).Column("categoria_id").Nullable();
            
            //  References(x => x.CategoriaId)
            //     .Column("categoria_id")
            //     .Nullable();
    }}
}