using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Util.Biz.Payments.Alipay.Configs;

namespace Web.Extension
{
    public class AlipayParams: IAlipayConfigProvider
    {
        private AlipayConfig Config { get; }

        public AlipayParams(IOptions<AlipayConfig> options)
        {
            Config = options.Value;
        }

        public Task<AlipayConfig> GetConfigAsync()
        {
            return Task.FromResult(Config);
        }
    }
}