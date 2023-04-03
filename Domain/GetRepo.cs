using Microsoft.Extensions.DependencyInjection;
using System;


namespace HW_01_Eurich_Kapitonova.Domain
{
    public static class GetRepo
    {
        internal static IServiceProvider? service;
        public static TRepo? Instance<TRepo>() where TRepo : class
            => service?.CreateScope()?.ServiceProvider?.GetRequiredService<TRepo>();
        public static void SetService(IServiceProvider s) => service = s;
    }
}
