using YourLogo.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourLogo.Tests.Interfaces
{
    public interface ISectionType 
    {
        dynamic SelectSubSection();
        string GeTypeOfSelectedProductSection();
    }
}
