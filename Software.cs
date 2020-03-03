using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    abstract public class Software
    {
        protected string name;
        protected string manufct;
        
        abstract public void showInf();
        abstract public bool relevance(DateTime dateNow);
        

    }
}
