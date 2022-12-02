using System;

using System.Runtime.InteropServices;

namespace Minefield_Online
{
    public enum Players : byte {None=0,Player1,Player2,Player3,Player4};

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Informations
    {
        public ushort Connected;
        public Players PlayersTurn;
        public ushort Player1Points;
        public ushort Player2Points;
        public ushort Player3Points;
        public ushort Player4Points;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Settings
    {
        public ushort Horizontal;
        public ushort Vertical;
        public ushort Bombs;
        public ushort Players;
        public ushort ServerPort;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PlayerNames
    {
        public string Player1Name;
        public string Player2Name;
        public string Player3Name;
        public string Player4Name;
    }
    public static class General
    {
        public static readonly System.Drawing.Color[] PlayerColors = new System.Drawing.Color[4] {System.Drawing.Color.Blue,System.Drawing.Color.Red,System.Drawing.Color.Green,System.Drawing.Color.Orange};

        public static string GetPlayersName(Players Player, PlayerNames Names) {
            if(Player== Players.Player1)
                return Names.Player1Name;

            if(Player== Players.Player2)
                return Names.Player2Name;

            if(Player== Players.Player3)
                return Names.Player3Name;

            if(Player== Players.Player4)
                return Names.Player4Name;

             return "Waiting...";
        }
        public static T ParseEnumValue<T>(ushort index)
        {
            return (T)Enum.ToObject(typeof(T), index);
        }
    }
}
