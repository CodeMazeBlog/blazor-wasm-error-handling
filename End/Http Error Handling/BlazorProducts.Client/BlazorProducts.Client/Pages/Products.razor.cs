using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProducts.Client.Pages
{
	public partial class Products : IDisposable
	{
		public List<Product> ProductList { get; set; } = new List<Product>();

		[Inject]
		public IProductHttpRepository ProductRepo { get; set; }

		[Inject]
		public HttpInterceptorService Interceptor { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Interceptor.RegisterEvent();

			ProductList = await ProductRepo.GetProducts();
		}

		public void Dispose() => Interceptor.DisposeEvent();
	}
}
