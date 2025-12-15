using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.ClsTests
{
    public class ClsTestView
    {
        ClsTest clstst= new ClsTest();

        public List<TaskModel>GetTasks()
        {
            DataTable dt = new DataTable();
            dt = clstst.GetTask();
            List<TaskModel> lst= new List<TaskModel>();

            if(dt!=null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows) {
                    TaskModel obj = new TaskModel
                    {
                        id = Convert.ToInt32(dr["id"]),
                        title=Convert.ToString(dr["title"]),
                        description=Convert.ToString(dr["description"]),
                        due_date = Convert.ToDateTime(dr["due_date"]),
                        status=Convert.ToInt32(dr["status"]),
                        remarks = Convert.ToString(dr["remarks"]),
                        create_on = Convert.ToDateTime(dr["create_on"]),
                        update_on = Convert.ToDateTime(dr["update_on"]),
                        created_by=Convert.ToString(dr["created_by"]),
                        updated_by = Convert.ToString(dr["updated_by"])
                    };
                    lst.Add(obj);
                }
                
            }
            return lst;
        }
    }
}