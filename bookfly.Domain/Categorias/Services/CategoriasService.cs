

// using bookfly.Domain.Categorias.Commands;
// using bookfly.Domain.Categorias.Entities;
// using bookfly.Domain.Categorias.Repositories;
// using bookfly.Domain.Categorias.Services.Interfaces;
// using bookfly.Domain.Enums;

// namespace bookfly.Domain.Categorias.Services
// {
//     public class CategoriasService(ICategoriasRepository categoriaRepository) : ICategoriasService
//     {
//         public async Task<Categoria> EditarCategoriaAsync(EditarCategoriaCommand comando, CancellationToken cancellationToken)
//         {
//             Categoria categoria = await ValidarAsync(id, cancellationToken);

//             categoria.SetNome(comando.Nome);
//             categoria.SetDescricao(comando.Descricao);
//             categoria.SetUrlImagem(comando.UrlImagem);

//         //editar tbem
//             await categoriaRepository.EditarAsync(categoria, cancellationToken);
//             return categoria;
//         }

//         public async Task<Categoria> InserirCategoriaAsync(InserirCategoriaCommand comando, CancellationToken cancellationToken)
//         {
//             Categoria categoria = Instanciar(comando);


//             //fazer metodo de inserir async no repositorio
//             await categoriaRepository.InserirAsync(categoria, cancellationToken);
//             return categoria;

//         }

//         public Categoria Instanciar(InserirCategoriaCommand comando)
//         {
//             return new Categoria(comando.Nome, comando.Descricao, comando.UrlImagem);
//         }

//         public async Task MudarSituacaoAsync(int id, CancellationToken cancellationToken)
//         {
//             Categoria categoria = await ValidarAsync(id, cancellationToken);

//             switch (categoria.Situacao)
//             {
//                 case AtivoInativoEnum.Ativo:
//                     categoria.SetSituacao(AtivoInativoEnum.Inativo);
//                     break;
//                 case AtivoInativoEnum.Inativo:
//                     categoria.SetSituacao(AtivoInativoEnum.Ativo);
//                     break;
//             }

//             //fazer editar tambem
//             await categoriaRepository.EditarAsync(categoria, cancellationToken);
//         }

//         public async Task<Categoria> ValidarAsync(int id, CancellationToken cancellationToken)
//         {
//             //recuperar tbm rsrs
//             Categoria categoria = await categoriaRepository.RecuperarAsync(id, cancellationToken);

//             if (categoria == null)
//                 throw new Exception("Categoria não encontrado");

//             return categoria;
//         }
//     }
// }