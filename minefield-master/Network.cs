using System;


using System.Runtime.InteropServices;

namespace Minefield_Online
{

    public enum Commands : byte { start = 0, play, connect, disconnect, played, sendSettings, sendInfo, sendPlayer, sendName,sendText}

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Command
    {
        public Commands command;
        public ushort extraDataLength;
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MineInfo
    {
        public Players player;
        public ushort x;
        public ushort y;
        public bool bomb;
        public ushort count;
    }

    public static class Network
    {
        public static readonly ushort CommandSize = (ushort)Marshal.SizeOf(typeof(Command));
        public static readonly ushort InformationsSize = (ushort)Marshal.SizeOf(typeof(Informations));
        public static readonly ushort SettingsSize = (ushort)Marshal.SizeOf(typeof(Settings));
        public static readonly ushort MineInfoSize = (ushort)Marshal.SizeOf(typeof(MineInfo));
        public static readonly ushort PlayerNamesSize = (ushort)Marshal.SizeOf(typeof(PlayerNames));

        public static Byte[] SerializeStruct<T>(T obj)
        {
            int objsize = Marshal.SizeOf(typeof(T));

            Byte[] ret = new Byte[objsize];

            IntPtr buff = Marshal.AllocHGlobal(objsize);
            Marshal.StructureToPtr(obj, buff, true);
            Marshal.Copy(buff, ret, 0, objsize);
            Marshal.FreeHGlobal(buff);

            return ret;
        }

        public static T DeSerializeStruct<T>(Byte[] data)
        {
            int objsize = Marshal.SizeOf(typeof(T));
            IntPtr buff = Marshal.AllocHGlobal(objsize);

            Marshal.Copy(data, 0, buff, objsize);
            T retStruct = (T)Marshal.PtrToStructure(buff, typeof(T));
            Marshal.FreeHGlobal(buff);

            return retStruct;
        }

     
    }
}
