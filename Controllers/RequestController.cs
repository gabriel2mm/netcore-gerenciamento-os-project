using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDR.Contracts;
using GDR.Models;
using GDR.Models.ModelsForViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GDR.Controllers
{
    [Authorize(Roles = "Usuario,Admin,Triagem,Nivel 2,Tecnico")]
    public class RequestController : Controller
    {

        private readonly IRepository<Request> _requestRepository;
        public RequestController(IRepository<Request> requestRepository)
        {
            _requestRepository = requestRepository;
        }
        public ActionResult ViewRequest(String id)
        {
            Request request = _requestRepository.Find(Guid.Parse(id));

            if (request == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(request);
        }

        public ActionResult EditRequest(String id)
        {
            Request req = _requestRepository.Find(Guid.Parse(id));

            RequestViewModel view = new RequestViewModel()
            {
                Id = req.Id,
                Description = req.Description,
                Type = req.Type,
                Equipament = req.Equipament,
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRequest(RequestViewModel model)
        {
            Request req = _requestRepository.Find(model.Id);
            req.Equipament = model.Equipament;
            req.Description = model.Description;
            req.Type = model.Type;
            req.isDptoPayment = false;
            req.DescriptionDeclineApproval = String.Empty;
            req.DescriptionsSupport = String.Empty;               
                
            _requestRepository.Update(req);
            _requestRepository.SaveAll();

            return RedirectToAction("Index", "Home");
        }
    }
}