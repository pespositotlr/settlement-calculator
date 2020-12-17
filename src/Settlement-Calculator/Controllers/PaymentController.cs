using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementCalculator.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PaymentController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<PaymentController> _logger;
		private IConfiguration _config;
		private readonly IPaymentPlanFactory _paymentPlanFactory;

		public PaymentController(ILogger<PaymentController> logger, IConfiguration config, IPaymentPlanFactory paymentPlanFactory)
		{
			_logger = logger;
			_config = config;
			_paymentPlanFactory = paymentPlanFactory;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpPost]
		public PaymentPlan Post([FromBody]decimal settlementAmount)
		{
			PaymentPlan plan = _paymentPlanFactory.CreatePaymentPlan(settlementAmount);
			return plan;
		}
	}
}
