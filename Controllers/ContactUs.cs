using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace InsuranceWebApps.Controllers
{
    public class ContactUsController : Controller
    {
        [HttpPost]
        public ActionResult SendMessage(InsuranceWebApps.Models.ContactUs model)
        {
            if (ModelState.IsValid)
            {
                MailMessage mess = new MailMessage();
                mess.From = new MailAddress(model.Email);
                mess.To.Add("youremail@example.com");
                mess.Subject = model.Subject;
                mess.Body = "Name: " + model.Name + "<br> Email: " + model.Email + "<br><br> Comment: " + model.Message;
                mess.Priority = MailPriority.Normal;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("youremail@example.com", "yourpassword");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;

                try
                {
                    client.Send(mess);
                    return RedirectToAction("Index", "Home", new { message = "Your message has been sent successfully!" });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error: " + ex.Message);
                }
            }

            return View(model);
        }
    }
}