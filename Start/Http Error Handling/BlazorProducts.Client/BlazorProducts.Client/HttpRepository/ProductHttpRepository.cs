using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProducts.Client.HttpRepository
{
	public class ProductHttpRepository : IProductHttpRepository
	{
		private readonly HttpClient _client;

		public ProductHttpRepository(HttpClient client)
		{
			_client = client;
		}

		public async Task<List<Product>> GetProducts()
		{
			var response = await _client.GetAsync("products");
			var content = await response.Content.ReadAsStringAsync();
			
			var products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			
			return products;
		}
	}
}
