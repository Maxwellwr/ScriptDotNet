using ScriptDotNet2.Data;
using ScriptDotNet2.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptDotNet2.Services
{
    public class MapService:BaseService, IMapService
    {
        public MapService(StealthClient client)
            :base(client)
        {

        }

        public uint AddFigure(MapFigure figure)
        {
            throw new NotImplementedException();
        }

        public void ClearFigures()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFigure(uint id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFigure(uint id, MapFigure figure)
        {
            throw new NotImplementedException();
        }
    }
}
