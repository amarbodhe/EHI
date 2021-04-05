using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHI.Models
{
    public class Contact:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }

        public string PhoneNo { get; set; }
        public bool Active { get; set; }
    }
}