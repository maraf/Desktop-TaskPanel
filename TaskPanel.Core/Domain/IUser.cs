using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskPanel.Core.Domain
{
    public interface IUser
    {
        int ID { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
