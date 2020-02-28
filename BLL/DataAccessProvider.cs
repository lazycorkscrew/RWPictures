
using RWPictures.DAL;
using RWPictures.IDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.BLL
{
    internal static class DataAccessProvider
    {
        internal static IDBAccessContracts DBAccessor { get; }

        static DataAccessProvider()
        {
            DBAccessor = new DBAccessor();
        }
    }
}
