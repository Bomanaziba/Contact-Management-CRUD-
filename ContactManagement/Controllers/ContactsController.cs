using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManagement.Domain;
using ContactManagement.Repository;
using ContactManagement.Interface;
using System.Web.Security;
using ContactManagement.Common;

namespace ContactManagement.Controllers
{
    //[AccessDeniedAuthorizationAttribute(Roles = "Administrator")]

    public class ContactsController : Controller
    {
        private IContact contactRepository;


        int request = 0;
        bool success = false;

        public ContactsController(IContact contact)
        {
            this.contactRepository = contact;
        }

        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoadContactData()
        {
             var data = (from contact in contactRepository.Contacts
                        select new
                        {
                            contact.ContactID,
                            contact.LastName,
                            contact.FirstName,
                            contact.Name,
                            contact.Phone,
                            contact.Email,
                            contact.DateCreated
                        }).OrderBy(a => a.LastName).ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.Get(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public PartialViewResult Create()
        {
            return PartialView("_CreateModalView");
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    contact.ImageMimeType = image.ContentType;
                    contact.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(contact.ImageData, 0, image.ContentLength);
                }
                contactRepository.Add(contact);
                contactRepository.SaveChanges();
                
                success = true;
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public PartialViewResult Edit(int id)
        {
            ViewBag.ContactID = id;

            Contact contact = contactRepository.Get(id);

            return PartialView("_EditModalView", contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    contact.ImageMimeType = image.ContentType;
                    contact.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(contact.ImageData, 0, image.ContentLength);
                }

                contactRepository.Update(contact);
                request = 1;
                contactRepository.SaveChanges();
                success = true;
                return RedirectToAction("Index");

            }
            
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [HttpGet]
        public PartialViewResult Delete(int id)
        {
            ViewBag.ContactID = id;

            Contact contact = contactRepository.Get(id);

            return PartialView("_DeleteModalView", contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.ContactID = id;
            Contact contact = contactRepository.Get(id);
            contactRepository.Delete(id);
            contactRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetThumbnailImage(int contactId)
        {
            Contact contact = contactRepository.Contacts.FirstOrDefault(x => x.ContactID == contactId);
            if (contact != null)
            {
                return File(contact.ImageData, contact.ImageMimeType.ToString());
            }
            else
            {
                return null;
            }
        }

        public PartialViewResult Report(string message, int status)
        {
            ViewBag.Message = message;
            ViewBag.Status = status;
            return PartialView("_SuccessPartialModal");
        }
    }

}
