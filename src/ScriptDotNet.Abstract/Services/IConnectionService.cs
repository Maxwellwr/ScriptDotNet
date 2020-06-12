using System;

namespace ScriptDotNet.Services
{
    public interface IConnectionService
    {
        bool ARStatus { get; set; }
        bool Connected { get; }

        /// <summary>
        /// Returns last time connected to server(ConnectedTime).
        /// Returns during the last successful connecting to the server.
        /// If there is no connection to the UO server - return '30.12.1899'.
        /// </summary>
        DateTime ConnectedTime { get; }

        /// <summary>
        /// Returns last time disconnected from server(DisconnectedTime).
        /// returns the last time disconnect from server(for whatever reason).
        /// In the event that such action did not occur - will return '30.12.1899'.
        /// </summary>
        DateTime DisconnectedTime { get; }
        bool PauseScriptOnDisconnectStatus { get; set; }


        string GameServerIPString { get; }
        string ProxyIP { get; }
        ushort ProxyPort { get; }
        bool UseProxy { get; }

        int ChangeProfile(string Name);
        bool CheckLag(int timeoutMS);
        void CheckLagBegin();
        void CheckLagEnd();
        void Connect();
        void Disconnect();
    }
}
