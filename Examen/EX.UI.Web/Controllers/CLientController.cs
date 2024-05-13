using EX.Core.Domain;
using EX.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Numerics;

namespace EX.UI.Web.Controllers
{
    public class CLientController : Controller
    {
        readonly IClientService clientService;
        readonly IConseiller conseillerService;
        public CLientController(IClientService clientService, IConseiller conseillerService)
        {
            this.clientService = clientService;
            this.conseillerService = conseillerService;

        }
        // GET: CLientController
        public ActionResult Index(string login)
        {
            var clients = clientService.GetAll();

            if (!string.IsNullOrEmpty(login))
            {
                clients = clients.Where(c => c.login.Contains(login)).ToList();
            }

            return View(clients);
        }
     

        // GET: CLientController/Details/5
        public ActionResult Details(int id)
        {
            return View(conseillerService.Get(id));
        }

        // GET: CLientController/Create
        public ActionResult Create()
        {
            var c = conseillerService.GetAll();
            ViewBag.P = new SelectList(c, "conseillerId", "conseillerId");
            return View();
        }

        // POST: CLientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CLient c, IFormFile photoImg)
        {
            try
            {
                if (photoImg != null && photoImg.Length > 0)
                {
                    // Save the image file to the "wwwroot/Images" folder
                  //  var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Path.GetFileName(photoImg.FileName);

                    var fileName = Path.GetFileName(photoImg.FileName);
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photoImg.CopyTo(fileStream);
                    }

                    // Set the image file path in the client object
                    c.photo = fileName;
                }

                // Add the client to the database
                clientService.Add(c);

                // Redirect to the Index action method
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // If an error occurs, add the error message to ModelState and return the View with the client object
                ModelState.AddModelError("", "An error occurred while adding the client: " + ex.Message);
                return View(c);
            }
        }



        // GET: CLientController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(clientService.Get(id));
        }

        // POST: CLientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CLient c)
        {
            try
            {var clinet=clientService.Get(id);
                clinet = c;

                clientService.Update(clinet);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CLientController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(clientService.Get(id));
        }

        // POST: CLientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {var c = clientService.Get(id);
                clientService.Delete(c);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
