using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetSendGrid.Models;
using AspNetSendGrid.Core.Services;

namespace AspNetSendGrid.Controllers
{
    public class HomeController : Controller
    {

        readonly IMailSender _mailSender;
        readonly ILogger<HomeController> _logger;

        public HomeController(
            IMailSender mailSender, 
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _mailSender = mailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("/signup")]
        public async Task<IActionResult> Create(NewsletterSignup signup)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "All fields are required. Please fill them and resubmit.";
                return View("Index", signup);
            }

            await _mailSender.Send(new SendMail
            {
                Name = signup.Name,
                Email = signup.Email
            });

            TempData["Success"] = "Thanks for registering with us. You'll get an email shortly.";

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
