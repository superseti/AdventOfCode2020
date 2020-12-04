using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCodeConsole.FourthDay
{
    interface IPassportValidator
    {
        bool IsValid(PassportInfo password);
    }
}
