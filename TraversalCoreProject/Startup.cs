using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUnitOfWork;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUnitOfWork;
using BusinessLayer.FluentValidation.ContactUs;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.AbstractUnitOfWork;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFramework.EfUnitOfWork;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDto;
using DTOLayer.DTOs.ContactDto;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.CQRS.Handlers.GuideHandlers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace TraversalCoreProject
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
            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                //uygulamayı debug modda calıstırınca logları outputta gosterir
                x.AddDebug();
            });
            //typeof(Startup) ifadesi, eşleme profillerinin (Profile sınıfı) nerede aranacağını belirtir.
            //Yani, AutoMapper Startup sınıfının bulunduğu assembly içinde tanımlı Profile sınıflarını bulup otomatik yükler.

            services.AddAutoMapper(typeof(Startup));
            //AnnouncementAddDto sınıfının doğrulamasını(validation) yapacak olan AnnouncementAddValidator sınıfını belirtir.
            //AddTransient ile bu validator, her ihtiyaç duyulduğunda yeniden oluşturularak kullanılır.
            //FluentValidation kullanılarak şöyle bir validator yazılır:
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDto>, AnnouncementUpdateValidator>();

            services.AddTransient<IValidator<SendMessageDto>, SendContactUsValidatior>();

            //FluentValidation kütüphanesini ASP.NET Core MVC ile entegre eder. Böylece, gönderilen form verileri FluentValidation ile otomatik doğrulanır.
            services.AddControllersWithViews();
            // FluentValidation otomatik bağlama
            services.AddFluentValidationAutoValidation(); // Bu satır FluentValidation 11 içindir
            //✳️ Bu yeni yapı, FluentValidation 11 ile uyumludur ve hiçbir metot çizili görünmez.
            services.AddValidatorsFromAssemblyContaining<AppUserRegisterValidator>();


            services.AddScoped<IAppUserService,AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

             services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();


            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IContactSideUserMessageService, ContactSideUserMessageManager>();
            services.AddScoped<IContactSideUserMessageDal, EfContactSideUserMessageDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();
            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();

            services.AddScoped<GetAllDestinationQueryHandler>();
            services.AddScoped<GetDestinationByIdQueryHandler>();
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            //uygulamaya MediatR kütüphanesini tanıtır ve ilgili handler'ları (işleyicileri)
            //otomatik olarak bulup Dependency Injection (bağımlılık enjeksiyonu) sistemine dahil eder.
            //typeof(Startup) ifadesi, C#’ta Startup sınıfının tür bilgisini (type) verir.
            //Bu türün bulunduğu assembly(derlenmiş.dll dosyası) üzerinden MediatR handler’larını araması sağlanır.
             services.AddMediatR(typeof(Startup));

            //Entity Framework Core kullanarak veritabanı bağlantısını yapılandırır.
            //Context->Uygulamanın veri tabanı ile i,letişimini sagalar.
            services.AddDbContext<Context>();
            //Kullanıcı kimlik doğrulama (authentication) sistemini ekler.
            //.AddEntityFrameworkStores<Context>() → Kimlik doğrulama işlemlerinin veritabanında saklanacağını belirtir
            services.AddIdentity<AppUser, AppRole>()
              .AddEntityFrameworkStores<Context>()
              //Password reset işlemi için gerekiyor
              //	Şifre sıfırlama, e-posta onayı gibi işlemler için token üretir
              .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            services.Configure<IdentityOptions>(options =>
            {
                // Şifre kuralları
                options.Password.RequireDigit = true;              // En az 1 rakam
                options.Password.RequiredLength = 6;               // En az 6 karakter
                options.Password.RequireNonAlphanumeric = false;   // !@# gibi özel karakter zorunlu mu
                options.Password.RequireUppercase = true;          // En az 1 büyük harf
                options.Password.RequireLowercase = true;          // En az 1 küçük harf
            });



            services.AddControllersWithViews();
            services.AddHttpClient();

            //Mvc servisini ekler ve bazı yetkilendirme (authorization) kurallarını uygular.
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                //Tüm sayfalara erişim için kimlik doğrulaması gerektirir.
                .RequireAuthenticatedUser()
                .Build();
                //Bu yetkilendirme filtresini global olarak tüm controller'lara uygular.
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //services.AddMvc();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });

            //Dil destegi için eklenmesi gerekiyor
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //Logları dosyaya kaydeder
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //Kullanıcı kimliği doğrulanıyor (ÖNCE GELMELİ!)
            app.UseAuthentication();

            app.UseRouting();
            //Yetkilendirmeden önce cagırılırsa kullanıcının kimliği bilinmez
            //Kullanıcının yetkileri kontrol ediliyor (SONRA GELMELİ!)
            app.UseAuthorization();

            var supportedCultures = new[] { "en", "tr" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
