using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace sun_or_rain.Model
{
    public class Favourite
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Cityname { get; set; }
        public Favourite Copy()
        {
            var newItem = new Favourite();
            newItem.ID = ID;
            if (Cityname != null)
                newItem.Cityname = string.Copy(Cityname);
            return newItem;
        }

        public bool Equals(Favourite other)
        {
            if (other == null)
                return false;
            if (ID == other.ID)
                return true;
            else
                return false;
        }
    }

}
    

