using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebModel.StudentModel;

namespace WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        StudentDBContext db = new StudentDBContext();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Student> list = new List<Student>();
                list = db.Students.ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var student = db.Students.Find(id);
                if (student == null) return BadRequest("User Not Found");
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(Student studentData)
        {
            try
            {
                db.Students.Add(studentData);
                db.SaveChanges();
                return Created(Request.RequestUri, studentData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(Student studentData)
        {
            try
            {
                db.Students.AddOrUpdate(studentData);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var student = db.Students.Find(id);
                if (student == null) return BadRequest("User Not Found");
                db.Students.Remove(student);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
