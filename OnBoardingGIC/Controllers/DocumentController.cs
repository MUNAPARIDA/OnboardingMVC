using HelloSign;
using Microsoft.AspNet.Identity;
using OnBoardingGIC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.DirectoryServices.Protocols;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnBoardingGIC.Controllers
{
    public class DocumentController : Controller
    {

        protected string HelloSignAPIKey = "22d0e01c1614cb634f1590fcf79bafde6467186db77cad6b3d93fd994b53285a";
        protected string HelloSignClientID = "8702a7cb0eb5127fc40232f33e019a49";

        private ApplicationDbContext db = new ApplicationDbContext();

       // [Authorize]
        public ActionResult Upload()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload([Bind(Exclude = "UserID, tenStandard,twelveStandard")] Models.Document document)
        {
               
            byte[] imageData = null;
            byte[] imageData2 = null;

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["tenStandard"];
                HttpPostedFileBase poImgFile2 = Request.Files["twelveStandard"];


                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);

                }
                using (var binary = new BinaryReader(poImgFile2.InputStream))
                {
                    imageData2 = binary.ReadBytes(poImgFile2.ContentLength);

                }

            }
            document.UserID = User.Identity.GetUserId();
            document.tenStandard = imageData;
            document.twelveStandard = imageData2;
            db.Documents.Add(document);
            db.SaveChanges();


            //DIGITAL SIGN CODE
            var client = new Client(HelloSignAPIKey);
            var request = new SignatureRequest();
            request.Subject = "Mandatory Documents";
            request.Message = "Sample Message";
            request.AddSigner("parida.suraj.26@gmail.com", "Muna Parida");
            
           /* byte[] arreglo = new byte[Form.File.ContentLength];
            Form.File.InputStream.Read(arreglo, 0, Form.File.ContentLength);*/
            request.AddFile(imageData, "Tenth Standard Certificate");
            request.AddFile(imageData2, "Twelth Standard Certificate");
            request.TestMode = true;
            var response = client.CreateEmbeddedSignatureRequest(request, HelloSignClientID);
            var urlSign = client.GetSignUrl(response.Signatures[0].SignatureId);
           
            return RedirectToAction("Sign", new { url = urlSign.SignUrl });

            //end code



            //return View("SuccessUpload");
        }




        public ActionResult Sign(string url)
        {
            ViewBag.Url = url;
            ViewBag.ClientId = HelloSignClientID;
            return View();
        }


        public ActionResult SuccessUpload()
        {
            return View();
        }
        [Authorize]
        public ActionResult CheckUpload()
        {

            /*string userid = User.Identity.GetUserId();
            try
            {
                userid = db.Documents.FirstOrDefault(m => m.UserID == userid)?.UserID;
            }
            catch 
            {

                userid = null;
                
            }
            
            //userid = User.Identity.GetUserId();
            if(userid == null)
            return View("Upload");
            else
            return View("SuccessUpload");*/


            return View("Upload");
        }



        [HttpGet]
        public FileResult DownLoadFile(string name)
        {
            string userid = User.Identity.GetUserId();
            byte[] sample = null;
            Models.Document doc = db.Documents.Where(m => m.UserID == userid).FirstOrDefault();
            if (name == "docOne")
                return File(doc.tenStandard, "application/pdf");
            else if (name == "docTwo")
                return File(doc.twelveStandard, "application/pdf");
            else
                return File(sample, "application/pdf");




            

        }




        [Authorize]
        public ActionResult CheckStatus()
        {

            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);

            /*try
            {
                LdapConnection ldapConnection = new LdapConnection("35.225.172.253:10389");
                var networkCredential = new NetworkCredential(
                      "CN=Gic.test,dc=onboard,dc=gic",
                      "welcome@123");
                ldapConnection.SessionOptions.ProtocolVersion = 3;
                ldapConnection.AuthType = AuthType.Basic;
                ldapConnection.Bind(networkCredential);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }*/


            if (user.Accepted == true)
            {
                ViewBag.Status = true; 
            }
            else
            {
                ViewBag.Status = false;

            }
            return View();
        }


        public ActionResult ConfirmReject()
        {
            
            return View();
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("ConfirmReject")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmRejectH()
        {
            var userid = User.Identity.GetUserId();
            var cart = db.Users.Find(userid);
            cart.Accepted = false;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
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