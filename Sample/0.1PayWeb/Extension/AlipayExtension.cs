using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Biz.Payments.Alipay.Configs;
using Util.Biz.Payments.Extensions;

namespace Web.Extension
{
    public static class AlipayExtension
    {
        public static IServiceCollection AddAlipayExtension(this IServiceCollection services,Action<AlipayConfig> func)
        {
            services.Configure(func);
            services.AddAlipay<AlipayParams>();

            return services;
        }

        public static IServiceCollection AddAlipayExtension(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AlipayConfig>(config);
            services.AddAlipay<AlipayParams>();

            return services;
        }
    }
}