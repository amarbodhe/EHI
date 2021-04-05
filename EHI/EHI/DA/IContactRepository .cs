using EHI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHI.DA
{
    public interface IContactRepository
    {
        List<Contact> Contact_DS(Contact contact);
        int Contact_DM( Contact contact);
        Contact Contact_DQ(int mode, int id);
    }
}