using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Contracts;
using GDR.Helpers;
using GDR.Models;
using GDR.Models.ModelsForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDR.Controllers
{
    [Authorize(Roles = "Usuario,Admin,Triagem,Nivel 2,Tecnico")]
    public class OrderController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository, UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public IActionResult ViewOrder(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }

            Guid temp;
            Guid.TryParse(id, out temp);
            Order order = _orderRepository.Find(temp);

            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order);
        }


        [HttpGet]
        public async Task<IActionResult> ApproveRequest(string id)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Request.Approval = true;
            order.Request.isDptoPayment = true;
            order.Request.Status = Enumerators.Status.Triagem;
            order.Queue = Enumerators.Queue.Triagem;
            order.Request.User = await _userManager.GetUserAsync(User);
            order.Request.DescriptionDeclineApproval = String.Empty;

            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id});
        }

        [HttpGet]
        public IActionResult RecuseRequest(String id)
        {
            return View("RecuseRequest", id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecuseRequest(string id, string description)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Request.Approval = false;
            order.Request.DescriptionDeclineApproval = description;
            order.Request.isDptoPayment = true;
            order.Request.Status = Enumerators.Status.Triagem;
            order.Queue = Enumerators.Queue.Triagem;
            order.Request.User = await _userManager.GetUserAsync(User);

            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> SendNextStep(string id, string step, bool permission)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            User user = await _userManager.GetUserAsync(User);
            ChainUsuario chainUsuario = new ChainUsuario();
            ChainTriagem chainTriagem = new ChainTriagem();
            ChainPagamento chainPagamento = new ChainPagamento();
            ChainTecnico chainTecnico = new ChainTecnico();
            ChainSuporte chainSuporte = new ChainSuporte();
            ChainCloseOrder chainCloseOrder = new ChainCloseOrder();

            chainUsuario.SetNext(chainTriagem).SetNext(chainPagamento).SetNext(chainTecnico).SetNext(chainSuporte).SetNext(chainCloseOrder);
            
            object[] handler = new object[4] { step, permission, order, user };
            order = chainUsuario.Handle(handler) as Order;

            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", "Order", id);
        }


        public IActionResult UpdateTechnicianOrder(string id)
        {
            return View("UpdateTechnicianOrder", id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTechnicianOrder(string id, string description)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Request.TechnicianDescription = description;
            order.Queue = Enumerators.Queue.Requisitante;
            order.Request.Status = Enumerators.Status.Fechado;
            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id });
        }

        public IActionResult UpdateSupporteOrder(string id)
        {
            return View("UpdateTechnicianOrder", id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSupporteOrder(string id, string description)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Queue = Enumerators.Queue.Tecnico;
            order.Request.DescriptionsSupport = description;
            order.Request.Status = Enumerators.Status.Tecnico;
            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id });
        }


        public IActionResult SchedullingOrder(string id)
        {
            SchedulingViewModel sc = new SchedulingViewModel();
            sc.Id = Guid.Parse(id);

            return View("SchedullingOrder", sc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SchedullingOrder(SchedulingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SchedullingOrder", model.Id);
            }

            Order order = _orderRepository.Find(model.Id);
            order.Request.Status = Enumerators.Status.Agendado;
            order.Request.Scheduling = model.Agendamento;

            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", model.Id);
        }
    }
}