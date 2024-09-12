
using Kashkha.BL;
using Kashkha.BL.Managers.CartManager;
using Kashkha.BL.Mapping;
using Kashkha.DAL;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using AutoMapper;
namespace Kashkha.API
{
	public class Program
	{
		public void ConfigureServices(IServiceCollection services)
{
  

    services.AddAutoMapper(typeof(MappingProfile));

  
}
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers().ConfigureApiBehaviorOptions(op=>
			op.SuppressModelStateInvalidFilter=true);
			builder.Services.AddDbContext<KashkhaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KashkhaDb")));
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IProductManager, ProductManager>();
		    builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICartManager, CartManager>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartManager, CartManager>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(option =>
			{
                var connection = builder.Configuration.GetConnectionString("RedisConnection");
				return ConnectionMultiplexer.Connect(connection);
			});

			builder.Services.AddScoped<IReviewManager, ReviewManager>();
			builder.Services.AddScoped<IOrderManager, OrderManager>();

			builder.Services.AddAutoMapper(typeof(MappingProfile));
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
