using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Models
{
    public class ResultViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Temp { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
    }


    public class Weather
    {
        public string description { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }


    public class RootObject
    {        
        public List<Weather> weather { get; set; }
        public Main main { get; set; }        
        public string name { get; set; }
    }
}