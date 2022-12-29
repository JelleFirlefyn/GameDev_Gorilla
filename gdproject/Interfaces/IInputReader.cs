using gdproject.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.Interfaces
{
    public interface IInputReader
    {
        Movement ReadInput();
    }
}
