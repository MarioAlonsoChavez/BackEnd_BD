using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {
                //select * from alumnos;
                return View(dbProfesor.Profesor.ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {
                Profesor profe = dbProfesor.Profesor.Find(id);
                if (profe == null)
                {
                    return HttpNotFound();
                }
                return View(profe);


            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Profesor profe)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {
                dbProfesor.Profesor.Add(profe);
                dbProfesor.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {

                return View(dbProfesor.Profesor.Where(x => x.Matricula == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(Profesor profe)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {

                dbProfesor.Entry(profe).State = EntityState.Modified;
                dbProfesor.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {

                return View(dbProfesor.Profesor.Where(x => x.Matricula == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(Profesor profe, int? id)
        {
            using (AlumnoDbContext dbProfesor = new AlumnoDbContext())
            {
                Profesor prof = dbProfesor.Profesor.Where(x => x.Matricula == id).FirstOrDefault();
                dbProfesor.Profesor.Remove(prof);
                dbProfesor.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}