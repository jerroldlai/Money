using Money.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Money.Controllers
{
    public class MoneyController : Controller
    {
        
          
        // GET: Money
        public ActionResult Money()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
        listItems.Add(new SelectListItem
            {
                Text = "請選擇",
                Value = "請選擇"
            });

            listItems.Add(new SelectListItem
            {
                Text = "收入",
                Value = "收入"
            });
            listItems.Add(new SelectListItem
            {
                Text = "支出",
                Value = "支出",
            });
            ViewBag.CategroyItems = listItems;
            return View();
            
        }
        
        public ActionResult List(MoneyViewModel pagedata)
        {
            var source = new List<MoneyViewModel>();
            if (pagedata.category!= null || 
                pagedata.money != null ||
                pagedata.description != null ||
                pagedata.date != null)
            {
                source.Add(new MoneyViewModel
                {
                    no = source.Count,
                    category =pagedata.category,
                    money =pagedata.money,
                    date =pagedata.date,
                    description =pagedata.description,
                });
            }

            for (int i = 0; i < 5; i++)
            {
                source.Add(new MoneyViewModel
                {
                    no = i,
                    category = "支出",
                    money = System.Convert.ToString(123 * i),
                    date = DateTime.Now.AddDays(i+1).ToString("yyyy-MM-dd"),
                    description = "",
                });
            }
            return View(source);
        }
    }
}