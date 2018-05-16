using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Data.Entities;
using AspNetCore.Infrastructure.Enums;
using AspNetCore.Data.Enums;
using AspNetCore.Utilities.Constants;


namespace AspNetCore.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Admin"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    //Balance = 0,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = Status.Actived
                }, "hoilamgi");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            if (!_context.Functions.Any())
            {
                var functionId = Guid.NewGuid();
                var ecommerceId = Guid.NewGuid();
                var contentId = Guid.NewGuid();
                var utilityId = Guid.NewGuid();
                var reportId = Guid.NewGuid();

                _context.Functions.AddRange(new List<Function>()
                {
                   new Function() {Id =functionId,UniqueCode = "SYSTEM", Name = "Hệ thống",ParentId = null,SortOrder = 1,Status = Status.Actived,Url = "/",CssClass = "fa-desktop"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ROLE", Name = "Nhóm",ParentId = functionId,SortOrder = 1,Status = Status.Actived,Url = "/admin/role/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FUNCTION", Name = "Chức năng",ParentId = functionId,SortOrder = 2,Status = Status.Actived,Url = "/admin/function/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "USER", Name = "Người dùng",ParentId = functionId,SortOrder =3,Status = Status.Actived,Url = "/admin/user/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ACTIVITY", Name = "Nhật ký",ParentId = functionId,SortOrder = 4,Status = Status.Actived,Url = "/admin/activity/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ERROR", Name = "Lỗi",ParentId = functionId,SortOrder = 5,Status = Status.Actived,Url = "/admin/error/index",CssClass = "fa-home"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "SETTING", Name = "Cấu hình",ParentId = functionId,SortOrder = 6,Status = Status.Actived,Url = "/admin/setting/index",CssClass = "fa-home"  },

                    new Function() {Id =ecommerceId,UniqueCode = "ECOMMERCE",Name = "Sản phẩm",ParentId = null,SortOrder = 2,Status = Status.Actived,Url = "/",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = ecommerceId,SortOrder =1,Status = Status.Actived,Url = "/admin/productcategory/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = ecommerceId,SortOrder = 2,Status = Status.Actived,Url = "/admin/product/index",CssClass = "fa-chevron-down"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "BILL",Name = "Hóa đơn",ParentId = ecommerceId,SortOrder = 3,Status = Status.Actived,Url = "/admin/bill/index",CssClass = "fa-chevron-down"  },

                    new Function() {Id =contentId,UniqueCode = "CONTENT",Name = "Nội dung",ParentId = null,SortOrder = 3,Status = Status.Actived,Url = "/",CssClass = "fa-table"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "POST_CATEGORY",Name = "Danh mục",ParentId = ecommerceId,SortOrder =1,Status = Status.Actived,Url = "/admin/postcategory/index",CssClass = "fa-table"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "POST",Name = "Bài viết",ParentId =contentId,SortOrder = 1,Status = Status.Actived,Url = "/admin/post/index",CssClass = "fa-table"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "PAGE",Name = "Trang",ParentId = contentId,SortOrder = 2,Status = Status.Actived,Url = "/admin/page/index",CssClass = "fa-table"  },

                    new Function() {Id =utilityId,UniqueCode = "UTILITY",Name = "Tiện ích",ParentId = null,SortOrder = 4,Status = Status.Actived,Url = "/",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FOOTER",Name = "Footer",ParentId = utilityId,SortOrder = 1,Status = Status.Actived,Url = "/admin/footer/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "FEEDBACK",Name = "Phản hồi",ParentId = utilityId,SortOrder = 2,Status = Status.Actived,Url = "/admin/feedback/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ANNOUNCEMENT",Name = "Thông báo",ParentId = utilityId,SortOrder = 3,Status = Status.Actived,Url = "/admin/announcement/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "CONTACT",Name = "Liên hệ",ParentId = utilityId,SortOrder = 4,Status = Status.Actived,Url = "/admin/contact/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "SLIDE",Name = "Slide",ParentId = utilityId,SortOrder = 5,Status = Status.Actived,Url = "/admin/slide/index",CssClass = "fa-clone"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ADVERTISMENT",Name = "Quảng cáo",ParentId = utilityId,SortOrder = 6,Status = Status.Actived,Url = "/admin/advertistment/index",CssClass = "fa-clone"  },

                    new Function() {Id =reportId,UniqueCode = "REPORT",Name = "Báo cáo",ParentId = null,SortOrder = 5,Status = Status.Actived,Url = "/",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "REVENUES",Name = "Báo cáo doanh thu",ParentId = reportId,SortOrder = 1,Status = Status.Actived,Url = "/admin/report/revenues",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "ACCESS",Name = "Báo cáo truy cập",ParentId = reportId,SortOrder = 2,Status = Status.Actived,Url = "/admin/report/visitor",CssClass = "fa-bar-chart-o"  },
                    new Function() {Id =Guid.NewGuid(),UniqueCode = "READER",Name = "Báo cáo độc giả",ParentId = reportId,SortOrder = 3,Status = Status.Actived,Url = "/admin/report/reader",CssClass = "fa-bar-chart-o"  },
                });
            }

            if (_context.Contacts.Count(x => x.Id == CommonConstants.DefaultContactId) == 0)
            {
                _context.Contacts.Add(new Contact()
                {
                    Id = CommonConstants.DefaultContactId,
                    Name = "ABC",
                    Status = Status.Actived,
                    Address = "Hanoi",
                    Email = "abc@gmail.com",
                    Phone = "0900 000 000",
                    Other = "Khác",                
                    Website = "/",
                    Lng = 21.0000000,
                    Lat = 105.000000,
                });
            }

            if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                _context.Footers.Add(new Footer()
                {
                    Id = CommonConstants.DefaultFooterId,
                    Content = content,
                    Status = Status.Actived
                });
            }

            //if (_context.Colors.Count() == 0)
            //{
            //    List<Color> listColor = new List<Color>()
            //    {
            //        new Color() {Name="Black", Code="#000000" },
            //        new Color() {Name="White", Code="#FFFFFF"},
            //        new Color() {Name="Red", Code="#ff0000" },
            //        new Color() {Name="Blue", Code="#1000ff" },
            //    };
            //    _context.Colors.AddRange(listColor);
            //}

            if (!_context.AdvertistmentPages.Any())
            {
                List<AdvertistmentPage> pages = new List<AdvertistmentPage>()
                {
                    new AdvertistmentPage() { Id = Guid.NewGuid(), UniqueCode = "home", Name="Trang chủ"},
                    new AdvertistmentPage() { Id =Guid.NewGuid(), UniqueCode = "product-cate", Name="Danh mục sản phẩm" },
                    new AdvertistmentPage() { Id = Guid.NewGuid(), UniqueCode = "product-detail", Name="Chi tiết sản phẩm"},
                };
                _context.AdvertistmentPages.AddRange(pages);
            }

            if (!_context.Slides.Any())
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 1",Image="/client-side/images/slider/slide-1.jpg",Url="#",SortOrder = 1,GroupAlias = SlideGroup.Top,Status = Status.Actived  },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 2",Image="/client-side/images/slider/slide-2.jpg",Url="#",SortOrder = 2,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 3",Image="/client-side/images/slider/slide-3.jpg",Url="#",SortOrder = 3,GroupAlias = SlideGroup.Top,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 4",Image="/client-side/images/brand1.png",Url="#",SortOrder = 4,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 5",Image="/client-side/images/brand2.png",Url="#",SortOrder = 5,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 6",Image="/client-side/images/brand3.png",Url="#",SortOrder = 6,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 7",Image="/client-side/images/brand4.png",Url="#",SortOrder = 7,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 8",Image="/client-side/images/brand5.png",Url="#",SortOrder = 8,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 9",Image="/client-side/images/brand6.png",Url="#",SortOrder = 9,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 10",Image="/client-side/images/brand7.png",Url="#",SortOrder = 10,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 11",Image="/client-side/images/brand8.png",Url="#",SortOrder = 11,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 12",Image="/client-side/images/brand9.png",Url="#",SortOrder = 12,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 13",Image="/client-side/images/brand10.png",Url="#",SortOrder = 13,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                    new Slide() { Id = Guid.NewGuid(),Name="Slide 14",Image="/client-side/images/brand11.png",Url="#",SortOrder = 14,GroupAlias = SlideGroup.Branch,Status = Status.Actived },
                };
                _context.Slides.AddRange(slides);
            }

            //if (_context.Sizes.Count() == 0)
            //{
            //    List<Size> listSize = new List<Size>()
            //    {
            //        new Size() { Width=100 },
            //        new Size() { Height=200}                    
            //    };
            //    _context.Sizes.AddRange(listSize);
            //}

            if (!_context.ProductCategories.Any())
                {
                var id1 = Guid.NewGuid();
                var id2 = Guid.NewGuid();
                var id3 = Guid.NewGuid();
                var id4 = Guid.NewGuid();
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Id = id1,Code="RV01",RelCanonical="Link01",Name="Rem vải",PageAlias="Rèm vải",ParentId = null,Status=Status.Actived,SortOrder=1,PageTitle="Rèm vải",MetaDescription="description" },
                    new ProductCategory() { Id = id2,Code="RC01",RelCanonical="Link02",Name="Rèm cuốn",PageAlias="rem-cuon",ParentId = null,Status=Status.Actived,SortOrder=2,PageTitle="Rèm cuốn",MetaDescription="description"},
                    new ProductCategory() { Id = id3,Code="RG01",RelCanonical="Link03",Name="Rèm gỗ",PageAlias="Rem go",ParentId = null,Status=Status.Actived,SortOrder=3,PageTitle="Rèm gỗ",MetaDescription="description"},
                    new ProductCategory() { Id = id4,Code="RLD01",RelCanonical="Link04",Name="Rèm lá dọc",PageAlias="rèm-lá-dọc",ParentId = null,Status=Status.Actived,SortOrder=4,PageTitle="Rèm lá dọc",MetaDescription="description"}
                };

                var list1 = new List<Product>()
                        {
                            new Product(){CategoryId = id1, Name = "Product 1",PageTitle="Product 1",MetaDescription="Description",Tags="rèm vải,rèm vải đẹp",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-1",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1, Name = "Product 2",PageTitle="Product 2",MetaDescription="Description",Tags="rem vai,rèm vải thô",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-2",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1, Name = "Product 3",PageTitle="Product 3",MetaDescription="Description",Tags="rèm vải thô",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-3",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1, Name = "Product 4",PageTitle="Product 4",MetaDescription="Description",Tags="rèm vải",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-4",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id1, Name = "Product 5",PageTitle="Product 5",MetaDescription="Description",Tags="rem vai,thành",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-5",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
                var list2 = new List<Product>()
                        {
                            new Product(){CategoryId = id2, Name = "Product 6",PageTitle="Product 6",MetaDescription="Description",Tags="rem cuon,rèm cuốn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-6",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2, Name = "Product 7",PageTitle="Product 7",MetaDescription="Description",Tags="rem cuon,rèm cuốn,rèm cuốn rẻ",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-7",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2, Name = "Product 8",PageTitle="Product 8",MetaDescription="Description",Tags="rem cuốn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-8",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2, Name = "Product 9",PageTitle="Product 9",MetaDescription="Description",Tags="rem cuon",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-9",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id2, Name = "Product 10",PageTitle="Product 10",MetaDescription="Description",Tags="rem cuon",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-10",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
                var list3 = new List<Product>()
                        {
                            new Product(){CategoryId = id3, Name = "Product 11",PageTitle="Product 11",MetaDescription="Description",Tags="rem go,rèm gỗ xịn",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-11",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id3, Name = "Product 12",PageTitle="Product 12",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-12",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id3, Name = "Product 13",PageTitle="Product 13",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-13",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id3, Name = "Product 14",PageTitle="Product 14",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-14",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id3, Name = "Product 15",PageTitle="Product 15",MetaDescription="Description",Tags="rem go",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-15",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
                var list4 = new List<Product>()
                        {
                            new Product(){CategoryId = id4, Name = "Product 16",PageTitle="Product 16",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-16",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id4, Name = "Product 17",PageTitle="Product 17",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-17",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id4, Name = "Product 18",PageTitle="Product 18",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-18",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id4, Name = "Product 19",PageTitle="Product 19",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-19",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                            new Product(){CategoryId = id4, Name = "Product 20",PageTitle="Product 20",MetaDescription="Description",Tags="rem la doc",Image="/client-side/images/products/product-1.jpg",PageAlias = "san-pham-20",Price = 1000,Status = Status.Actived,OriginalPrice = 1000},
                        };
                _context.ProductCategories.AddRange(listProductCategory);
                _context.Products.AddRange(list1);
                _context.Products.AddRange(list2);
                _context.Products.AddRange(list3);
                _context.Products.AddRange(list4);              
            }

            if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new Setting()
                {
                    Id = Guid.NewGuid(),
                    UniqueCode = "HomeTitle",
                    Name = "Tiêu đề trang chủ",
                    TextValue = "Title",
                    Status = Status.Actived
                });
            }
            if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new Setting()
                {
                    Id = Guid.NewGuid(),
                    UniqueCode = "HomeMetaKeyword",
                    Name = "Từ khoá trang chủ",
                    TextValue = "Keywords",
                    Status = Status.Actived
                });
            }
            if (!_context.SystemConfigs.Any(x => x.UniqueCode == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new Setting()
                {
                    Id = Guid.NewGuid(),
                    UniqueCode = "HomeMetaDescription",
                    Name = "Mô tả trang chủ",
                    TextValue = "Description",
                    Status = Status.Actived
                });
            }
            _context.SaveChanges();
            //await _context.SaveChangesAsync();
        }
    }
}
