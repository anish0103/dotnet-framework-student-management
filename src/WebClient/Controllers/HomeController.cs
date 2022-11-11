using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebClient.Wrapper;
using WebModel.StudentModel;

//ReadAsAsync, PostAsJsonAsync, DeleteAsync and PutAsJsonAsync is available in Microsoft.AspNet.WebApi.Client

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                IEnumerable<Student> students = consumeAPI.generaticReadAsAsyncs("Students");
                return View(students);
            }
        }

        public ActionResult Edit(int id)
        {
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                Student student = consumeAPI.generaticReadAsAsync("Students/" + id);
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student studentData, int id)
        {
            studentData.id = id;
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                Student student = consumeAPI.generaticPutAsJsonAsync("Students", studentData);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student studentData)
        {
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                Student student = consumeAPI.generaticPostAsJsonAsync("Students", studentData);
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(int id)
        {
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                Student student = consumeAPI.generaticReadAsAsync("Students/" + id);
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Delete(Student studentData, int id)
        {
            using (ConsumeAPI<Student> consumeAPI = new ConsumeAPI<Student>())
            {
                Student student = consumeAPI.generaticDeleteAsync("Students/" + id);
                return RedirectToAction("Index");
            }
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