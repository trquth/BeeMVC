using BeeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeeMVC.Function;

namespace BeeMVC.Controllers
{
    public class BeeManagerController : Controller
    {
        #region Variables
        String[] BEE_NAME = { "Worker", "Queen", "Drone" };
        private BeeManager beeManager;
        private Random random;
        public BeeManagerController()
        {
            beeManager = new BeeManager();
            random = new Random();
        }
        #endregion
        #region Methods
        private List<Bee> CreateNewList()
        {
            var model = beeManager.InitializeList(random);
            return model;
        }

        private List<Bee> DamageAll(List<Bee> item)
        {
            var model = beeManager.DamageAll(item, random);
            return model;

        }
        #endregion
        #region Action
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Tao danh sach ngau nhien 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateBee()
        {
            Session.RemoveAll();
            var model = CreateNewList();
            var list = from bee in model
                       select new BeeViewModel
                       {
                           BeeName = BEE_NAME[bee.beeType],
                           Health1 = (decimal)bee.health,
                           Dead = bee.isDeath() ? "Yes" : "No",

                       };
            Session["BEES"] = model;
            return PartialView("ListBeePartialView", list);
        }
        /// <summary>
        /// Ham Demage 
        /// </summary>
        /// <returns></returns>
        public ActionResult DemageBee()
        {
            var items = Session["BEES"] as List<Bee>;
            Session.RemoveAll();
            var model = DamageAll(items);
            var list = from bee in model
                       select new BeeViewModel
                       {
                           BeeName = BEE_NAME[bee.beeType],
                           Health1 = (decimal)bee.health,
                           Dead = bee.isDeath() ? "Yes" : "No",

                       };
            Session["BEES"] = model;
            return PartialView("ListBeePartialView", list);
        }
        /// <summary>
        /// Luu vao database
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveBees()
        {
            var items = Session["BEES"] as List<Bee>;
            if (items == null)
            {
                return PartialView("ListBeePartialView");
            }
            else
            {
                var list = from bee in items
                           select new BeeViewModel
                           {
                               BeeName = BEE_NAME[bee.beeType],
                               Health1 = (decimal)bee.health,
                               Dead = bee.isDeath() ? "Yes" : "No",
                           };
                var model = from bee in list
                            select new BeeData
                            {
                                BeeName = bee.BeeName,
                                Health = bee.Health1,
                                Dead = bee.Dead
                            };
                using (var context = new BEEContext())
                {
                    var data = context.BeeDatas;
                    int i = data.Count();
                    try
                    {
                        if (i == 0)
                        {
                            foreach (var item in model)
                            {
                                context.BeeDatas.Add(item);
                            }
                        }
                        else
                        {
                            context.BeeDatas.RemoveRange(data);
                            foreach (var item in model)
                            {
                                context.BeeDatas.Add(item);
                            }
                        }
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return PartialView("ListBeePartialView", list);
                }
            }
        }
        /// <summary>
        /// Load tu database len
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadBees()
        {
            var context = new BEEContext();
            try
            {
                var model = context.BeeDatas;
                int i = model.Count();
                if (i == 0)
                {
                    return PartialView("ListBeePartialView");
                }
                else
                {
                    var list = from bee in model
                               select new BeeViewModel
                               {
                                   BeeName = bee.BeeName,
                                   Health1 = (decimal)bee.Health,
                                   Dead = bee.Dead,

                               };
                    return PartialView("ListBeePartialView", list);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
