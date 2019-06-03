using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Interfaces.Localizations.Exceptions;
using BLL.Services;
using BLL.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ninject;
using System.Text;
using WebApiLayer.Middleware;

namespace WebApiLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        IUnitOfWorkExceptionMessageLocalization UnitOfWorkExceptionMessageLocalization { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IKernel ninjectKernel = new StandardKernel(new InterfacesRegistrationsBLL(Configuration.GetConnectionString("BookshelfDatabase")));
            IUnitOfWorkService unitOfWorkService = ninjectKernel.Get<IUnitOfWorkService>();
            UnitOfWorkExceptionMessageLocalization = ninjectKernel.Get<IUnitOfWorkExceptionMessageLocalization>();
            services.AddScoped<IDataBaseService<AuthorDTO>>(o => new AuthorService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddScoped<IDataBaseService<BookDTO>>(o => new BookService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddScoped<IDataBaseService<GenreDTO>>(o => new GenreService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddScoped<IDataBaseService<TagDTO>>(o => new TagService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddScoped<IReportService>(o => new ReportService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddScoped<IAccountService>(o => new AccountService(unitOfWorkService, UnitOfWorkExceptionMessageLocalization));
            services.AddAutoMapper();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(cfg =>
                    {
                        cfg.RequireHttpsMetadata = false;
                        cfg.SaveToken = true;
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = "me",
                            ValidAudience = "you",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")) //Secret
                        };
                    });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            BLLAutoMapperConfiguration.Configure();
            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwaggerDocumentation();
            app.UseErrorHandlingMiddleware(UnitOfWorkExceptionMessageLocalization);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
