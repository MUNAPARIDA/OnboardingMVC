using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnBoardingGIC.Models;
using Microsoft.AspNet.Identity;

namespace OnBoardingGIC.Controllers
{
    public class CandidateDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       

        // GET: CandidateDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,UserId,AddressOne,City,State,PostalCode,Skill,Certifications")] CandidateDetail candidateDetail)
        {
              


            if (ModelState.IsValid)
            {
                candidateDetail.UserId = User.Identity.GetUserId();
                db.CandidateDetails.Add(candidateDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Upload","Document");
            }

            return View(candidateDetail);
        }


        



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
