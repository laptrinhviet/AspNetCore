using AutoMapper;
using AspNetCore.Services.Content.Contacts.Dtos;
using AspNetCore.Services.Content.Feedbacks.Dtos;
using AspNetCore.Services.Content.Pages.Dtos;
using AspNetCore.Services.Content.PostCategories.Dtos;
using AspNetCore.Services.Content.Posts.Dtos;
using AspNetCore.Services.Content.Slides.Dtos;
using AspNetCore.Services.Dtos;
using AspNetCore.Services.ECommerce.Bills.Dtos;
using AspNetCore.Services.ECommerce.ProductCategories.Dtos;
using AspNetCore.Services.ECommerce.Products.Dtos;
using AspNetCore.Services.Systems.Announcements.Dtos;
//using AspNetCore.Services.Systems.AuditLogs;
//using AspNetCore.Services.Systems.Commons;
using AspNetCore.Services.Systems.Permissions;
using AspNetCore.Services.Systems.Functions.Dtos;
using AspNetCore.Services.Systems.Roles.Dtos;
using AspNetCore.Services.Systems.Settings.Dtos;
using AspNetCore.Services.Systems.Users.Dtos;
using AspNetCore.Data.Entities;
using AspNetCore.Services.Systems.Permissions.Dtos;
using AspNetCore.Services.Advs.Dtos;
using AspNetCore.Services.Content.Footers.Dtos;

namespace AspNetCore.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<AppRole, AppRoleViewModel>().MaxDepth(2);
            CreateMap<AppUser, AppUserViewModel>().MaxDepth(2);
            CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);
            CreateMap<Product, ProductViewModel>().MaxDepth(2);
            CreateMap<PostCategory, PostCategoryViewModel>().MaxDepth(2);
            CreateMap<Post, PostViewModel>().MaxDepth(2);
            CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);
            CreateMap<ProductQuantity, ProductQuantityViewModel>().MaxDepth(2);
            CreateMap<ProductWishlist, ProductWishlistViewModel>().MaxDepth(2);
            CreateMap<ProductTag, ProductTagViewModel>().MaxDepth(2);
            CreateMap<PostTag, PostTagViewModel>().MaxDepth(2);
            CreateMap<Tag, TagViewModel>().MaxDepth(2);
            CreateMap<Function, MenuViewModel>().MaxDepth(2);
            CreateMap<Permission, PermissionViewModel>().MaxDepth(2);
            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<Page, PageViewModel>().MaxDepth(2);
            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<Bill, BillViewModel>().MaxDepth(1);
            CreateMap<BillDetail, BillDetailViewModel>().MaxDepth(1);
            CreateMap<Color, ColorViewModel>().MaxDepth(2);
            CreateMap<Size, SizeViewModel>().MaxDepth(2);
            CreateMap<WholePrice, WholePriceViewModel>().MaxDepth(2);
            CreateMap<Setting, SystemConfigViewModel>().MaxDepth(2);
            CreateMap<Footer, FooterViewModel>().MaxDepth(2);
            CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            CreateMap<Menu, MenuViewModel>().MaxDepth(2);
            CreateMap<Language, LanguageViewModel>().MaxDepth(2);
            CreateMap<Announcement, AnnouncementViewModel>().MaxDepth(2);
            CreateMap<AnnouncementUser, AnnouncementUserViewModel>().MaxDepth(2);
            CreateMap<Language, LanguageViewModel>().MaxDepth(2);
            CreateMap<Advertistment, AdvertistmentViewModel>().MaxDepth(2);
            CreateMap<AdvertistmentPage, AdvertistmentPageViewModel>().MaxDepth(2);
            CreateMap<AdvertistmentPosition, AdvertistmentPositionViewModel>().MaxDepth(2);
        }
    }
}