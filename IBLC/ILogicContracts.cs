using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWPictures.IBLC
{
    public interface ILogicContracts
    {
        byte[] GetImageFromFile(string filePath);

        bool ReturnTrue();

    }
}
