using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHospitalizationPal.DAL.Interfaces;
using MyHospitalizationPal.DAL.Models;
using MyHospitalizationPal.DAL.Repository;
using MyHospitalizationPal.Server.DAO.Repository;
using MyHospitalizationPal.Server.Services.FeelingsGraphic;
using MyHospitalizationPal.Server.Services.HealthProfessional;
using MyHospitalizationPal.Server.Services.Login;
using MyHospitalizationPal.Server.Services.PatientNotes;
using MyHospitalizationPal.Server.Services.Pdf;
using MyHospitalizationPal.Server.Services.Register;
using MyHospitalizationPal.Server.Services.ScheduledEvents;
using MyHospitalizationPal.Server.Services.UserBanner;
using MyHospitalizationPal.Server.Services.UserProfile;
using Newtonsoft.Json.Serialization;

namespace MyHospitalizationPal.Server
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                        // send back a ISO date
                        var settings = options.SerializerSettings;
                        settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                        // dont mess with case of properties
                        var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                        resolver.NamingStrategy = null;
                    });


            //services.AddDbContext<MobilityDbContext>(options =>
            //{
            //    var connectionString = Configuration.GetConnectionString("MobilityDb");
            //    options.UseSqlServer(connectionString);
            //});

            //Inregistram contextul

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MobilityDb"), b => b.MigrationsAssembly("MyHospitalizationPal.Server")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserBannerService, UserBannerService>();
            services.AddTransient<IPatientNotesService, PatientNotesService>();
            services.AddTransient<IHealthProfessionalService, HealthProfessionalService>();
            services.AddTransient<IScheduledEventService, ScheduledEventService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IFeelingsGraphicService, FeelingsGraphicService>();
            services.AddTransient<IPdfService, PdfService>();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            

            //Inregistram repo
            //services.AddTransient<IRepository, Repository.Value()>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
