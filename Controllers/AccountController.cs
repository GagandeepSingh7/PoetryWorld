using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginPageContext context;
        public AccountController(LoginPageContext context)
        {
            this.context=context;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Employee employeeModel)
        {
            var requestUrl = "https://localhost:7153/api/Login/Register";
            using (var client = new HttpClient())
            {
                var requestContent = new StringContent(JsonConvert.SerializeObject(employeeModel), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                    // The POST request was successful, handle the response if necessary

                    ViewBag.message = "The user is saved successfully ! Click on Login Button below";
                    
                     return RedirectToAction("Index", "Home");
                   
                }
                else
                {
                    // The POST request failed, handle the error if necessary

                    ViewBag.ErrorMessage = "Invalid Details";
                    // Return the view with the ViewBag object
                    return View("Index");
                }

            }
        }

            //if (ModelState.IsValid)

            //{

            //    LoginPageContext _empoyeeContext = new LoginPageContext();

            //    var status = _empoyeeContext.UserRegisters.Where(

            //        m => m.Username == employeeModel.Username

            //         ).FirstOrDefault();



            //    if (status == null)

            //    {

            //        var data = new UserRegister()

            //        {

            //            Username = employeeModel.Username,

            //            FirstName = employeeModel.FirstName,

            //            LastName  = employeeModel.LastName,

            //            Password = employeeModel.Password,



            //        };

            //        context.UserRegisters.Add(data);

            //        context.SaveChanges();

            //        ViewBag.LoginExistsorNot = 0;

            //        ViewBag.message = "The user is saved successfully ! Click on Login Button below";
            //        if (ViewBag.Condition==1)
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }

            //        return View();

            //    }

            //    else

            //    {



            //        ViewBag.message = "User is already exists!";

            //        ViewBag.LoginExistsorNot = 0;

            //        return View();

            //    }

            //}



            //return View();
            ////    if (ModelState.IsValid)
            //    {
            //        LoginPageContext loginPageContext = new LoginPageContext();
            //        var status = loginPageContext.LoginPages.Where(

            //        m => m.Username == employeeModel.Username

            //                        &&

            //        m.Password == employeeModel.Password).FirstOrDefault();


            //        if (status == null)

            //        {
            //            var data = new UserRegister()
            //            {
            //                Username = employeeModel.Username,
            //                Password = employeeModel.Password,
            //                FirstName = employeeModel.FirstName,
            //                LastName = employeeModel.LastName,
            //            };
            //            context.UserRegisters.Add(data);
            //            context.SaveChanges();
            //            //ViewBag.LoginExistsorNot = 0;

            //            //ViewBag.message = "The user is saved successfully";
            //            //ViewBag.Message = "Your Data has been recorded ! You can successfully Login.";

            //        }





            //    }
            //    else
            //    {


            //        //ViewBag.LoginExistsorNot = 0;
            //        ViewBag.Message = "Both Passwords must be same ! ";
            //        return View(employeeModel);
            //    }
            //    return View();
            //}

        }
}
    
