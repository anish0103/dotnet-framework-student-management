using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebModel.StudentModel;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.GetAsync("Students");
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                var data = responseData.Content.ReadAsAsync<List<Student>>();
                data.Wait();

                var processedData = data.Result;
                return View(processedData);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.GetAsync("Students/"+id);
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                var data = responseData.Content.ReadAsAsync<Student>();
                data.Wait();

                var processedData = data.Result;
                return View(processedData);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Student studentData, int id)
        {
            studentData.id = id;
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.PutAsJsonAsync("Students", studentData);
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student studentData)
        {
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.PostAsJsonAsync("Students", studentData);
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.GetAsync("Students/" + id);
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                var data = responseData.Content.ReadAsAsync<Student>();
                data.Wait();

                var processedData = data.Result;
                return View(processedData);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(Student studentData, int id)
        {
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["backendString"] + "/api/Students");
            var response = client.DeleteAsync("Students/" +id);
            response.Wait();

            var responseData = response.Result;
            if (responseData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}