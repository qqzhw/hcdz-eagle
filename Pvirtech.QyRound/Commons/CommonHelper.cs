using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.Commons
{
	public class CommonHelper
	{
        /// <summary>
        /// 转换接收到的字符串
        /// </summary>
        /// <param name="recvStr"></param>
        /// <returns></returns>
        public static string UTF8ToUnicode(string recvStr)
        {
            byte[] tempStr = Encoding.UTF8.GetBytes(recvStr);
            byte[] tempDef = Encoding.Convert(Encoding.UTF8, Encoding.Default, tempStr);
            string msg = Encoding.Default.GetString(tempDef);
            return msg;
        }
		public string ByteToString(byte[] InBytes, int len)
		{
			string StringOut = "";
			for (int i = 0; i < len; i++)
			{
				StringOut = StringOut + String.Format("{0:X2} ", InBytes[i]);
			}
			return StringOut;
		}
		public static string ByteToString(byte[] InBytes)
		{
			string StringOut = "";
			foreach (byte InByte in InBytes)
			{
				StringOut = StringOut + String.Format("{0:X2} ", InByte);
			}
			return StringOut;
		}
        public static byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        public static byte[] StringToByte(string InString)
		{
			string[] ByteStrings;
			ByteStrings = InString.Split(" ".ToCharArray());
			byte[] ByteOut;
			ByteOut = new byte[ByteStrings.Length - 1];
			for (int i = 0; i <ByteStrings.Length - 1; i++)
			{
				ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]),16);
			}
			return ByteOut;
		}
        public static byte[] HexStringToByteArray(string str)
        {
            str = str.Replace(" ", "");
            byte[] buffer = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(str.Substring(i, 2), 16);
            }
            return buffer;
        }
         
        #region 利用API方式获取网络链接状态
        private static int NETWORK_ALIVE_LAN = 0x00000001;
        private static int NETWORK_ALIVE_WAN = 0x00000002;
        private static int NETWORK_ALIVE_AOL = 0x00000004;
        [DllImport("sensapi.dll")]
        private extern static bool IsNetworkAlive(ref int flags);
        [DllImport("sensapi.dll")]
        private extern static bool IsDestinationReachable(string dest, IntPtr ptr);

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
         
        public static bool IsConnected()
        {
            int desc = 0;
            bool state = InternetGetConnectedState(out desc, 0);
            return state;
        }

        public static bool IsLanAlive()
        {
            return IsNetworkAlive(ref NETWORK_ALIVE_LAN);
        }
        public static bool IsWanAlive()
        {
            return IsNetworkAlive(ref NETWORK_ALIVE_WAN);
        }
        public static bool IsAOLAlive()
        {
            return IsNetworkAlive(ref NETWORK_ALIVE_AOL);
        }
        public static bool IsDestinationAlive(string Destination)
        {
            return (IsDestinationReachable(Destination, IntPtr.Zero));
        }
        #endregion
    }
}
