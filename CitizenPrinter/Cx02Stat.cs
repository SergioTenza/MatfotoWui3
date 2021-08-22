using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    internal class Cx02Stat : IDisposable
    {
        public void Dispose()
        {
        }
    
        // CITIZEN CX-02 Printer Status Code
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
        public const int STATUS_USUALLY_STANDBY_MODE = GROUP_USUALLY | 0x8000;
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

        // Cutter Mode Setting Value
        public const uint CUTTER_MODE_STANDARD = 0U;
        public const uint CUTTER_MODE_NONSCRAP = 1U;
        public const uint CUTTER_MODE_2INCHCUT = 120U;
        public const uint CUTTER_MODE_PANORAMA = 1000U;

        // Panorama Print Status Code
        public const int STATUS_PRINTABLE = 0x0;
        public const int STATUS_HIGHTEMP_HEAD = 0x1;
        public const int STATUS_LOWTEMP_MEDIA = 0x20;
        public const int STATUS_HIGHHUMIDITY = 0x100;
        public const int STATUS_OTHER_STATE = 0x10000;
        public const uint STATUS_COMM_ERROR = 0xFFFFFFFF;

        // Continuous Panoramic Prints Specification
        public const uint CONT_PANORAMA_LAST = 0x0U;
        public const uint CONT_PANORAMA_PRINT = 0x1U;

        // Overcoat Setting Value
        public const uint OVERCOAT_FINISH_GLOSSY = 0U;          // glossy
        public const uint OVERCOAT_FINISH_MATTE1 = 1U;          // matte 1
        public const uint OVERCOAT_FINISH_MATTE2 = 2U;          // matte 2( reserve )
        public const uint OVERCOAT_FINISH_MATTE3 = 3U;          // matte 3( reserve )
        public const uint OVERCOAT_FINISH_FINEMATTE = 21U;      // fine matte
        public const uint OVERCOAT_FINISH_LUSTER = 22U;     // luster
        public const uint OVERCOAT_FINISH_PMATTE11 = 101U;      // partial matte ( matte )
        public const uint OVERCOAT_FINISH_PMATTE12 = 121U;      // partial matte ( fine matte )
        public const uint OVERCOAT_FINISH_PMATTE13 = 122U;      // partial matte ( luster )

        // Media Extension Code
        public const string EXT_CODE_STANDARD = "0000000000";
        public const string EXT_CODE_STICKER = "0000000001";
        public const string EXT_CODE_UNKNOWN = "0000000099";

        // Cut control parameter
        public const uint CUT_MODE_STANDARD = 0U;
        public const uint CUT_MODE_STICKER = 1U;
        public const uint CUT_MODE_INSTRUCTION = 2U;
        public const uint CUT_MODE_PAPER_FEED = 10U;
        public const uint CUT_MODE_FEED_FORWARD = 100U;
        public const uint CUT_MODE_FEED_BACKWARD = 200U;
        public const uint CUT_MODE_START_CUTTING = 1000U;

        // Cut Control Status
        public const uint CUT_STS_IDLE = 0U;
        public const uint CUT_STS_PRINTING = 1U;
        public const uint CUT_STS_WAIT_PAPER_FEED = 10U;
        public const uint CUT_STS_WAIT_COMMAND = 20U;
        public const uint CUT_STS_FEED_FORWARD = 120U;
        public const uint CUT_STS_FEED_BACKWARD = 220U;
        public const uint CUT_STS_WAIT_START_CUTTING = 1000U;
        public const uint CUT_STS_ERROR = 9000U;

        // Old Printer Status Code definition
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
        public const int CVS_USUALLY_STANDBY_MODE = CVG_USUALLY | 0x8000;
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

        [DllImport("CsjCx2Sts.dll")]
        static extern int CvInitialize([MarshalAs(UnmanagedType.LPWStr)] string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetVersion(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetSensorInfo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetResolutionH(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetResolutionV(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetMedia(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetStatus(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetCounterL(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetCounterA(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetCounterB(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvSetClearCounterA(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvSetClearCounterB(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetFreeBuffer(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetPQTY(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetMediaCounter(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetMediaColorOffset(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetMediaLotNo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetSerialNo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvSetFirmwUpdateMode(int lPortNum);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvSetFirmwDataWrite")]
        static extern int CvSetFirmwDataWrite_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvSetColorDataClear(int lPortNum);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvSetColorDataWrite")]
        static extern int CvSetColorDataWrite_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvSetColorDataVersion")]
        static extern int CvSetColorDataVersion_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetColorDataVersion(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int CvGetColorDataChecksum(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvSetCommand")]
        static extern int CvSetCommand_(int lPortNum, int lpCmd, int dwCmdLen);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvGetCommandEX")]
        static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "CvGetCommandEX")]
        static extern int CvGetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, byte[] lpRetBuff, int dwRetBuffSize);
        [DllImport("CsjCx2Sts.dll")]
        static extern int PortInitialize([MarshalAs(UnmanagedType.LPWStr)] string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetFirmwVersion(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetSensorInfo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetResolutionH(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetResolutionV(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMedia(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetStatus(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterL(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterA(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterB(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterP(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterMatte(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetCounterM(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetClearCounterA(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetClearCounterB(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetClearCounterM(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetCounterP(int lPortNum, int lCounter);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetFreeBuffer(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetPQTY(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMediaCounter(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMediaCounterH(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetInitialMediaCount(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMediaColorOffset(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMediaLotNo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetRfidMediaClass(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetRfidReserveData(int lPortNum, string p, int dwPage);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetSerialNo(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetUSBSerialEnable(int lPortNum, int dwEnable);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetUSBSerialEnable(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetFirmwUpdateMode(int lPortNum);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "SetFirmwDataWrite")]
        static extern int SetFirmwDataWrite_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetColorDataClear(int lPortNum);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "SetColorDataWrite")]
        static extern int SetColorDataWrite_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "SetColorDataVersion")]
        static extern int SetColorDataVersion_(int lPortNum, int lpData, int dwDataLen);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetColorDataVersion(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetColorDataVersionRes(int lPortNum, string p, int dwType);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetColorDataChecksum(int lPortNum, string p);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetColorDataChecksumRes(int lPortNum, string p, int dwType);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetCutterMode(int lPortNum, int dwMode);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetFullCutterSetup(int lPortNum, int lSize1, int lSize2, int lSize3, int lSize4);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetFullCutterSetupEX(int lPortNum, int lCutSize1, int lCutSize2, int lCutSize3, int lCutSize4, int lDustSize);
        [DllImport("CsjCx2Sts.dll")]
        static extern bool SetCutControl(int lPortNum, uint dwMode, uint dwSpeed, uint dwLength);
        [DllImport("CsjCx2Sts.dll")]
        static extern bool SetPaperFeed(int lPortNum, uint dwFrontFeed, uint dwRearFeed, uint dwFlag);
        [DllImport("CsjCx2Sts.dll")]
        static extern bool GetCutControlStatus(int lPortNum, ref uint lpState, ref uint lpFeedCount, ref uint lpRemainLength);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetMediaExtensionCode(int lPortNum, string s);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetStandbyTime(int lPortNum, int lTime);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetStandbyTime(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetEndKeepMode(int lPortNum, int lMode);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetEndKeepMode(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int GetPanoramaPrintable(int lPortNum);
        [DllImport("CsjCx2Sts.dll")]
        static extern int SetOvercoatFinish(int lPortNum, int ovcoat);
        [DllImport("CsjCx2Sts.dll")]
        static extern bool SetContPanorama(int lPortNum, uint dwContinuous, uint dwOverlap);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "SetCommand")]
        static extern int SetCommand_(int lPortNum, int lpCmd, int dwCmdLen);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "GetCommandEX")]
        static extern int GetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, string lpRetBuff, int dwRetBuffSize);
        [DllImport("CsjCx2Sts.dll", EntryPoint = "GetCommandEX")]
        static extern int GetCommandEX_(int lPortNum, int lpCmd, int dwCmdLen, byte[] lpRetBuff, int dwRetBuffSize);

        
        public static int CvSetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            int CvSetCommandRet = default;
            byte[] ByteArray;
            // Code Page 65001 = UTF-8
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            // 
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            // 
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetCommandRet = CvSetCommand_(lPortNum, lpCmd, dwCmdLen);

            // 
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

        public static int CvGetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            int CvGetCommandEXRet = default;
            byte[] ByteArray;
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvGetCommandEXRet = Cx02Stat.CvGetCommandEX_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize);
            gchCmd.Free();
            return CvGetCommandEXRet;
        }

        public static int SetCommand(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetCommandRet = default;
            byte[] ByteArray;
            // Code Page 65001 = UTF-8
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            // 
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            // 
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetCommandRet = SetCommand_(lPortNum, lpCmd, dwCmdLen);

            // �J��
            gchCmd.Free();
            return SetCommandRet;
        }

        public static int GetCommandEX(int lPortNum, string Cmd, int dwCmdLen, ref string rb, int dwRetBuffSize)
        {
            int GetCommandEXRet = default;
            byte[] ByteArray;
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            GetCommandEXRet = Cx02Stat.GetCommandEX_(lPortNum, lpCmd, dwCmdLen, rb, dwRetBuffSize);
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

        public static int CvSetFirmwDataWrite(int lPortNum, byte[] ByteArray, int dwLen)
        {
            int CvSetFirmwDataWriteRet = default;
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetFirmwDataWriteRet = CvSetFirmwDataWrite_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return CvSetFirmwDataWriteRet;
        }

        public static int CvSetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            int CvSetColorDataVersionRet = default;
            byte[] ByteArray;
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            CvSetColorDataVersionRet = CvSetColorDataVersion_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
            return CvSetColorDataVersionRet;
        }

        public static int SetColorDataVersion(int lPortNum, string Cmd, int dwCmdLen)
        {
            int SetColorDataVersionRet = default;
            byte[] ByteArray;
            ByteArray = Encoding.GetEncoding(65001).GetBytes(Cmd);
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetColorDataVersionRet = SetColorDataVersion_(lPortNum, lpCmd, dwCmdLen);
            gchCmd.Free();
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
            var gchCmd = GCHandle.Alloc(ByteArray, GCHandleType.Pinned);
            int lpCmd = gchCmd.AddrOfPinnedObject().ToInt32();
            SetColorDataWriteRet = SetColorDataWrite_(lPortNum, lpCmd, dwLen);
            gchCmd.Free();
            return SetColorDataWriteRet;
        }
    }
}
