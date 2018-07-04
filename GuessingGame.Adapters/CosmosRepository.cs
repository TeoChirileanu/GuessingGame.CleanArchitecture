using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace GuessingGame.Adapters {
    public static class CosmosRepository<T> where T : class {
        private const string Endpoint = "https://localhost:8081/";

        private const string Key =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private const string DatabaseId = "GuessingGame";
        private const string CollectionId = "Logs";
        private static DocumentClient _client;

        public static async Task<IEnumerable<T>> GetLogs() {
            var query = _client.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                    new FeedOptions {MaxItemCount = -1})
                .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults) results.AddRange(await query.ExecuteNextAsync<T>());

            return results;
        }

        public static async Task StoreLog(T item) {
            var resourceResponse = await _client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
            Console.WriteLine(resourceResponse.Resource);
        }

        public static async Task DeleteLogs() {
            await _client.DeleteDocumentCollectionAsync(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
        }

        public static void Initialize() {
            _client = new DocumentClient(new Uri(Endpoint), Key,
                new ConnectionPolicy {EnableEndpointDiscovery = false});
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        private static async Task CreateDatabaseIfNotExistsAsync() {
            try {
                await _client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e) {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    await _client.CreateDatabaseAsync(new Database {Id = DatabaseId});
                else
                    throw;
            }
        }

        private static async Task CreateCollectionIfNotExistsAsync() {
            try {
                await _client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e) {
                if (e.StatusCode == HttpStatusCode.NotFound)
                    await _client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection {Id = CollectionId},
                        new RequestOptions {OfferThroughput = 1000});
                else
                    throw;
            }
        }
    }
}