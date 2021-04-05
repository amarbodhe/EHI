using EHI.DA;
using EHI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EHI.Controllers
{
    public class ContactController : Controller
    {

        private IContactRepository _iContactRepository;
        private Contact contact = new Contact();
        public ContactController(IContactRepository iContactRepository)
        {
            _iContactRepository = iContactRepository;
           
        }
        // GET: Contact
        public ActionResult Index()

        {
            contact.Mode = 1;
            var data = _iContactRepository.Contact_DS(contact);
            return View(data);
        }
        

        // GET: Contact/Create
        public ActionResult AddContact()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.Mode = 4;

                    if (_iContactRepository.Contact_DM(contact) == 200)
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Something is wrong";
                    }
                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Something is wrong";
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult EditContact(int id)
        {
            return View(_iContactRepository.Contact_DQ(1,id)); 
            
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult EditContact(int id, Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contact.Mode = 16;

                    if (_iContactRepository.Contact_DM(contact) == 200)
                    {
                        ViewBag.Message = "Employee details edit successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Something is wrong";
                    }
                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Something is wrong";
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult DeleteContact(int id)
        {
            try
            {
                contact.Mode = 8;
                contact.Id = id;
                if (_iContactRepository.Contact_DM(contact) == 200)
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
