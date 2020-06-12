namespace ScriptDotNet.Services
{
    public interface ILayerService
    {
        ushort DressSpeed { get; set; }

        bool Disarm();
        bool DressSavedSet();
        bool Equip(Layer layer, uint objId);
        bool EquipDressSet();
        bool Equipt(Layer layer, ushort objType);
        Layer GetLayer(uint objId);
        
        /// <summary>
        /// Returns Object ID located on your Char to specify the layer LayerType
        /// If there is no connection to the UO server, or in the bed wearing nothing - returns 0.
        /// </summary>
        /// <param name="layerType">Layer to search</param>
        /// <returns>Object id</returns>
        uint ObjAtLayer(Layer layerType);

        /// <summary>
        /// Returns Object ID located on your Char to specify the layer LayerType and playerId
        /// If there is no connection to the UO server, or in the bed wearing nothing - returns 0.
        /// </summary>
        /// <param name="layerType">Layer</param>
        /// <param name="playerId">Player</param>
        /// <returns>Object id</returns>
        uint ObjAtLayerEx(Layer layerType, uint playerId);
        void SetDress();
        bool Undress();
        bool Unequip(Layer layer);
        bool WearItem(Layer layer, uint objId);
    }
}
