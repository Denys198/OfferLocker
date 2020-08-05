using System.Text;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OfferLocker.API.Extensions;
using OfferLocker.Business.Categories;
using OfferLocker.Business.Categories.Services.Implementations;
using OfferLocker.Business.Categories.Services.Interfaces;
using OfferLocker.Business.Identity;
using OfferLocker.Business.Identity.Models;
using OfferLocker.Business.Identity.Services.Implementations;
using OfferLocker.Business.Identity.Services.Interfaces;
using OfferLocker.Business.Identity.Validators;
using OfferLocker.Business.Meetups;
using OfferLocker.Business.Meetups.Services.Implementations;
using OfferLocker.Business.Meetups.Services.Interfaces;
using OfferLocker.Business.Offers;
using OfferLocker.Business.Offers.Services.Implementations;
using OfferLocker.Business.Offers.Services.Interfaces;
using OfferLocker.Persistence;
using OfferLocker.Persistence.Commons;
using OfferLocker.Persistence.Categories;
using OfferLocker.Persistence.Identity;
using OfferLocker.Persistence.Meetups;
using OfferLocker.Persistence.Offers;

namespace OfferLocker.API
{
	public sealed class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();

			services
				.AddScoped<IOffersService, OffersService>()
				.AddScoped<IOfferCommentsService, OfferCommentsService>()
				.AddScoped<IPhotosService, PhotosService>()
				.AddScoped<ICategoriesService, CategoriesService>()
				.AddScoped<IMeetupsService, MeetupsService>()
				.AddScoped<IFollowService, FollowService>()
				.AddScoped<IPasswordHasher, PasswordHasher>()
				.AddScoped<IAuthenticationService, AuthenticationService>();

			AddAuthentication(services);

			services
				.AddDbContext<OffersContext>(config =>
					config.UseSqlServer(Configuration.GetConnectionString("OffersConnection")))
				.AddScoped<IOffersRepository, OffersRepository>()
				.AddScoped<IMeetupsRepository,MeetupsRepository>()
				.AddScoped<IUserRepository, UserRepository>()
				.AddScoped<IFollowRepository, FollowRepository>();
				.AddScoped<ICategoriesRepository, CategoriesRepository>()

			services
				.AddAutoMapper(c =>
				{
					c.AddProfile<OffersMappingProfile>();
					c.AddProfile<MeetupsMappingProfile>();
					c.AddProfile<CategoriesMappingProfile>();
					c.AddProfile<IdentityMappingProfile>();
				}, typeof(OffersService))
				.AddHttpContextAccessor()
				.AddSwagger()
				.AddControllers()
				.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services
				.AddMvc()
				.AddFluentValidation();

			services.AddTransient<IValidator<UserRegisterModel>, UserRegisterModelValidator>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app
				.UseSwagger()
				.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Offers API"));

			app
				.UseHttpsRedirection()
				.UseRouting()
				.UseCors(options => options
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader())
				.UseAuthentication()
				.UseAuthorization()
				.UseEndpoints(endpoints => endpoints.MapControllers());
		}

		private void AddAuthentication(IServiceCollection services)
		{
			var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
			services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = true;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidIssuer = jwtOptions.Issuer,
						ValidAudience = jwtOptions.Audience
					};
				});
		}
	}
}
