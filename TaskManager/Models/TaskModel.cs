using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskModel
    {
        public int id {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime due_date { get; set; }
        public int status { get; set; }
        public string remarks {  get; set; }
        public DateTime? create_on {  get; set; }
        public DateTime? update_on { get; set; }
        public string created_by {  get; set; }
        public string updated_by { get; set; }



    }
}