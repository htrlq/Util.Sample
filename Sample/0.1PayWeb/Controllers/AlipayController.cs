using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Util.Biz.Payments;
using Util.Biz.Payments.Alipay.Parameters.Requests;

namespace _0._1PayWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlipayController : ControllerBase
    {
        private IPayFactory Factory { get; }

        public AlipayController(IPayFactory factory)
        {
            Factory = factory;
        }

        //构建html，提供给webapi
        [HttpGet("BuildHtml")]
        public async Task<string> BuildHtml(AlipayWapPayRequest param)
        {
            var service = Factory.CreateAlipayWapPayService();

            return await service.PayAsync(param);
        }

        //mvc自动转跳地址
        [HttpGet("RedirectAsync")]
        public async Task RedirectAsync(AlipayWapPayRequest param)
        {
            var service = Factory.CreateAlipayWapPayService();
            await service.RedirectAsync(param);
        }

        //同步转跳
        [HttpGet("ReturnUrl")]
        public async Task<string> ReturnUrl()
        {
            var service = Factory.CreateAlipayReturnService();
            var result = await service.ValidateAsync();

            return result.IsValid ? "支付成功" : result.ToString();
        }

        //异步回调
        [HttpPost("NotifyUrl")]
        public async Task<string> NotifyUrl()
        {
            var service = Factory.CreateAlipayNotifyService();
            var result = await service.ValidateAsync();

            if (result.IsValid)
            {
                var orderId = service.OrderId;
                var money = service.Money;
                var tradeNo = service.TradeNo;

                return service.Success();
            }

            return service.Fail();
        }
    }
}