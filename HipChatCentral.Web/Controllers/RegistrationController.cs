using System;
using System.Linq;
using System.Web.Mvc;
using HipChatCentral.Domain.Data.Contexts;
using HipChatCentral.Domain.Interfaces;
using HipChatCentral.Domain.Models;
using HipChatCentral.Domain.Models.ViewModels;
using HipChatCentral.Domain.Services;

namespace HipChatCentral.Web.Controllers
{    
    public class RegistrationController : Controller
    {
        private HipChatCentralContext _hipChatCentralContext;
        private IRepository<Registration> _registrationRepository; 

        //
        // GET: /SignUp/


        public RegistrationController (IRepository<Registration> _repository)
        {
            _registrationRepository = _repository;
        }

        public ActionResult Index()
        {
            return View(@"~\Views\Registration\Index.cshtml");
        }

        //
        // GET: /SignUp/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SignUp/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SignUp/Create


        [HttpPost]
        public ActionResult Create (RegistrationViewModel newRegistrationViewModel)
        {
            ValidateModel(newRegistrationViewModel);

            if (!ModelState.IsValid)
                return View(@"~\Views\Registration\Index.cshtml", newRegistrationViewModel);
            
            try
            {                               
 
                var registration = new Registration()
                                       {
                                           UserName = newRegistrationViewModel.UserName,
                                           Password = newRegistrationViewModel.Password
                                       };
                
                _registrationRepository.Insert(registration);
                _registrationRepository.SaveChanges();
                return RedirectToAction("Details", "Admin", new {Id = registration.Id});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Entry", ex);
                return View(@"~\Views\Registration\Index.cshtml");
            }
        }

        //
        // GET: /SignUp/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SignUp/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SignUp/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SignUp/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

         private void ValidateModel (RegistrationViewModel registrationViewModel)
         {
             if (String.IsNullOrWhiteSpace(registrationViewModel.UserName))
                 ModelState.AddModelError("Username", "Username Is Required");
             if (registrationViewModel.Password != registrationViewModel.PasswordReEntry)
                 ModelState.AddModelError("Password", "Passwords Much Match");
             else
                if (registrationViewModel.Password.Length < 6)
                   ModelState.AddModelError("Password", "Password Must Be At Least 6 Characters");

             
             var matching = _registrationRepository.GetCollection(x => x.UserName == registrationViewModel.UserName);             
             
             if (matching.Any())
             {
                 ModelState.AddModelError("Username", "Username Is Already Taken");
             }            
         }
    }
}
