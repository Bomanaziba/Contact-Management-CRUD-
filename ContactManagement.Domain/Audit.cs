using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Domain
{
    public class Audit
    {
        public Guid AduitID { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string URLAccessed { get; set; }
        public DateTime TimeaAccessed { get; set; }

        public Audit()
        {
        }
    }
}
