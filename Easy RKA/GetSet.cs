using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_RKA
{
    class GetSet
    {

    }

    class User 
    {
        public string id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string timestamp { get; set; }
        public string user_status { get; set; }
    }

    class Rekening
    {
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }
        public string d4 { get; set; }
        public string d5 { get; set; }
        public string rekening { get; set; }
        public string timestamp { get; set; }
        public string status { get; set; }
    }

    class T_rekening
    {
        public string id_rekening { get; set; }
        public string id_parent { get; set; }
        public string rekening { get; set; }
        public string status { get; set; }
    }

    class T_urusan
    {
        public string id_urusan { get; set; }
        public string id_parent { get; set; }
        public string urusan { get; set; }
        public string status { get; set; }
    }

    class CbRoleItem 
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    class CbStatusItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
