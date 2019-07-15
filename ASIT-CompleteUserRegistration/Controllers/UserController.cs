using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASIT_CompleteUserRegistration.Repository;
using ASIT_CompleteUserRegistration.ViewModels;
using Microsoft.Ajax.Utilities;
using Models.ViewModels;

namespace ASIT_CompleteUserRegistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string searchString)
        {
            var userRepo = new UserRepository();
            List<UserDisplayViewModel> users = new List<UserDisplayViewModel>();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                users = userRepo.SearchUsersByName(searchString);
            }
            else
            {
                users = userRepo.GetUsers();
            }
            
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Registration
        public ActionResult Registration()
        {
            var userRepo = new UserRepository();
            var regiUser = userRepo.Registration();
            return View(regiUser);
        }

        

        // POST: User/Registration
        [HttpPost]
        public ActionResult Registration(UserEditViewModel editUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new UserRepository();
                    bool saved = repo.SaveUser(editUser);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }

                throw new ApplicationException("Invalid model");
            }
            catch(ApplicationException ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult GetDistricts(string divisionId)
        {
            if (!string.IsNullOrWhiteSpace(divisionId))
            {
                var disRepo = new DistrictRepository();
                IEnumerable<SelectListItem> districts = disRepo.GetDistricts(int.Parse(divisionId));

                return Json(districts, JsonRequestBehavior.AllowGet);
            }

            return null;
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var repo = new UserRepository();
            var user = repo.GetUser(id);
            return View(user);
            
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserEditViewModel editUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new UserRepository();
                    bool saved = repo.UpdateUser(id,editUser);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }

                throw new ApplicationException("Invalid model");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var repo = new UserRepository();
                repo.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var repo = new UserRepository();
                repo.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        
}
}
