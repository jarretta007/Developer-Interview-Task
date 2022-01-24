using System;
using System.Web.Mvc;
using System.Collections.Generic;
using InterviewTask.Services;
using InterviewTask.Models;
using InterviewTask.ViewModels;
using System.Linq;

namespace InterviewTask.Services
{
    public class HelperSetup
    {

        internal static List<HelperServiceModel> Setup(List<string> Weather)
        {
            HelperServiceViewModel ServiceModelVM = new HelperServiceViewModel();
            ServiceModelVM.HelperServiceList = HelperServiceFactory.Create();

            DateTime localDate = DateTime.Now;
            string day = localDate.ToString("dddd");
            int hour = (int)localDate.Hour;
            string getAttribute = day + "OpeningHours";            

            foreach (var i in ServiceModelVM.HelperServiceList)
            {
                dynamic getToday = i.GetType().GetProperty(getAttribute).GetValue(i, null);

                i.Opening = getToday[0];
                i.Closing = getToday[1];

                if (hour < i.Opening || hour > i.Closing)
                {
                    List<int> OpeningTimes = new List<int>();
                    OpeningTimes.Add(i.SundayOpeningHours[0]);
                    OpeningTimes.Add(i.MondayOpeningHours[0]);
                    OpeningTimes.Add(i.TuesdayOpeningHours[0]);
                    OpeningTimes.Add(i.WednesdayOpeningHours[0]);
                    OpeningTimes.Add(i.ThursdayOpeningHours[0]);
                    OpeningTimes.Add(i.FridayOpeningHours[0]);
                    OpeningTimes.Add(i.SaturdayOpeningHours[0]);

                    int dayofweek = (int)localDate.DayOfWeek;

                    foreach (var L in OpeningTimes)
                    {
                        dayofweek = dayofweek + 1;

                        //If closed keep trying to find next DAY that store is open.                         
                        if (OpeningTimes[dayofweek] != 0)
                        {
                            //We now know the Next Day set it and add the time Next Open. 
                            
                            int nextOpen = OpeningTimes[dayofweek];                            
                            string nextDay = ((DayOfWeek)dayofweek).ToString();

                            i.Status = "CLOSED - REOPENS " + nextDay + " at " + nextOpen;
                            break;
                        }
                    }

                    i.background = "bg-color-light-grey";
                    
                }
                else
                {
                    i.Status = "OPEN - OPEN FROM " + i.Opening + " TODAY UNTIL " + i.Closing;
                    i.background = "bg-color-donation-orange";
                }

            }

            if (Weather != null)
            {
                foreach (var i in ServiceModelVM.HelperServiceList)
                {
                    if (i.City == Weather[0])
                    {
                        i.WeatherDescription = Weather[1];
                        i.Temp = Weather[2];
                        i.TempMin = Weather[3];
                        i.TempMax = Weather[4];
                    }
                }
            }

            return ServiceModelVM.HelperServiceList;
        }


    }
}