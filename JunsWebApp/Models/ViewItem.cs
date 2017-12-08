using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JunsWebApp.Models
{
    public class ViewItem
    {
        public int Id { get; set; }
        public string  Name{ get; set; }
        public string Location { get; set; }
        public int  Rating { get; set; }

        public static List<ViewItem> GetItems()
        {
            return items;
        }

        private static List<ViewItem> items = new List<ViewItem>()
        {
            new ViewItem(){Id = 1,Location = "China",Name="Nurse",Rating = 5},
            new ViewItem(){Id = 2,Location = "Erupe",Name="Burky",Rating = 6},
            new ViewItem(){Id = 3,Location = "Outlus",Name="Chuck",Rating = 3},
            new ViewItem(){Id = 4,Location = "Atlas",Name="Fris",Rating = 3},
            new ViewItem(){Id = 5,Location = "China",Name="Jun",Rating = 9},
            new ViewItem(){Id = 7,Location = "Atlas",Name="Aliris",Rating = 8},
        };
    }

    public class ViewItemDB : DbContext
    {
        public ViewItemDB():base("name=dbconnection2")
        {
            
        }

        public DbSet<ViewItem> Items { get; set; }
    }

}