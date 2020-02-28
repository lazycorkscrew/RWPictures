using RWPictures.BLL;
using RWPictures.IBLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.PL
{
    public static class LogicProvider
    {
        public static ILogicContracts Logic { get; }

        static LogicProvider()
        {
            Logic = new Logic();
        }
    }
}
