using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewTask.Models;

namespace InterviewTask.ViewModels
{
    public class HelperServiceViewModel
    {
        public List<HelperServiceModel> HelperServiceList { get; set; }
        public int Open;
        public int Close;
    }
}