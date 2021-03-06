using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using OperaWebSite.Controllers;
using OperaWebSite.Data;
using System.Data.Entity;
using OperaWebSite.Models;

using OperaWebSite.Filters;

namespace OperaWebSite.Controllers
{
    [MyFilterAction]

    public class OperaController : Controller
    {
        //Crear instancia del dbcontext

        private OperaDbContext context = new OperaDbContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            //Traer todas las Operas usando EF

            var operas = context.Operas.ToList();

            return View("Index", operas);
        }

        // Creamos dos metodos para la insercion de la opera en la DB 

        // Primer create por GET para retornar la vista de registro
        [HttpGet] // El Get es implicito asi y todo lo podemos indicar
        public ActionResult Create()
        {
            //Creamos la instancia sin valores en las propiedades
            Opera opera = new Opera();

            //Retornamos la vista "Create" que tiene el objeto opera
            return View("Create", opera);
        }

        // Segundo create es por Post para insertar la nueva opera en la base 
        // cuando el usuario en la vista Create hace click en enviar
        //Opera/Create -->POST
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", opera);
        }

        //GET
        // Opera/Detail/id
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
                return HttpNotFound();


        }

        //GET /Opera/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET /Opera/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Edit", opera);
        }


        //TODO Search by year

        
    }
}