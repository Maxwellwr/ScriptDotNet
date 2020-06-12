namespace ScriptDotNet.Services
{
    public interface IMapService
    {
        uint AddFigure(MapFigure figure);
        void ClearFigures();
        bool RemoveFigure(uint id);
        bool UpdateFigure(uint id, MapFigure figure);
    }
}
