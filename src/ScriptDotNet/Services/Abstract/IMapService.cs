using ScriptDotNet2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public interface IMapService
    {
        uint AddFigure(MapFigure figure);
        void ClearFigures();
        bool RemoveFigure(uint id);
        bool UpdateFigure(uint id, MapFigure figure);
    }
}
