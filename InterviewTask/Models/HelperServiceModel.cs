using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewTask.Models
{
    public class HelperServiceModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber { get; set; }

        public List<int> MondayOpeningHours { get; set; }
        public List<int> TuesdayOpeningHours { get; set; }
        public List<int> WednesdayOpeningHours { get; set; }
        public List<int> ThursdayOpeningHours { get; set; }
        public List<int> FridayOpeningHours { get; set; }
        public List<int> SaturdayOpeningHours { get; set; }
        public List<int> SundayOpeningHours { get; set; }

        public string City { get; set; }
        public string WeatherDescription { get; set; }
        public string Temp { get; set; }
        public string TempMin { get; set; }
        public string TempMax { get; set; }

        [NotMapped]
        public int Opening { get; set; }
        [NotMapped]
        public int Closing { get; set; }
        [NotMapped]
        public string Status { get; set; }
        [NotMapped]
        public string background { get; set; }

    }
}

