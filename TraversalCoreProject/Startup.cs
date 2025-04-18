﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //Entity Framework Core kullanarak veritabanı bağlantısını yapılandırır.
            //Context->Uygulamanın veri tabanı ile i,letişimini sagalar.
            services.AddDbContext<Context>();
            //Kullanıcı kimlik doğrulama (authentication) sistemini ekler.
            //.AddEntityFrameworkStores<Context>() → Kimlik doğrulama işlemlerinin veritabanında saklanacağını belirtir
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
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
