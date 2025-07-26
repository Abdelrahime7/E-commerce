using Microsoft.AspNetCore.Builder;
using Serilog;


namespace Infrastructure
{
    public static class SeriLogConfig
    {
        public static void  LoggConfig(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));
            

        }


    }
}
