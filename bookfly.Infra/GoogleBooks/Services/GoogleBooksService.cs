using System.Text.Json;
using bookfly.Application.Livros.DataTransfer.Responses;
using bookfly.Domain.GoogleBooks.Entities;
using bookfly.Domain.GoogleBooks.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace bookfly.Infra.GoogleBooks.Services
{
    public class GoogleBooksService : IGoogleBooksService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IConfiguration _configuration;

        public GoogleBooksService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _apiKey = _configuration["GoogleBooks:ApiKey"];
        }

        public async Task<Item?> BuscarPorIdAsync(
            string googleBooksId,
            CancellationToken cancellationToken)
        {
            var url =
                $"https://www.googleapis.com/books/v1/volumes/{googleBooksId}?key={_apiKey}";

            var response =
                await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            var json =
                await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<Item>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<List<Item>> BuscarPorTituloAsync(
            string titulo,
            CancellationToken cancellationToken)
        {
            var url =
                $"https://www.googleapis.com/books/v1/volumes?q={titulo}&key={_apiKey}";

            var response =
                await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return [];

            var json =
                await response.Content.ReadAsStringAsync(cancellationToken);

            var resultado =
                JsonSerializer.Deserialize<GoogleBooksResponse>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return resultado?.Items ?? [];
        }
    }
}