using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RoPlus.Base.Models;

namespace RoPlus.Repository {
  public class Startup {
    public Startup( IHostingEnvironment env ) {
      var builder = new ConfigurationBuilder()
          .SetBasePath( env.ContentRootPath )
          .AddJsonFile( "appsettings.json", optional: true, reloadOnChange: true )
          .AddJsonFile( $"appsettings.{env.EnvironmentName}.json", optional: true );

      if ( env.IsEnvironment( "Development" ) ) {
        // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
        builder.AddApplicationInsightsSettings( developerMode: true );
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices( IServiceCollection services ) {
      
      var connection = Configuration.GetConnectionString( "RoPlus" );
      services.AddDbContext<RoPlusDbContext>( options => options.UseSqlServer( connection ) );
      services.AddApplicationInsightsTelemetry( Configuration );

      services.AddMvc();
    }

    public void Configure( IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory ) {
      loggerFactory.AddConsole( Configuration.GetSection( "Logging" ) );
      loggerFactory.AddDebug();

      app.UseApplicationInsightsRequestTelemetry();

      app.UseApplicationInsightsExceptionTelemetry();

      app.UseMvc();
    }
  }
}
