using System.Threading.Tasks;
using Util.Biz.Payments.Wechatpay.Configs;
using Util.Parameters;

namespace Web.Extension
{
    public class WeChatParams : IWechatpayConfigProvider
    {
        public Task<WechatpayConfig> GetConfigAsync(IParameterManager parameters = null)
        {
            throw new System.NotImplementedException();
        }
    }
}