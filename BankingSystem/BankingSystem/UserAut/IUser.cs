using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAut
{
    public interface IUser
    {
        string LoginText { get; set; }
        string PasswordText { get; set; }
        string Message { get; set; }

    }
}
