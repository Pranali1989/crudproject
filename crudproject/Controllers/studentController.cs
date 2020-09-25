
using System;
using crudproject.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudproject.Controllers
{
    public class StudentController : Controller
    {
        // GET: student
        db_studentinfoEntities1 dbobj = new db_studentinfoEntities1();

        public ActionResult student(tb_Student obj)
        {
            
                 return View(obj);
        }
         
        [HttpPost]

        public ActionResult Addstudent(tb_Student model)
        {
            tb_Student obj = new tb_Student();
            if (ModelState.IsValid)
            {

                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.Id == 0)
                {

                    dbobj.tb_Student.Add(obj);
                    dbobj.SaveChanges();

                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }

            }

                ModelState.Clear();

                return View("student");
            
        }
        public ActionResult studentList()
        {
            var res = dbobj.tb_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tb_Student.Where(x => x.Id == id).First();
            dbobj.tb_Student.Remove(res);
            dbobj.SaveChanges();

            var list = dbobj.tb_Student.ToList();

            return View("studentList", list);

        }
    }


}