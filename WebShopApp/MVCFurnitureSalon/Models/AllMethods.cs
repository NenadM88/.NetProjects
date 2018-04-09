using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCFurnitureSalon.Models
{
    public class AllMethods
    {
        public List<FurnitureModel> GetAllFurniture()
        {

            List<FurnitureModel> lista = new List<FurnitureModel>();
            string path = HttpContext.Current.Server.MapPath("~/Furniture.txt");

            if (File.Exists(path))
            {
                string line = string.Empty;
                string[] array;

                using (StreamReader sr = new StreamReader(path))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == string.Empty)
                        {
                            continue;
                        }                           
                        array = line.Split(',');
                        FurnitureModel furniture = new FurnitureModel();

                        try
                        {
                            furniture.ID = int.Parse(array[0]);
                            furniture.Name = array[1];
                            furniture.Colour = array[2];
                            furniture.OriginCountry = array[3];
                            furniture.ManufacturerName = array[4];
                            furniture.Price = double.Parse(array[5]);
                            furniture.Quantity = int.Parse(array[6]);
                            furniture.Category = array[7];
                            furniture.ProductionYear = int.Parse(array[8]);
                            furniture.SalonName = array[9];
                            //komadNamestaja.Picture = null;
                            lista.Add(furniture);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                            return null;
                        }
                    }
                }
            }
            return lista;
        }

        public List<FurnitureModel> AddFurniture(FurnitureModel furniture)
        {
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = GetAllFurniture();
            FurnitureModel newFurniture = new FurnitureModel();
            
            newFurniture.Name = furniture.Name;
            newFurniture.Colour = furniture.Colour;
            newFurniture.OriginCountry = furniture.OriginCountry;
            newFurniture.ManufacturerName = furniture.ManufacturerName;
            newFurniture.Price = furniture.Price;
            newFurniture.Quantity = furniture.Quantity;
            newFurniture.Category = furniture.Category;
            newFurniture.ProductionYear = furniture.ProductionYear;
            newFurniture.SalonName = furniture.SalonName;
            list.Add(newFurniture);

            string path = HttpContext.Current.Server.MapPath("~/Furniture.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    sw.WriteLine(item.ID + "," + item.Name + "," + item.Colour + "," + item.OriginCountry + "," + item.ManufacturerName + ","
                        + item.Price + "," + item.Quantity + "," + item.Category + "," + item.ProductionYear + "," + item.SalonName);
                }
            }
            return list;
        }

        public FurnitureModel GetOneFurniture(int furnitureID)
        {
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = GetAllFurniture();
            FurnitureModel furniture = (from fur in list where fur.ID == furnitureID select fur).First();
            return furniture;
        }

        public void DeleteFurniture(int? furnitureID)
        {
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = GetAllFurniture();

            FurnitureModel furnitureToDelete = (from fur in list where fur.ID == furnitureID select fur).First();
            list.Remove(furnitureToDelete);

            string path = HttpContext.Current.Server.MapPath("~/Furniture.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    sw.WriteLine(item.ID + "," + item.Name + "," + item.Colour + "," + item.OriginCountry + "," + item.ManufacturerName + ","
                        + item.Price + "," + item.Quantity + "," + item.Category + "," + item.ProductionYear + "," + item.SalonName);
                }
            }
        }

        public List<FurnitureModel> EditFurniture(FurnitureModel furniture)
        {
            List<FurnitureModel> list = new List<FurnitureModel>();
            list = GetAllFurniture();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == furniture.ID)
                {
                    list[i].ID = furniture.ID;
                    list[i].Name = furniture.Name;
                    list[i].Colour = furniture.Colour;
                    list[i].OriginCountry = furniture.OriginCountry;
                    list[i].ManufacturerName = furniture.ManufacturerName;
                    list[i].Price = furniture.Price;
                    list[i].Quantity = furniture.Quantity;
                    list[i].Category = furniture.Category;
                    list[i].ProductionYear = furniture.ProductionYear;
                    list[i].SalonName = furniture.SalonName;
                }
            }
            string path = HttpContext.Current.Server.MapPath("~/Furniture.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    sw.WriteLine(item.ID + "," + item.Name + "," + item.Colour + "," + item.OriginCountry + "," + item.ManufacturerName + ","
                        + item.Price + "," + item.Quantity + "," + item.Category + "," + item.ProductionYear + "," + item.SalonName);
                }
            }
            return list;
        }

        public List<User> GetAllUser()
        {
            List<User> list = new List<User>();
            string path = HttpContext.Current.Server.MapPath("~/Users.txt");

            if (File.Exists(path))
            {
                string line = string.Empty;
                string[] array;

                using (StreamReader sr = new StreamReader(path))
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == string.Empty)
                        {
                            continue;
                        }
                        array = line.Split(',');
                        User user = new User();

                        try
                        {
                            user.UserName = array[0];
                            user.Password = array[1];
                            user.Name = array[2];
                            user.LastName = array[3];
                            user.Role = array[4];
                            user.Number = array[5];
                            user.Email = array[6];
                            list.Add(user);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                            return null;
                        }
                    }
                }
            }
            return list;
        }

    }
}