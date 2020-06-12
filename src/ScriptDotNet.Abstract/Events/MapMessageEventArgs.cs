namespace ScriptDotNet
{
    public class MapMessageEventArgs : ItemEventArgs
    {
        public MapMessageEventArgs(int itemId, int centerX, int centerY)
            : base(itemId)
        {
            CenterX = centerX;
            CenterY = centerY;
        }
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }
    }


}
