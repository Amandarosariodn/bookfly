using bookfly.Domain.Livros.Entities;
using FluentNHibernate.Mapping;

namespace bookfly.Infra.Livros.Mappings
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Table("livro");

            Id(livro => livro.Id).Column("id").GeneratedBy.Identity();
            Map(livro => livro.GoogleBooksId).Column("google_books_id").Nullable();
            Map(livro => livro.Titulo).Column("titulo").Not.Nullable();
            Map(livro => livro.Autor).Column("autor").Nullable();
            Map(livro => livro.Sinopse).Column("sinopse").Nullable();
            Map(livro => livro.TotalPaginas).Column("total_paginas").Nullable();
            Map(livro => livro.DataLancamento).Column("data_lancamento").CustomType<DateTime>().Nullable();
            Map(livro => livro.UrlImagem).Column("url_imagem").Nullable();
            Map(livro => livro.Situacao).Column("situacao").CustomType<bool>().Not.Nullable();
            References(livro => livro.CategoriaId).Column("categoria_id").Not.Nullable();
        }
    }
}
