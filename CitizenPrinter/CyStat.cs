using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal class CyStat : IDisposable
    {
        public void Dispose()
        {
        }
    
        public const int GROUP_USUALLY = 0x10000;
        public const int GROUP_SETTING = 0x20000;
        public const int GROUP_HARDWARE = 0x40000;
        public const int GROUP_SYSTEM = 0x80000;
        public const int GROUP_FLSHPROG = 0x100000;
        public const uint STATUS_ERROR = 0x80000000;
        public const int STATUS_USUALLY_IDLE = GROUP_USUALLY | 0x1;
        public const int STATUS_USUALLY_PRINTING = GROUP_USUALLY | 0x2;
        public const int STATUS_USUALLY_STANDSTILL = GROUP_USUALLY | 0x4;
        public const int STATUS_USUALLY_PAPER_END = GROUP_USUALLY | 0x8;
        public const int STATUS_USUALLY_RIBBON_END = GROUP_USUALLY | 0x10;
        public const int STATUS_USUALLY_COOLING = GROUP_USUALLY | 0x20;
        public const int STATUS_USUALLY_MOTCOOLING = GROUP_USUALLY | 0x40;
        public const int STATUS_SETTING_COVER_OPEN = GROUP_SETTING | 0x1;
        public const int STATUS_SETTING_PAPER_JAM = GROUP_SETTING | 0x2;
        public const int STATUS_SETTING_RIBBON_ERR = GROUP_SETTING | 0x4;
        public const int STATUS_SETTING_PAPER_ERR = GROUP_SETTING | 0x8;
        public const int STATUS_SETTING_DATA_ERR = GROUP_SETTING | 0x10;
        public const int STATUS_SETTING_SCRAPBOX_ERR = GROUP_SETTING | 0x20;
        public const int STATUS_HARDWARE_ERR01 = GROUP_HARDWARE | 0x1;
        public const int STATUS_HARDWARE_ERR02 = GROUP_HARDWARE | 0x2;
        public const int STATUS_HARDWARE_ERR03 = GROUP_HARDWARE | 0x4;
        public const int STATUS_HARDWARE_ERR04 = GROUP_HARDWARE | 0x8;
        public const int STATUS_HARDWARE_ERR05 = GROUP_HARDWARE | 0x10;
        public const int STATUS_HARDWARE_ERR06 = GROUP_HARDWARE | 0x20;
        public const int STATUS_HARDWARE_ERR07 = GROUP_HARDWARE | 0x40;
        public const int STATUS_HARDWARE_ERR08 = GROUP_HARDWARE | 0x80;
        public const int STATUS_HARDWARE_ERR09 = GROUP_HARDWARE | 0x100;
        public const int STATUS_HARDWARE_ERR10 = GROUP_HARDWARE | 0x200;
        public const int STATUS_SYSTEM_ERR01 = GROUP_SYSTEM | 0x1;
        public const int STATUS_FLSHPROG_IDLE = GROUP_FLSHPROG | 0x1;
        public const int STATUS_FLSHPROG_WRITING = GROUP_FLSHPROG | 0x2;
        public const int STATUS_FLSHPROG_FINISHED = GROUP_FLSHPROG | 0x4;
        public const int STATUS_FLSHPROG_DATA_ERR1 = GROUP_FLSHPROG | 0x8;
        public const int STATUS_FLSHPROG_DEVICE_ERR1 = GROUP_FLSHPROG | 0x10;
        public const int STATUS_FLSHPROG_OTHERS_ERR1 = GROUP_FLSHPROG | 0x20;

        // For CV Printers Item
        public const int CVG_USUALLY = 0x10000;
        public const int CVG_SETTING = 0x20000;
        public const int CVG_HARDWARE = 0x40000;
        public const int CVG_SYSTEM = 0x80000;
        public const int CVG_FLSHPROG = 0x100000;
        public const uint CVSTATUS_ERROR = 0x80000000;
        public const int CVS_USUALLY_IDLE = CVG_USUALLY | 0x1;
        public const int CVS_USUALLY_PRINTING = CVG_USUALLY | 0x2;
        public const int CVS_USUALLY_STANDSTILL = CVG_USUALLY | 0x4;
        public const int CVS_USUALLY_PAPER_END = CVG_USUALLY | 0x8;
        public const int CVS_USUALLY_RIBBON_END = CVG_USUALLY | 0x10;
        public const int CVS_USUALLY_COOLING = CVG_USUALLY | 0x20;
        public const int CVS_USUALLY_MOTCOOLING = CVG_USUALLY | 0x40;
        public const int CVS_SETTING_COVER_OPEN = CVG_SETTING | 0x1;
        public const int CVS_SETTING_PAPER_JAM = CVG_SETTING | 0x2;
        public const int CVS_SETTING_RIBBON_ERR = CVG_SETTING | 0x4;
        public const int CVS_SETTING_PAPER_ERR = CVG_SETTING | 0x8;
        public const int CVS_SETTING_DATA_ERR = CVG_SETTING | 0x10;
        public const int CVS_SETTING_SCRAP_ERR = CVG_SETTING | 0x20;
        public const int CVS_HARDWARE_ERR01 = CVG_HARDWARE | 0x1;
        public const int CVS_HARDWARE_ERR02 = CVG_HARDWARE | 0x2;
        public const int CVS_HARDWARE_ERR03 = CVG_HARDWARE | 0x4;
        public const int CVS_HARDWARE_ERR04 = CVG_HARDWARE | 0x8;
        public const int CVS_HARDWARE_ERR05 = CVG_HARDWARE | 0x10;
        public const int CVS_HARDWARE_ERR06 = CVG_HARDWARE | 0x20;
        public const int CVS_HARDWARE_ERR07 = CVG_HARDWARE | 0x40;
        public const int CVS_HARDWARE_ERR08 = CVG_HARDWARE | 0x80;
        public const int CVS_HARDWARE_ERR09 = CVG_HARDWARE | 0x100;
        public const int CVS_HARDWARE_ERR10 = CVG_HARDWARE | 0x200;
        public const int CVS_SYSTEM_ERR01 = CVG_SYSTEM | 0x1;
        public const int CVS_FLSHPROG_IDLE = CVG_FLSHPROG | 0x1;
        public const int CVS_FLSHPROG_WRITING = CVG_FLSHPROG | 0x2;
        public const int CVS_FLSHPROG_FINISHED = CVG_FLSHPROG | 0x4;
        public const int CVS_FLSHPROG_DATA_ERR1 = CVG_FLSHPROG | 0x8;
        public const int CVS_FLSHPROG_DEVICE_ERR1 = CVG_FLSHPROG | 0x10;
        public const int CVS_FLSHPROG_OTHERS_ERR1 = CVG_FLSHPROG | 0x20;
        public const short CUTTER_MODE_STANDARD = 0;
        public const short CUTTER_MODE_NONSCRAP = 1;
        public const short CUTTER_MODE_2INCHCUT = 120;

        [DllImport("CyStat.dll")]
        static extern int CvInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);
        [DllImport("CyStat.dll")]
        static extern int CvGetVersion(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvGetSensorInfo(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvGetMedia(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvGetStatus(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetPQTY(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetCounterL(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetCounterA(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetCounterB(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetMediaCounter(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetMediaColorOffset(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetMediaLotNo(int lPortNum, string s);
        [DllImport("CyStat.dll", EntryPoint = "CvSetColorDataVersion")]
        static extern int CvSetColorDataVersion_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll", EntryPoint = "SetColorDataWrite")]
        static extern int CvSetColorDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll")]
        static extern int CvGetColorDataVersion(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvSetColorDataClear(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetColorDataChecksum(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvGetSerialNo(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int CvGetResolutionH(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetResolutionV(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvGetFreeBuffer(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvSetClearCounterA(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvSetClearCounterB(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int CvSetFirmwUpdateMode(int lPortNum);
        [DllImport("CyStat.dll", EntryPoint = "SetFirmwDataWrite")]
        static extern int CvSetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll", EntryPoint = "CvSetCommand")]
        static extern int CvSetCommand_(int lPortNum, int lpCmd, int dwCmdLen);
        [DllImport("CyStat.dll", EntryPoint = "CvGetCommand")]
        static extern int CvGetCommand_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize, ref int lpdwRetLen);
        [DllImport("CyStat.dll", EntryPoint = "CvGetCommandEX")]
        static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize);        
        [DllImport("CyStat.dll")]
        static extern int PortInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);
        [DllImport("CyStat.dll")]
        static extern int GetFirmwVersion(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetSensorInfo(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetMedia(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetStatus(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetPQTY(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterL(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterA(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterB(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterP(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterMatte(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetCounterM(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetMediaCounter(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetMediaCounter_R(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetMediaColorOffset(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetMediaLotNo(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetMediaIdSetInfo(int lPortNum);
        [DllImport("CyStat.dll", EntryPoint = "SetColorDataVersion")]
        static extern int SetColorDataVersion_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll", EntryPoint = "SetColorDataWrite")]
        static extern int SetColorDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll")]
        static extern int GetColorDataVersion(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int SetColorDataClear(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetColorDataChecksum(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetSerialNo(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetResolutionH(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetResolutionV(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int GetFreeBuffer(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int SetClearCounterA(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int SetClearCounterB(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int SetClearCounterM(int lPortNum);
        [DllImport("CyStat.dll")]
        static extern int SetCounterP(int lPortNum, int Counter);
        [DllImport("CyStat.dll")]
        static extern int SetFirmwUpdateMode(int lPortNum);
        [DllImport("CyStat.dll", EntryPoint = "SetFirmwDataWrite")]
        static extern int SetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("CyStat.dll")]
        static extern int SetCutterMode(int lPortNum, int d);
        [DllImport("CyStat.dll", EntryPoint = "SetCommand")]
        static extern int SetCommand_(int lPortNum, int lpCmd, int dwCmdLen);
        [DllImport("CyStat.dll", EntryPoint = "GetCommand")]
        static extern int GetCommand_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize, ref int lpdwRetLen);
        [DllImport("CyStat.dll", EntryPoint = "GetCommandEX")]
        static extern int GetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize);
        [DllImport("CyStat.dll")]
        static extern int GetRfidMediaClass(int lPortNum, string s);
        [DllImport("CyStat.dll")]
        static extern int GetRfidReserveData(int lPortNum, string s, int dwPage);
        [DllImport("CyStat.dll")]
        static extern int GetInitialMediaCount(int lPortNum);
        
        public static int SetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetCommandRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetCommandRet = SetCommand_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
            return SetCommandRet;
        }

        public static int GetCommand(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize, ref int dwRetLen)
        {
            int GetCommandRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            var gchRetLen = GCHandle.Alloc(dwRetLen, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            int lpdwRetLen = gchCmd.AddrOfPinnedObject().ToInt32();
            GetCommandRet = CyStat.GetCommand_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize, ref lpdwRetLen);
            gchCmd.Free();
            gchRetLen.Free();
            return GetCommandRet;
        }

        public static int GetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            int GetCommandEXRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            GetCommandEXRet = CyStat.GetCommandEX_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize);
            gchCmd.Free();
            return GetCommandEXRet;
        }

        public static int SetFirmwDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int SetFirmwDataWriteRet = default;
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetFirmwDataWriteRet = SetFirmwDataWrite_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return SetFirmwDataWriteRet;
        }

        public static int SetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetColorDataVersionRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetColorDataVersionRet = SetColorDataVersion_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
            return SetColorDataVersionRet;
        }

        public static int SetColorDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int SetColorDataWriteRet = default;
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetColorDataWriteRet = SetColorDataWrite_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return SetColorDataWriteRet;
        }
    }
}
