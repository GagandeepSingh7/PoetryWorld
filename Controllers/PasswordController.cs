using System.Text;
using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Login.Controllers;

public class PasswordController : Controller
{
    private readonly LoginPageContext _context;

    public PasswordController(LoginPageContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Password()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> PasswordVerify(EmailDto employeeModel)
    {
        var requestUrl = "https://localhost:7153/api/Email";
        using (var client = new HttpClient())
        {
            var requestContent = new StringContent(JsonConvert.SerializeObject(employeeModel), Encoding.UTF8,
                "application/json");
            var response = await client.PostAsync(requestUrl, requestContent);

            if (response.IsSuccessStatusCode)
            {
                // The POST request was successful, handle the response if necessary

                ViewBag.message = "Link Sent";

                return RedirectToAction("Index", "Home");
            }

            // The POST request failed, handle the error if necessary

            ViewBag.ErrorMessage = "Invalid Details";
            // Return the view with the ViewBag object
            return View("Password");
        }
    }
}