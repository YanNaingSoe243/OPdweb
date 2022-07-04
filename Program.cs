using AutoMapper;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OPdWebApp.ExprotService;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OPdWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
           
            var DefaultApi = builder.Configuration.GetValue<string>("Api:Connection");
         

            builder.Services.AddHttpClient<IRepositoryT, RestRepositoryT>(client =>
            {
                client.BaseAddress = new Uri(DefaultApi);
            });

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddBlazoredToast();
            // builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IAuthenticationService, RestAuthentication>(client => new RestAuthentication(DefaultApi));
            builder.Services.AddScoped<IRepositoryT, RestRepositoryT>(client => new RestRepositoryT(DefaultApi));
            builder.Services.AddSingleton<ExportService>();
            builder.Services.AddSingleton<QRcode>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();           
            builder.Services.AddBlazorDownloadFile();
        
            await builder.Build().RunAsync();
           
        }
       
    }
}
