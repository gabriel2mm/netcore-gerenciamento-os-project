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
using GDR.Contracts;
using GDR.Models.ModelsForViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GDR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Request> _requestRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Order> orderRepository, IRepository<Request> requestRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _orderRepository = orderRepository;
            _requestRepository = requestRepository;
        }

        public IActionResult Index()
        {
            ViewBag.orders = _orderRepository.GetAll().ToList();
            ViewBag.requests = _requestRepository.GetAll().ToList();

            return View();
        }
       
        public async  Task<IActionResult> CreateOrder()
        {
            OrderViewModel view = new OrderViewModel();
            User user = await _userManager.GetUserAsync(User);
            view.User = user.Id;

            ViewBag.requests = _requestRepository.GetAll().ToList();

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(OrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Order o = new Order();
            o.Id = Guid.NewGuid();
            o.Description = order.Description;
            o.Created = new DateTime();
            o.User = await _userManager.FindByIdAsync(order.User);
            //o.Request = _requestRepository.Get((r => r.Id.Equals(order.Request))).FirstOrDefault();

            _orderRepository.Add(o);
            _orderRepository.SaveAll();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Usuario")]
        public IActionResult CreateRequest()
        {
            RequestViewModel request = new RequestViewModel();
            return View(request);
        }

        [Authorize(Roles = "Admin,Usuario")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRequest(RequestViewModel request)
        {
          
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(request);
                }

                User user = await _userManager.GetUserAsync(User);
                request.UserId = user.Id;

                Request r = new Request();
                r.Id = Guid.NewGuid();
                r.Equipament = request.Equipament;
                r.Description = request.Description;
                r.Status = Enumerators.Status.Aberto;
                r.Type = request.Type;
                r.Approval = false;
                r.User = user;
                r.DescriptionDeclineApproval = String.Empty;

                _requestRepository.Add(r);
                _requestRepository.SaveAll();

            }
            catch(Exception e)
            {
                _logger.LogError(String.Format("Não foi possível criar requisição [ %s ]", e.Message));
            }

            return RedirectToAction(nameof(Index));            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
