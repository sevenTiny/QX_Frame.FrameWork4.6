﻿using QX_Frame.App.Web;
using QX_Frame.Data.Entities;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service;
using QX_Frame.Helper_DG.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QX_Frame.Web.Controllers
{
    public class DefaultController : WebControllerBase
    {
        // GET: Default
        public ActionResult Index()
        {
            //throw new Exception_DG_Internationalization(9999);
            return View();
        }


        public JsonResult GetJson()
        {
            using (var fact = Wcf<PeopleService>())
            {
                var channel = fact.CreateChannel();

                List<V_People> poepleList = channel.QueryAll(new V_PeopleQueryObject()).Cast<List<V_People>>();

                return Json_DG(poepleList);
            }
        }
    }
}