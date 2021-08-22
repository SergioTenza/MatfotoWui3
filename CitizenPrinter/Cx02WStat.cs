using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal class Cx02WStat : IDisposable
    {
        public void Dispose()
        {
        }

        [DllImport("Cx2WStat.dll")]
        static extern int CvInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetVersion(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetSensorInfo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetMedia(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetStatus(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetPQTY(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetCounterL(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetCounterA(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetCounterB(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetMediaCounter(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetMediaColorOffset(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetMediaLotNo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvSetColorDataVersion")]
        static extern int CvSetColorDataVersion_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvSetColorDataWrite")]
        static extern int CvSetColorDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetColorDataVersion(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvSetColorDataClear(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetColorDataChecksum(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetSerialNo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetResolutionH(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetResolutionV(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvGetFreeBuffer(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvSetClearCounterA(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvSetClearCounterB(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int CvSetFirmwUpdateMode(int lPortNum);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvSetFirmwDataWrite")]
        static extern int CvSetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvSetCommand")]
        static extern int CvSetCommand_(int lPortNum, int lpCmd, int dwCmdLen);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvGetCommand")]
        static extern int CvGetCommand_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize, ref int lpdwRetLen);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvGetCommandEX")]
        static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize);
        [DllImport("Cx2WStat.dll", EntryPoint = "CvGetCommandEX")]
        static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, byte[] lpRetBuff, int dwRetBuffSize);
        [DllImport("Cx2WStat.dll")]
        static extern int PortInitialize([MarshalAs(UnmanagedType.LPWStr)] string pszPortName);
        [DllImport("Cx2WStat.dll")]
        static extern int PortInitializeEX([MarshalAs(UnmanagedType.LPWStr)] string pszPortName, [MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName);
        [DllImport("Cx2WStat.dll")]
        static extern int RegisterPrinterName(int lPortNum, [MarshalAs(UnmanagedType.LPWStr)] string pszPrinterName);
        [DllImport("Cx2WStat.dll")]
        static extern int GetFirmwVersion(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetSensorInfo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMedia(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetStatus(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetPQTY(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterL(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterA(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterB(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterP(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterMatte(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetCounterM(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaCounter(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaCounter_R(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaCounterH(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaCounterH_R(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaColorOffset(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaLotNo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetMediaIdSetInfo(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetRfidMediaClass(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetRfidReserveData(int lPortNum, string s, int dwPAge);
        [DllImport("Cx2WStat.dll", EntryPoint = "SetColorDataVersion")]
        static extern int SetColorDataVersion_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll", EntryPoint = "SetColorDataWrite")]
        static extern int SetColorDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataVersion(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataVersionRes(int lPortNum, string s, int dpi);
        [DllImport("Cx2WStat.dll")]
        static extern int SetColorDataClear(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataChecksum(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataChecksumRes(int lPortNum, string s, int dpi);
        [DllImport("Cx2WStat.dll")]
        static extern int GetSerialNo(int lPortNum, string s);
        [DllImport("Cx2WStat.dll")]
        static extern int GetResolutionH(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetResolutionV(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int GetFreeBuffer(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int SetClearCounterA(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int SetClearCounterB(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int SetClearCounterM(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int SetCounterP(int lPortNum, int Counter);
        [DllImport("Cx2WStat.dll")]
        static extern int SetFirmwUpdateMode(int lPortNum);
        [DllImport("Cx2WStat.dll", EntryPoint = "SetFirmwDataWrite")]
        static extern int SetFirmwDataWrite_(int lPortNum, int lpBuff, int bLen);
        [DllImport("Cx2WStat.dll")]
        static extern int SetCutterMode(int lPortNum, int d);
        [DllImport("Cx2WStat.dll")]
        static extern int SetRettentionMode(int lPortNum, int d);
        [DllImport("Cx2WStat.dll")]
        static extern int GetInitialMediaCount(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern int SetUSBSerialEnable(int lPortNum, bool b);
        [DllImport("Cx2WStat.dll")]
        static extern int GetUSBSerialEnable(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetFullCutterSetup(int lPortNum, int lSize1, int lSize2, int lSize3, int lSize4, int lSize5, int lSize6);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetStandbyTime(int lPortNum, int lTime);
        [DllImport("Cx2WStat.dll")]
        static extern int GetStandbyTime(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetEndKeepMode(int lPortNum, int lMode);
        [DllImport("Cx2WStat.dll")]
        static extern int GetEndKeepMode(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetFullCutterSetupEX(int lPortNum, int lCutSize1, int lCutSize2, int lCutSize3, int lCutSize4, int lCutSize5, int lCutSize6, int DustSize);
        [DllImport("Cx2WStat.dll")]
        static extern int GetPanoramaPrintable(int lPortNum);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetOvercoatFinish(int lPortNum, int ovcoat);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataVersionResEX(int lPortNum, string s, int dpi, int lMedia);
        [DllImport("Cx2WStat.dll")]
        static extern int GetColorDataChecksumResEX(int lPortNum, string s, int dpi, int lMedia);
        [DllImport("Cx2WStat.dll")]
        static extern bool SetPrintSpeed(int lPortNum, int lPrintSpeed);

        
        public static int CvSetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            int CvSetCommandRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetCommandRet = CvSetCommand_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
            return CvSetCommandRet;
        }

        public static int CvSetData(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int CvSetDataRet = default;
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetDataRet = CvSetCommand_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return CvSetDataRet;
        }

        public static int CvGetCommand(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize, ref int dwRetLen)
        {
            int CvGetCommandRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            var gchRetLen = GCHandle.Alloc(dwRetLen, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            int lpdwRetLen = gchCmd.AddrOfPinnedObject().ToInt32();
            CvGetCommandRet = CvGetCommand_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize, ref lpdwRetLen);
            gchCmd.Free();
            gchRetLen.Free();
            return CvGetCommandRet;
        }

        public static int CvGetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            int CvGetCommandEXRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvGetCommandEXRet = CvGetCommandEX_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize);
            gchCmd.Free();
            return CvGetCommandEXRet;
        }

        public static int SetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetCommandRet = default;
            SetCommandRet = CvSetCommand(lPortNum, Cmd, dwCmdLen);
            return SetCommandRet;
        }

        public static int GetCommand(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize, ref int dwRetLen)
        {
            int GetCommandRet = default;
            GetCommandRet = CvGetCommand(lPortNum, Cmd, dwCmdLen, ref rb, dwRetBuffSize, ref dwRetLen);
            return GetCommandRet;
        }

        public static int GetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            int GetCommandEXRet = default;
            GetCommandEXRet = CvGetCommandEX(lPortNum, Cmd, dwCmdLen, ref rb, dwRetBuffSize);
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

        public static int CvSetFirmwDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int CvSetFirmwDataWriteRet = default;
            CvSetFirmwDataWriteRet = SetFirmwDataWrite(lPortNum, ByteArray, dwLen);
            return CvSetFirmwDataWriteRet;
        }

        public static int CvSetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            int CvSetColorDataVersionRet = default;
            byte[] ByteArray;
            ByteArray = System.Text.Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetColorDataVersionRet = CvSetColorDataVersion_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
            return CvSetColorDataVersionRet;
        }

        public static int SetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetColorDataVersionRet = default;
            SetColorDataVersionRet = CvSetColorDataVersion(lPortNum, Cmd, dwCmdLen);
            return SetColorDataVersionRet;
        }

        public static int CvSetColorDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int CvSetColorDataWriteRet = default;
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetColorDataWriteRet = CvSetColorDataWrite_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return CvSetColorDataWriteRet;
        }

        public static int SetColorDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int SetColorDataWriteRet = default;
            SetColorDataWriteRet = CvSetColorDataWrite(lPortNum, ByteArray, dwLen);
            return SetColorDataWriteRet;
        }
    }
}

