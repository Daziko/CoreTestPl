using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.Builder
{ 
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder appBuilder, string roothPath)
        {
            var path = Path.Combine(roothPath, "node_modules");
            var provider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = provider
            };
            appBuilder.UseStaticFiles(options);
            return appBuilder;
        }
    }
}
