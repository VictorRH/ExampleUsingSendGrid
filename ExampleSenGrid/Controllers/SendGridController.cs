using ExampleSenGrid.SendGrindLibrary.Interfaz;
using ExampleSenGrid.SendGrindLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ExampleSenGrid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendGridController : ControllerBase
    {
        private readonly ISendGridSend sendGrid;
        private readonly IConfiguration configuration;

        //private readonly Microsoft.Extensions.Configuration.IConfiguration configuration;
        public SendGridController(ISendGridSend sendGrid, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.sendGrid = sendGrid;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> SenEmail()
        {
            var objectData = new SendGridModel
            {
                PlainTextContent = "Example Send Email for josemer",
                EmailFrom = "josemer616@gmail.com",
                NameFrom = "ChilaquilTeam",
                Title = "Mi Second Email Send",
                SendGridAPIKey = configuration["SendGrid:ApiKey"]
            };
            var result = await sendGrid.SendEmail(objectData);
            if (result.result)
            {
                return Ok();
            }
            return BadRequest();
        }


        //[HttpPost]
        //public async Task<(bool result, string errorMessage)> SenEmail()
        //{
        //    try
        //    {
        //        var objectData = new SendGridModel
        //        {
        //            PlainTextContent = "Example Send Email",
        //            EmailFrom = "viktor.raymundo@gmail.com",
        //            NameFrom = "viktor",
        //            Title = "Example Title send grid",
        //            SendGridAPIKey = configuration["SendGrid:ApiKey"]
        //        };
        //        var result = await sendGrid.SendEmail(objectData);
        //        if (result.result)
        //        {
        //            return (true, null);
        //        }
        //        return (true, result.errorMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message);
        //    }
        //}




    }
}
