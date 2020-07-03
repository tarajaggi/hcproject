using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLModel
{
    public class ModelClass : BaseModelClass
    {
        public int ID { get; set; }
        public string Prefix { get; set; }
        public string User_id { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public long contactnumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string deptID { get; set; }
        public string deptName { get; set; }
        public string deptAbb { get; set; }
        public string ex_msg { get; set; }
        public string ex_source { get; set; }
        public string ex_url { get; set; }
    }
}
