using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuestionaryApp.Application.Mapper;
using QuestionaryApp.Application.Repository;
using QuestionaryApp.Application.Services.Abstract;
using QuestionaryApp.Application.Services.Concrete;
using QuestionaryApp.Infrastructure.Data.Context;
using QuestionaryApp.Infrastructure.Data.Query;
using System.IO;

namespace QuestionaryApp.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuestionaryApp.Presentation.API", Version = "v1" });
                
            });


            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddAutoMapper(typeof(ChoicesMap).Assembly);


            services.AddDbContext<QuestionaryAppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuestionaryApp.Presentation.API v1"));
            }
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x=>x.AllowAnyOrigin()
                        .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
