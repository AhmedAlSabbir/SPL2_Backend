using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using JWTApi.Helpers;
using JWTApi.Data;

namespace JWTApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();


            services.AddDbContext<DataContext>
           (x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            // services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnention")));
            // services.AddControllers().AddNewtonsoftJson();
            // services.AddMvc();
            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                });


            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            // services.AddScoped<IUserservice, UserService>();
            services.AddScoped<IUserservice, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseRouting();

            // // global cors policy
            // app.UseCors(x => x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader());

            // app.UseAuthentication();
            // app.UseAuthorization();

            // app.UseEndpoints(endpoints => {
            //     endpoints.MapControllers();
            // });

            // if(env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            // app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            // app.UseMvc();

            app.UseCors(buielder =>
            {
                buielder.WithOrigins("http://localhost:4200");
                buielder.AllowAnyMethod();
                buielder.AllowAnyHeader();
            });
            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
