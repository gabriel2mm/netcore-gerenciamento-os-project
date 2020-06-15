using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Contracts;
using GDR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GDR.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository, UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public ActionResult ViewOrder(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Home");
            }

            Order order = _orderRepository.Find(Guid.Parse(id));

            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order);
        }

        [HttpGet]
        public async Task<ActionResult> ApproveRequest(string id)
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
        public ActionResult RecuseRequest(String id)
        {
            return View("RecuseRequest", id);
        }

        [HttpPost]
        public async Task<ActionResult> RecuseRequest(string id, string description)
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
        public async Task<ActionResult> SendNextStep(string id, string step)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));

            switch (step)
            {
                case "usuario":
                    if (User.IsInRole("Admin") || User.IsInRole("Triagem"))
                    {
                        order.Queue = Enumerators.Queue.Requisitante;
                        order.Request.Status = Enumerators.Status.Atualizado;
                        order.Request.User = order.User;
                        order.Request.User = await _userManager.GetUserAsync(User);
                    }
                    break;
                case "triagem":
                    if (User.IsInRole("Usuario") || User.IsInRole("Admin"))
                    {
                        order.Queue = Enumerators.Queue.Triagem;
                        order.Request.Status = Enumerators.Status.Triagem;
                    }
                    break;
                case "pagamento":
                    if (User.IsInRole("Admin") || User.IsInRole("Triagem"))
                    {
                        order.Queue = Enumerators.Queue.DtoPagamento;
                        order.Request.Status = Enumerators.Status.DtoPagamentos;
                        order.Request.User = await _userManager.GetUserAsync(User);
                    }
                    break;
                case "tecnico":
                    if (User.IsInRole("Admin") || User.IsInRole("Triagem") ||  User.IsInRole("Nivel 2"))
                    {
                        order.Queue = Enumerators.Queue.Tecnico;
                        order.Request.Status = Enumerators.Status.Tecnico;
                        order.Request.User = await _userManager.GetUserAsync(User);
                    }
                    break;
                case "n2":
                    if (User.IsInRole("Admin") || User.IsInRole("Tecnico"))
                    {
                        order.Queue = Enumerators.Queue.nivel2;
                        order.Request.Status = Enumerators.Status.Suporte;
                        order.Request.User = await _userManager.GetUserAsync(User);
                    }
                    break;
                case "fechar":
                    if (User.IsInRole("Admin") || User.IsInRole("Tecnico"))
                    {
                        order.Queue = Enumerators.Queue.Requisitante;
                        order.Request.Status = Enumerators.Status.Fechado;
                        order.Request.User = order.User;
                    }
                    break;
                default:
                    return RedirectToAction("ViewOrder", "Order", new { id = id });
            }
            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", "Order", new { id = id });
        }


        public ActionResult UpdateTechnicianOrder(string id)
        {
            return View("UpdateTechnicianOrder", id);
        }

        [HttpPost]
        public ActionResult UpdateTechnicianOrder(string id, string description)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Request.TechnicianDescription = description;
            order.Queue = Enumerators.Queue.Requisitante;
            order.Request.Status = Enumerators.Status.Fechado;
            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id });
        }

        public ActionResult UpdateSupporteOrder(string id)
        {
            return View("UpdateTechnicianOrder", id);
        }

        [HttpPost]
        public ActionResult UpdateSupporteOrder(string id, string description)
        {
            Order order = _orderRepository.Find(Guid.Parse(id));
            order.Queue = Enumerators.Queue.Tecnico;
            order.Request.DescriptionsSupport = description;
            order.Request.Status = Enumerators.Status.Tecnico;
            _orderRepository.Update(order);
            _orderRepository.SaveAll();

            return RedirectToAction("ViewOrder", new { id = id });
        }


    }
}