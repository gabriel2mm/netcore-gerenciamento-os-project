using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GDR.Models;
using Microsoft.AspNetCore.Authorization;
using GDR.Repository;

namespace GDR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrderRepository _orderRepository;
        private readonly RequestRepository _requestRepository;

        public HomeController(ILogger<HomeController> logger, OrderRepository orderRepository, RequestRepository requestRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _requestRepository = requestRepository;
        }

        public IActionResult Index()
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
