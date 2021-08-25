using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appartments_MVC_Course.Models
{
    public class Stam
    {

        public int Id;
        public string Name;
        public bool IsRealStam;

        public Stam() { }
        public Stam(int id, string name, bool isRealStam)
        {
            Id = id;
            Name = name;
            IsRealStam = isRealStam;
        }
    }
}