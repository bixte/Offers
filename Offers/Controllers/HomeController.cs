using Microsoft.AspNetCore.Mvc;
using Offers.BLL.DTO;
using Offers.BLL.Interfaces;

namespace Offers.Controllers
{
    [Route("magazin.ru")]
    public class HomeController : Controller
    {
        private readonly IOfferServiceAsync offerService;
        private readonly IConfiguration configuration;

        public HomeController(IOfferServiceAsync offerService, IConfiguration configuration)
        {
            this.offerService = offerService;
            this.configuration = configuration;
        }
        [HttpGet("product_page.asp")]
        public async Task<IActionResult> Index(int pid = 11)
        {
            OfferDTO offer;
            try
            {
                offer = await offerService.GetOfferAsync(pid);
            }
            catch (Exception ex)
            {
                if (ex.Message == "not found")
                {
                    await offerService.SaveFromOriginAsync(configuration.GetConnectionString("origin")!, pid.ToString());
                    return Content("In database didn't detect this offer. It loaded, please update the page.");
                }
                return Content(ex.Message);
            }

            return View(offer);
        }
    }
}