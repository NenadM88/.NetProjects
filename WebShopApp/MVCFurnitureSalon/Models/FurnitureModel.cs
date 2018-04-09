using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFurnitureSalon.Models
{
    public class FurnitureModel
    {
        private int id;
        private string name;
        private string colour;
        private string originCountry;
        private string manufacturerName;
        private double price;
        private int quantity;
        private string category;
        private int productionYear;
        private string salonName;
        private string picture;

        private static int counterId = 1;

        //Konstruktori
        public FurnitureModel()
        {
            this.id = counterId;
            counterId++;
        }

        //Property
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public string OriginCountry
        {
            get { return originCountry; }
            set { originCountry = value; }
        }
        public string ManufacturerName
        {
            get { return manufacturerName; }
            set { manufacturerName = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public int ProductionYear
        {
            get { return productionYear; }
            set { productionYear = value; }
        }
        public string SalonName
        {
            get { return salonName; }
            set { salonName = value; }
        }
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

    }
}