using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
//using PaulMiami.AspNetCore.Mvc.Recaptcha;
using AspNetCore.Services.Content.Posts;
using AspNetCore.Services.Content.Contacts;
using AspNetCore.Services.Content.Feedbacks;
using AspNetCore.Services.Content.Pages;
using AspNetCore.Services.Content.Slides;
using AspNetCore.Services.ECommerce.Bills;
using AspNetCore.Services.ECommerce.ProductCategories;
using AspNetCore.Services.ECommerce.Products;
//using AspNetCore.Services.Systems.Commons;
using AspNetCore.Services.Systems.Functions;
using AspNetCore.Services.Systems.Roles;
using AspNetCore.Services.Systems.Users;
using AspNetCore.Data.EF;
using AspNetCore.Data.Entities;
using AutoMapper;
using AspNetCore.Infrastructure.Interfaces;
using AspNetCore.Extensions;
using AspNetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AspNetCore.Helpers;

namespace AspNetCore
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
            // 
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("AspNetCore.Data.EF")));

            //  Add Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc();

            // SwaggerGen
            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "TEDU Project",
            //        Description = "TEDU API Swagger surface",
            //        Contact = new Contact { Name = "ToanBN", Email = "tedu.international@gmail.com", Url = "http://www.tedu.com.vn" },
            //        License = new License { Name = "MIT", Url = "https://github.com/teduinternational/teducoreapp" }
            //    });
            //});

            // Policy
            //services.AddCors(o => o.AddPolicy("TeduCorsPolicy", builder =>
            //{
            //    builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader();
            //}));

            ////Config authen
            //services.AddAuthentication(o =>
            //{
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(cfg =>
            //{
            //    cfg.RequireHttpsMetadata = false;
            //    cfg.SaveToken = true;

            //    cfg.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = Configuration["Tokens:Issuer"],
            //        ValidAudience = Configuration["Tokens:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
            //    };
            //});

            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromHours(2);
            //    options.Cookie.HttpOnly = true;
            //});

            // Authentication FB, Google
            //services.AddAuthentication()
            //    .AddFacebook(facebookOptions =>
            //    {
            //        facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //        facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //    }).AddGoogle(googleOptions =>
            //    {
            //        googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
            //        googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    });
            //services.AddMinResponse();

            //services.ConfigureApplicationCookie(options => options.LoginPath = "/dang-nhap.html");
            
            services.AddAutoMapper();

            // Add application services.
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            //Register for DI
            services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<DbInitializer>();
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            //
            services.AddMvc()
               .AddViewLocalization()
               .AddDataAnnotationsLocalization()
               .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //services.AddTransient<IViewRenderService, ViewRenderService>();          

            //services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();


            //services.AddImageResizer();
            //services.AddRecaptcha(new RecaptchaOptions
            //{
            //    SiteKey = Configuration["Recaptcha:SiteKey"],
            //    SecretKey = Configuration["Recaptcha:SecretKey"]
            //});         

            //services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();


            //Register for service
            ServiceRegister.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/logs-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseCors("TeduCorsPolicy");
            app.UseAuthentication();
            //app.UseSwagger();
            app.UseStaticFiles();
            //app.UseSwaggerUI(s =>
            //{
            //    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API v1.1");
            //});


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });

        }
    }
}
