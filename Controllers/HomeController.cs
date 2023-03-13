using System.Diagnostics;
using System.Text;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Login.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private string baseURL = "https://localhost:7231/";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Success()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //Calling the webapi and populating the data in view using data table

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync("https://localhost:7153/api/Login");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                // Do something with the response content
            }
            // nothing
        }

        var employee = new Employee();

        return View(employee);
    }


    [HttpPost]
    public async Task<IActionResult> Index(Employee employee)
    {
        var requestUrl = "https://localhost:7153/api/Login/Validate";

        using (var client = new HttpClient())
        {
            var requestContent =
                new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, requestContent);

            if (response.IsSuccessStatusCode)
                // The POST request was successful, handle the response if necessary
                return RedirectToAction("Success", "Home");
            // The POST request failed, handle the error if necessary

            ViewBag.ErrorMessage = "Invalid Details";
            // Return the view with the ViewBag object
            return View("Index");
        }
    }

    //public IActionResult Register(Employee employeeModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var data = new Employee()
    //        {
    //            Username = employeeModel.Username,
    //            Password = employeeModel.Password,
    //            FirstName = employeeModel.FirstName,
    //            LastName = employeeModel.LastName,
    //        };


    //        return View(employeeModel);
    //    }
    //    else
    //    {
    //        TempData["errorMessage"] = "Empty form cannot be submitted ! ";
    //        return View(employeeModel);
    //    }
    //    //return View();
    //}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public override bool Equals(object? obj)
    {
        return obj is HomeController controller &&
               EqualityComparer<ILogger<HomeController>>.Default.Equals(_logger, controller._logger);
    }
}