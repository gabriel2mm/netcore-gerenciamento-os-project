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
using GDR.Enumerators;

namespace GDR.Controllers
{
    [Authorize(Roles="Usuario,Admin,Triagem,Nivel 2,Tecnico")]
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

        public async Task<IActionResult> Index()
        {
            User connected = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Usuario"))
            {
                ViewBag.orders = _orderRepository.Get((o => o.User.Login == connected.Login)).ToList();
                ViewBag.requests = _requestRepository.Get(((r => r.Status == Status.Aberto || r.Status == Status.Atualizado))).ToList();
            }
            else if (User.IsInRole("Triagem"))
            {
                ViewBag.orders = _orderRepository.Get((o => o.Queue == Queue.Triagem)).ToList();
                ViewBag.requests = _requestRepository.Get((r => r.Status == Status.Triagem)).ToList();
            }
            else if (User.IsInRole("DPTO Pagamento"))
            {
                ViewBag.orders = _orderRepository.Get((o => o.Queue == Queue.DtoPagamento)).ToList();
                ViewBag.requests = _requestRepository.Get((r => r.Status == Status.DtoPagamentos)).ToList();
            }
            else if (User.IsInRole("Nivel 2"))
            {
                ViewBag.orders = _orderRepository.Get((o => o.Queue == Queue.nivel2)).ToList();
                ViewBag.requests = _requestRepository.Get((r => r.Status == Status.Suporte)).ToList();
            }
            else if (User.IsInRole("Tecnico"))
            {
                ViewBag.orders = _orderRepository.Get((o => o.Queue == Queue.Tecnico)).ToList();
                ViewBag.requests = _requestRepository.Get((r => r.Status == Status.Tecnico || r.Status == Status.Agendado)).ToList();
            }

            return View();
        }

        public async Task<IActionResult> CreateOrder()
        {
            OrderViewModel view = new OrderViewModel();

            User connected = await _userManager.GetUserAsync(User);
            view.User = connected;

            ViewBag.requests = _requestRepository.Get((r => r.User.Login == connected.Login && (r.Status == Status.Aberto || r.Status == Status.Atualizado))).ToList();

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(OrderViewModel order)
        {

            User user = await _userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
            {
                ViewBag.requests = _requestRepository.Get((r => r.User.Login == user.Login && (r.Status == Status.Aberto || r.Status == Status.Atualizado))).ToList();
                return View(order);
            }
            
            Order o = new Order();
            o.Queue = Queue.Requisitante;
            o.Id = Guid.NewGuid();
            o.Description = order.Description;
            o.User = await _userManager.GetUserAsync(User);
            o.Request = _requestRepository.Find(Guid.Parse(order.Request));

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
            catch (Exception e)
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
