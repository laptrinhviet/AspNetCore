using Microsoft.Extensions.DependencyInjection;
using AspNetCore.Services.Content.Contacts;
using AspNetCore.Services.Content.Feedbacks;
using AspNetCore.Services.Content.Pages;
using AspNetCore.Services.Content.Posts;
using AspNetCore.Services.Content.Slides;
//using AspNetCore.Services.Dapper.Reports;
using AspNetCore.Services.ECommerce.Bills;
using AspNetCore.Services.ECommerce.ProductCategories;
using AspNetCore.Services.ECommerce.Products;
//using AspNetCore.Services.Systems.Commons;
using AspNetCore.Services.Systems.Functions;
using AspNetCore.Services.Systems.Roles;
using AspNetCore.Services.Systems.Users;

namespace AspNetCore
{
    public static class ServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            //services.AddTransient<IPostService, PostService>();
            //services.AddTransient<ICommonService, CommonService>();
            //services.AddTransient<IPageService, PageService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<IBillService, BillService>();
            //services.AddTransient<ISlideService, SlideService>();
            //services.AddTransient<IPageService, PageService>();
            //services.AddTransient<IContactService, ContactService>();
            //services.AddTransient<IFeedbackService, FeedbackService>();
            //services.AddTransient<IReportService, ReportService>();
        }
    }
}