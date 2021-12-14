using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrTaabodi.Data.DatabaseContext;
using DrTaabodi.Services.PostCategoryTable;
using DrTaabodi.Services.PostTable;
using DrTaabodi.Services.PostTypeTable;
using DrTaabodi.Services.QnATable;
using DrTaabodi.Services.UserTable;
using DrTaabodi.Services.WebsiteOptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DrTaabodi.WebApi;

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
        services.AddDbContext<DrTaabodiDbContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("DrNullConnttion")));

        services.AddControllers()
            .AddJsonOptions(ops =>
            {
                ops.JsonSerializerOptions.IgnoreNullValues = true;
                ops.JsonSerializerOptions.WriteIndented = true;
                ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddControllers().AddNewtonsoftJson(s =>
        {
            s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            s.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
        //Some comment about automapper and api
        services.AddControllers();
        services.AddScoped<IUser, SqlUser>();
        services.AddScoped<IPost, SqlPost>();
        services.AddScoped<IQnA, SqlQna>();
        services.AddScoped<IPostCategory, SqlPostCategory>();
        services.AddScoped<IPostType, SqlPostType>();
        services.AddScoped<IOptions, SqlOptions>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "DrTaabodi", Version = "v1"}); });
        services.AddControllersWithViews();

        services.AddMvc(p => p.EnableEndpointRouting = false);


        services.AddCors(x =>
        {
            x.AddPolicy("localhostVude",
                b =>
                {
                    b.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DrTaabodiDbContext db)
    {
        //db.Database.EnsureCreated();


        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DrTaabodi.WebApi v1"));
        }

        app.UseCors("localhostVude");
        app.UseStaticFiles();
        app.Map("/management",
            config =>
            {
                config.Run(async h =>
                {
                    await h.Response.SendFileAsync(Path.Combine(env.WebRootPath, "management/index.html"));
                });
            });


        app.UseHttpsRedirection();
        //This is comment about routing
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapControllerRoute(
                "web-controllers",
                "{controller=Home}/{action=Index}/{id?}",
                new {Namespace = "DrTaabodi.WebControllers"}
            );
        });
        app.UseRouting();
    }
}
