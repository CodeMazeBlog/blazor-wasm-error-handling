using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProducts.Client.HttpRepository
{
	public class ProductHttpRepository : IProductHttpRepository
	{
		private readonly HttpClient _client;
		private NavigationManager _navManager;

		public ProductHttpRepository(HttpClient client, NavigationManager navManager)
		{
			_client = client;
			_navManager = navManager;
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
