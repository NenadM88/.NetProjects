using MVCFurnitureSalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFurnitureSalon.Controllers
{
    public class FurnitureController : Controller
    {
        //List for shoppingCart
        public static List<FurnitureModel> shoppingList = new List<FurnitureModel>();

        // GET: Furniture
        public ActionResult Index(string searchBy, string search)
        {
            AllMethods allMet = new AllMethods();
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = allMet.GetAllFurniture();

            if (searchBy == "Name")
            {
                return View(list.Where(x => (x.Name.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.Name.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "Colour")
            {
                return View(list.Where(x => (x.Colour.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.Colour.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "OriginCountry")
            {
                return View(list.Where(x => (x.OriginCountry.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.OriginCountry.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "ManufacturerName")
            {
                return View(list.Where(x => (x.ManufacturerName.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.ManufacturerName.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "Price")
            {
                return View(list.Where(x => x.Price.ToString() == search || search == null).ToList());
            }
            else if (searchBy == "Quantity")
            {
                return View(list.Where(x => x.Quantity.ToString() == search || search == null).ToList());
            }
            else if (searchBy == "Category")
            {
                return View(list.Where(x => (x.Category.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.Category.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "ProductionYear")
            {
                return View(list.Where(x => x.ProductionYear.ToString() == search || search == null).ToList());
            }
            else if (searchBy == "SalonName")
            {
                return View(list.Where(x => (x.SalonName.ToLower()).StartsWith(search.ToLower()) ||
                                            (x.SalonName.ToLower()).Contains(search.ToLower()) || search == null).ToList());
            }
            else
            {
                return View(list);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, Name, Colour, OriginCountry, ManufacturerName, Price, Quantity, Category, ProductionYear, SalonName")] 
            FurnitureModel furniture)
        {
            AllMethods allMet = new AllMethods();
            allMet.AddFurniture(furniture);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AllMethods allMet = new AllMethods();
            FurnitureModel fur = allMet.GetOneFurniture(id);
            return View(fur);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            AllMethods allMet = new AllMethods();
            allMet.DeleteFurniture(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            AllMethods allMet = new AllMethods();
            FurnitureModel fur = allMet.GetOneFurniture(id);
            return View(fur);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, Name, Colour, OriginCountry, ManufacturerName, Price, Quantity, Category, ProductionYear, SalonName")]
            FurnitureModel furniture)
        {
            AllMethods allMet = new AllMethods();
            allMet.EditFurniture(furniture);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            AllMethods allMet = new AllMethods();
            FurnitureModel fur = allMet.GetOneFurniture(id);
            return View(fur);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {    
            AllMethods allMet = new AllMethods();
            FurnitureModel fur = allMet.GetOneFurniture(id);
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = allMet.GetAllFurniture();
            int sum;
            if (fur.Quantity >= 1)
            {
                sum = fur.Quantity - (fur.Quantity - 1);
                fur.Quantity = sum;
                shoppingList.Add(fur);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Quantity = list[i].Quantity - 1;
                }

                list = allMet.GetAllFurniture();
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OpenCart()
        {
            return View(shoppingList);
        }

        
        public ActionResult DeleteFromCart(int? id)
        {
            for (int i = 0; i < shoppingList.Count; i++)
            {
                if (shoppingList[i].ID == id)
                {
                    shoppingList.Remove(shoppingList[i]);
                }
            }
            return View("OpenCart", shoppingList);
        }

    }
}