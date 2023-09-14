using Lab.Demo.Entities;
using Lab.EF.Logic;
using Lab.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic logic = new ShippersLogic();
        // GET: Shippers
        public async Task<ActionResult> Index()
        {
            List<Shippers> shippers = await logic.GetAllAsync();

            List<ShippersView> shippersView = shippers.Select(s => new ShippersView
            {
                Id = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();

            return View(shippersView);
        }

        public ActionResult Insert()
        {
            ViewBag.Message = "Insert";
            var shippersView = new ShippersView { IsInsert = true };
            return View(shippersView);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ShippersView shippersView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shippers shippersEntity = new Shippers
                    {
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone,
                    };

                    await logic.AddAsync(shippersEntity);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
            await logic.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            Shippers shippersUpdate = logic.GetById(id);
            ShippersView shippersView = new ShippersView
            {
                Id = shippersUpdate.ShipperID,
                CompanyName = shippersUpdate.CompanyName,
                Phone = shippersUpdate.Phone,
            };
            ViewBag.Message = "Update";
            return View("Insert", shippersView);
        }

        [HttpPost]
        public async Task<ActionResult> Update(ShippersView shippersView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Shippers shippers = new Shippers
                    {
                        ShipperID = shippersView.Id,
                        CompanyName = shippersView.CompanyName,
                        Phone = shippersView.Phone,
                    };
                    await logic.UpdateAsync(shippers);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}