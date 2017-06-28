using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

///////////////////   Help
////           Last update 16 juillet  2011

//              20 07 2011  Corrige bug decoding hundred of secs.
//              20 06 2011  Added decode beam angle.
//              06 11 2010  Added  Ranges in Bottom track decoding.
//              05 10 2010  Added  VmDas navigation attitude decoding.    Coef 0.005493164
//              21 08 2010    CORRECTED VmDas navigation data decoding.
//              08 08  2010   Added surface velocity decoding 
//              //    Use ReadFile for playback
//              Class_PD0.ReadFile FileInProcess = new Class_PD0.ReadFile(FilePath0);
//              Class_PD0 Proc=new Class_PD0();
//              //    Class_PD0  will decode ensemble byte provided by ReadFile 
//              Proc.DecodeRecord(FileInProcess.CurrentPlaybackRecord);





namespace WindowsFormsApplication1   //// Last update 05 Juin 2010
{
    public class Class_PD0_23   //  use class Class_PDO.ReadFile   for playback.
    {

        #region Properties/// ///////////////////////////////////  Public properties
        public Byte[] RecordByte
        { get { return RecordByte0; } }

        public Record RecordStruct
        { get { return Record0; } }

        public RecordType Record_Type
        { get { return Record_Type0; } }

        #endregion /// ///////////////////////////////////  Public properties //

        #region Enum  ///////////////////////   Enumerations
        public enum RecordType { None, Ensemble, WavePacket, EndFile, ProcessError }
        public enum CoordinateSystemEnum { Beam, Instrument, Ship, Earth };
        #endregion ///////////////////////   Enumerations   //

        #region Method ////////////////////////////////////////  Public method


        public bool DecodeRecord(byte[] tempRecord)
        { return DecodeRecord0(tempRecord); }


        public byte[] AdjustCheckSum(Byte[] EnsIn)
        { return ChecksumAdjust0(EnsIn); }


        public bool IsADCPDataFile(string FilePath)
        { return IsADCPDataFile0(FilePath); }


        #endregion////////////////////////////////////////  Public method //

        #region Constructor///////////////////////   Constructor
        public Class_PD0_23()
        { LoadVariable(); }

        #endregion ///////////////////////   Constructor  //

        #region PrivateVariable///////////////////////  Private  Variable  general
        IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
        private Dictionary<int, string> RefDataType0 = new Dictionary<int, string>();

        private Byte[] RecordByte0;
        private Record Record0;
        private RecordType Record_Type0;
        #endregion

        #region RecordStructure /// ////////////////////Structures

        public struct Record
        {
            public EnsembleStruct EnsembleStruct;
            public PacketStruct PacketStruct;
        }
        #endregion

        #region Ensemble structure      //////////////////////
        //  Structure ensemble


        public struct EnsembleStruct
        {
            public Byte[] EnsBytesAll;
            public Byte[][] EnsBytes;
            public DescriptionStruct Description;
            public FixedLeaderStruct FixedLeader;
            public FixedLeaderStruct FixedLeader2;
            public VariableLeaderStruct VariableLeader;
            public VariableLeaderStruct VariableLeader2;
            public int[][] Correlation;
            public int[][] Correlation2;
            //public int[] CorrelationAll;
            public int[][] EchoInt;
            public int[][] EchoInt2;
            //public int[] EchoIntAll;
            public int[][] Echodb;
            public int[][] Status;
            public int[][] PercentGood;
            public int[][] PercentGood2;
            public BottomTrackStruct BottomTrack;
            public WinRiver1_GGAStruct WinRiverGGA;
            public VelocityStruct Velocity1;
            public VelocityStruct Velocity2;
            public VmDasNavigationStruct VmDasNavigation;
            public SurfaceLayerLeaderFormatStruct SurfaceLayerLeaderFormat;
            public VelocityStruct SurfaceVelocity;
            public int[][] SurfaceCorrelation;
            public int[][] SurfaceEchoInt;
            public int[][] SurfacePercentGood;
            public int[][] SurfaceSatus;
            public ExplorerGGAStruct ExplorerGGAStruct0;
            public ExplorerVTGStruct ExplorerVTGStruct0;
        }

        public struct DescriptionStruct
        {
            public int EnsembleSize;
            public int NbrDataType;
            public int[] DataTypeID;
            public int[] DataTypeOffset;
            public int[] DataTypeNbrBytes;
            public string[] DataTypeName;
            public Dictionary<int,int> ID2Offset;
            public Dictionary<int, Byte[]> ID2Byte;
        }

        public struct FixedLeaderStruct
        {
            public string FimwareVersion;
            public string firmwareRevision;
            public int LagLength;
            public int NumberOfDepthCells;
            public int PingPerEnsemble;
            public int DepthCellLength;
            public int BlankAfterTransmit;
            public int ProfilingMode;
            //public int CoordinateTransform;
            public CoordinateSystemEnum CoordinateSystem;
            public int HeadingAlignment;
            public float EA;
            public float EB;
            public int SystemConfigurationLow;
            public Boolean LookingDown;
            public int LookingDownInt;
            public int NbrBeam;
            public int RangeToBin1;
            public int LowCorThreshold;
            public int NbrCodeRep;
            public string TP;
            public string SensorSource;
            public string SensorAvailable;
            public int Bandwidth;
            public int SystBeamAngle;
            public string SystemSN;
            public string SystFreq;
        }

        public struct VariableLeaderStruct
        {
            public int EnsNumber;
            public int BitTest;
            public int Year;
            public int Month;
            public int DayE;
            public int Hour;
            public int Minutes;
            public int Secondes;
            public int HundredofSecondes;
            public DateTime EnsTime;
            public int BitResult;
            public int SpeedOfSound;
            public int XCDRDepth;
            public float Heading;
            public float Pitch;
            public float Roll;
            public int Salinity;
            public int Temperature;
            public int MPTMinutes;
            public int MPTSecondes;
            public int MPThundreds;
            public float HeadingSTD;
            public float PitchSTD;
            public float RollSTD;
            public int ADCChannel1;
            public int ADCChannel2;
            public int ADCChannel3;
            public int ADCChannel4;
            public int ADCChannel5;
            public int ADCChannel6;
            public int ADCChannel7;
            public int ErrorStatusWord;
            public int Pressure;
            public int PressureSensorVariance;
            //public int RTCCentury;
            //public int RTCYear;
            //public int RTCMonth;
            //public int RTCDay;
            //public int RTCHour;
            //public int RTCMinute;
            //public int RTCSecond;
            //public int RTCHundredth;
        }

        public struct VelocityStruct
        {
            public int ID;
            public string DisplayName;
            public string Data1Name;
            public string Data2Name;
            public string Data3Name;
            public string Data4Name;
            public int[][] Velocity;
            public int[] Velocities;
        }

        public struct BottomTrackStruct
        {
            public int PingPerEns;
            public int DelayBeforeReacquire;
            public int CorrMagMin;
            public int EvalAmpMin;
            public int PercentGoodMin;
            public int Mode;
            public int ErrorVelMax;
            public Double Range1;
            public Double Range2;
            public Double Range3;
            public Double Range4;
            public Double RangeAverage;
            public Double[] Ranges;
            public int Velocity1;
            public int Velocity2;
            public int Velocity3;
            public int Velocity4;
            public int[] Velocities;
            public int Correlation1;
            public int Correlation2;
            public int Correlation3;
            public int Correlation4;
            public int EvaluationAmplitude1;
            public int EvaluationAmplitude2;
            public int EvaluationAmplitude3;
            public int EvaluationAmplitude4;
            public int PercentGood1;
            public int PercentGood2;
            public int PercentGood3;
            public int PercentGood4;
            public int RefLayerMin;
            public int RefLayerNear;
            public int RefLayerFar;
            public int RefLayerVelocity1;
            public int RefLayerVelocity2;
            public int RefLayerVelocity3;
            public int RefLayerVelocity4;
            public int[] RefLayerVelocities;
            public int RefLayerCorrelation1;
            public int RefLayerCorrelation2;
            public int RefLayerCorrelation3;
            public int RefLayerCorrelation4;
            public int RefLayerIntensity1;
            public int RefLayerIntensity2;
            public int RefLayerIntensity3;
            public int RefLayerIntensity4;

            //public void BottomTrackStruct()
            //{

            //}

        }

        //   WinRiver 1 NMEA  structure
        public struct WinRiver1_GGAStruct
        {
            public string Header;
            public string GGAString;
            public DateTime GGATime;
            public double LatConvertedToDeg;
            public string NorthSouth;
            public double LongConvertedToDeg;
            public string EastWest;
            public float Altitude;
            public int Quality;
        }

        //   WinRiver II NMEA  structure

        public struct WinRiverII_NMEA_GGA_V2
        {
            public string Header;
            public DateTime UTCtime;
            public double Latitude;
            public char NS;
            public double Longitude;
            public char EW;
            public int Quality;
            public int NbrSat;
            public float HDOP;
            public float Altitude;
            public char AltUnit;
            public float Geoid;
            public char GeoidUnit;
            public float AgeDGPS;
            public int RefStationId;
        }

        public struct WinRiverII_NMEA_VTG_V2
        {
            public string Header;
            public float COGTrue;
            public char TrueIndicator;
            public float COGMagn;
            public char MagnIndicator;
            public float SpeedOverGroundKts;
            public char KtsIndicator;
            public float SpeedOverGroundKmh;
            public char KmhIndicator;
            public char ModeIndicator;
        }

        public struct WinRiverII_NMEA_HDT_V2
        {
            public string Header;
            public double dHeading;
            public char TrueIndicator;
        }

        public struct WinRiverII_NMEA_DBT_V2
        {
            public string Header;
            public float WaterDepth_ft;
            public char FeetIndicator;
            public float WaterDepth_m;
            public char MeterIndicator;
            public float WaterDepth_F;
            public char FathomIndicator;
        }

        public struct VmDasNavigationStruct
        {
            public string Header;
            public DateTime UTCDate;
            public long UTC_TIME_OF_FIRST_FIX;
            public int PC_CLOCK_OFFSET_FROM_UTC;
            public double FIRST_LATITUDE;
            public double FIRST_LONGITUDE;
            public int UTC_TIME_OF_LAST_FIX;
            public double LAST_LATITUDE;
            public double LAST_LONGITUDE;
            public float NMEAHeading;
            public float NMEAPitch;
            public float NMEARoll;
            public double SPEED_MADE_GOOD;
            public double DIRECTION_MADE_GOOD;
        }

        public struct SurfaceLayerLeaderFormatStruct
        {
            public int SURFACE_LAYER_CELL_COUNT;
            public int SURFACE_LAYER_CELL_SIZE;
            public int SURFACE_LAYER_CELL_1_DISTANCE;
        }

        public struct ExplorerGGAStruct
        {
            public double TimeTag;
            public double SampleTime;
            public double DataAvailable;
            public double ErrorBit0;
            public double ErrorBit1;
            public int UTCHours;
            public int UTCMinutes;
            public int UTCSeconds;
            public int UTC100ofSeconds;
            public int LatDegrees;
            public double LatMinutes;
            public int LongDegrees;
            public double LongMinutes;
            public int Quality;
            public int NbrStas;
            public double HDOP;
            public double Altitude;
            public double GeoidalSep;
            public double DiffAge;
            public double DiffRef;

        }

        public struct ExplorerVTGStruct
        {
            public double TimeTag;
            public double SampleTime;
            public double DataAvailable;
            public double ErrorBit0;
            public double ErrorBit1;
            public double TrueGroundCourse;
            public double MagGroundCourse;
            public double GroundSpeedKnots;
            public double GroundSpeedKm;
            public double Mode;
        }



        #endregion

        #region Burst structure
        //  full burst
        public struct FullBurstStruct
        {
            public FullWavesLeaderStruct FullWavesLeader;
            public FullWavesPacketWavesPingStruct[] FullWavesPacketWavesPing;
            public FullWavesPacketsLastLeaderStruct FullWavesPacketsLastLeader;
        }

        public struct PacketStruct
        {
            public PacketType PacketType3;
            public FullWavesLeaderStruct FullWavesLeaderStruct3;
            public FullWavesPacketWavesPingStruct FullWavesPacketWavesPingStruct3;
            public FullWavesPacketsLastLeaderStruct FullWavesPacketsLastLeaderStruct3;
        }


        public enum PacketType { None, BurstHeader, WavesPacket, BurstEnd }


        //  each record
        public struct FullWavesLeaderStruct
        {
            public WavesPacketHeaderStruct WavesPacketHeader;
            public WavesPacketLeaderStruct WavesPacketLeader;
        }

        public struct FullWavesPacketWavesPingStruct
        {
            public WavesPacketHeaderStruct WavesPacketHeader;
            public WavesPacketWavesPingStruct WavesPacketWavesPing;
            public WavesPacketsHPRStruct WavesPacketsHPR;
        }

        public struct FullWavesPacketsLastLeaderStruct
        {
            public WavesPacketHeaderStruct WavesPacketHeader;
            public WavesPacketsLastLeaderStruct WavesPacketsLastLeader;
        }

        //  each elements
        public struct WavesPacketHeaderStruct
        {
            public int PacketIDWord;                // 2 bytes
            public int OffsetToChecksum;            // 2 bytes
            public int Spare;                       // 1 bytes
            public int NumberOfDataTypes;           // 1 byte
            public int[] OffsetToEachDataType;     // 2 Tableau de bytes
            // total  8 for one data type
            public int[] SizeOfEachDataType;
        }

        public struct WavesPacketLeaderStruct
        {
            public int LeaderIDWord;    // 2 bytes      0x0103
            public int FirmwareVersion;  // 1 bytes
            public int FirmwareRevision;  // 1 bytes
            public int Bitmap;          // 2 bytes      Bitmap with sys freq, beam geometry
            public int Nbins;           // 1 byte       Number of depth cells in profile max (128)
            public int WaveRecPings;    //  2 bytes     # Samples per wave burst
            public int BinLength;       //  2 bytes     Depth cell size cm
            public int TimeBetweenPing; //  2 bytes     Time between wave samples 50 hund. Sec.
            public int TimeBetweenBurst; //  2 bytes    Time between wave bursts Sec.
            public int DistMidBin1;     //   2  bytes   Distance to middle of first depth cell cm
            public int BinsOut;         // 1 byte       Depth cells output 
            public int SelectedData;    //  2 bytes     Reserved
            public int DWSBins;         //   16 bytes   Bitmap of bins for dir. waves
            public int VelBins;         //  16 bytes    Bitmap of bins for non-dir waves
            public DateTime StartTime;       //  8 bytes     Start of burst  (Cen,Yr,mo,day,hr,min,sec,sec100)
            public long BurstNumber;     //  4 bytes     Burst number
            public int SerialNumber;    //  8 bytes     Serial number
            public int Temperature;     //  2  bytes    Temperature deg. C
            public int Reserved;        //  2  bytes
            //total  76
        }

        public struct WavesPacketWavesPingStruct
        {
            public int WavesPacketWavesPingIDWord;      //      2 bytes     0x0203
            public int PingNumber;                      //      2 Bytes     Sample #
            public int TimeSinceStart;                  //      4 bytes     Time since beginning of burst hund. Sec.       
            public int Pressure;                        //      4 bytes     Pressure deca Pa
            public int Dist2Surf;                       //      16 bytes    Range to surface for 4 beams (-1 = bad) mm
            public int[] Velocity;                      //      Tableau de bytes  2*bins Beam radial velocity for selected bins
            //      –32768=bad)  mm/s
        }

        public struct WavesPacketsHPRStruct
        {
            public int WavesPacketHPRIDWord;        //      2 bytes     0x0403
            public int Heading;                     //      2 bytes     Heading 0.01 deg
            public int Pitch;                       //      2 Pitch     Heading 0.01 deg
            public int Roll;                        //      2 Roll     Heading 0.01 deg
        }

        public struct WavesPacketsLastLeaderStruct
        {
            public int WavesPacketsLastLeaderIDWord;    //  2 bytes      ID 2 First leader ID word 0x0303
            public int AvgDepth;                        //  2 bytes      Average Depth dm
            public int AvgC;                            //  2 bytes      Average Speed of Sound m/s
            public int AvgTemp;                         //  2 bytes     Average Temperature 0.01 deg C
            public int AvgHeading;                      //  2 bytes     2 Average Heading 0.01 deg
            public int StdHeading;                      //  2 bytes     Standard Dev Heading 0.01 deg
            public int AvgPitch;                         // 2 bytes      Average Pitch 0.01 deg
            public int StdPitch;                       // 2 bytes      Standard Dev Pitch 0.01 deg
            public int AvgRoll;                         // 2 bytes      Average Roll 0.01 deg
            public int StdRoll;                         // 2 bytes      Standard Dev Roll 0.01 deg
        }

        #endregion

        #region Private methods/// //////////////////// Private methods

        private void LoadVariable()
        {
            //  fill table datatype name
            RefDataType0.Add(0x000, "Fixed leader 1");
            RefDataType0.Add(0x001, "Fixed leader 2");
            RefDataType0.Add(0x0080, "Variable leader 1"); //128
            RefDataType0.Add(0x0081, "Variable leader 2");
            RefDataType0.Add(0x0100, "Velocity Profile 1");  // 256
            RefDataType0.Add(0x0101, "Velocity Profile 2");
            RefDataType0.Add(0x0200, "Correlation Profile 1");  //512
            RefDataType0.Add(0x0201, "Correlation Profile 2");
            RefDataType0.Add(0x0300, "Echo Intensity Profile 1"); // 768
            RefDataType0.Add(0x0301, "Echo Intensity Profile 2");
            RefDataType0.Add(0x0400, "Percent Good Profile 1");   //  1024
            RefDataType0.Add(0x0401, "Percent Good Profile 2");
            RefDataType0.Add(0x0500, "Status Profile");
            RefDataType0.Add(0x0600, "Bottom Track");  //  1536
            RefDataType0.Add(0x0800, "MicroCAT");                   //2048
            RefDataType0.Add(0x2000, "VmDas Navigation");           //8192
            RefDataType0.Add(0x2101, "WinRiver GGA (GPS) Data");    //8449
            RefDataType0.Add(0x2102, "WinRiver VTG (GPS) Data");    //8450
            RefDataType0.Add(0x2103, "WinRiver GSA (GPS) Data");    //8451

            RefDataType0.Add(0x2022, "General NMEA structure");     //8226
            RefDataType0.Add(0x2100, "WinRiver II  NMEA  $xxDBT");  //8448
            //RefDataType0.Add(0x2101, "WinRiver II  NMEA  $xxGGA");  // 
            //RefDataType0.Add(0x2102, "WinRiver II  NMEA  $xxVTG");
            //RefDataType0.Add(0x2104, "WinRiver II  NMEA  $xxHDT");

            RefDataType0.Add(0x0010, "Surface Layer Leader"); //16
            RefDataType0.Add(0x0110, "Surface Layer Velocity"); //272
            RefDataType0.Add(0x0210, "Surface Correlation Magnitude"); //528
            RefDataType0.Add(0x0310, "Surface Echo Intensity"); //784
            RefDataType0.Add(0x0410, "Surface Percent-Good"); //1040
            RefDataType0.Add(0x0510, "Surface Status"); //1296
            RefDataType0.Add(0x4401, "Automatic Mode Setup"); //17409
            RefDataType0.Add(0x4400, "Firmware Status"); //17408
            RefDataType0.Add(0x5411, "Explorer GGA");  // 21521
            RefDataType0.Add(0x5416, "Explorer VTG"); //  21526
            //RefDataType0.Add(0x0010, "Surface Layer Leader Format"); //16
            //RefDataType0.Add(0x0010, "Surface Layer Leader Format"); //16
            //RefDataType0.Add(0x0010, "Surface Layer Leader Format"); //16

            //RefDataType0.Add(0x0010, "Surface Layer Leader Format"); //16
        } ///  used by constructor

        private bool DecodeRecord0(Byte[] tempRecord0)
        {
            RecordByte0 = null;
            Record_Type0 = RecordType.None;

            if (!ChecksumVerify(tempRecord0)) { return false; }

            RecordByte0 = tempRecord0;

            if (tempRecord0[0] == 127 && tempRecord0[0] == 127)
            {
                Record_Type0 = RecordType.Ensemble;
                return DecodeEnsemble(tempRecord0);
            }

            if (tempRecord0[0] == 127 && tempRecord0[0] == 121)
            {
                Record_Type0 = RecordType.WavePacket;
                return DecodePacket(tempRecord0);
            }
            return false;
        }///////////  decide if ensemble or packet  set record type

        #region Decode ensemble

        private bool DecodeEnsemble(byte[] TempsRecord0)
        {
            Record0.EnsembleStruct.EnsBytesAll = TempsRecord0;
            int NbrDataType = TempsRecord0[5];
            Record0.EnsembleStruct.Description.NbrDataType = NbrDataType;
            Record0.EnsembleStruct.Description.DataTypeID = new int[NbrDataType];
            Record0.EnsembleStruct.Description.DataTypeOffset = new int[NbrDataType];
            Record0.EnsembleStruct.Description.DataTypeNbrBytes = new int[NbrDataType];
            Record0.EnsembleStruct.Description.DataTypeName = new string[NbrDataType];
            Record0.EnsembleStruct.Description.ID2Offset = new Dictionary<int, int>();
            Record0.EnsembleStruct.Description.ID2Byte = new Dictionary<int, Byte[]>();

            ////////////////////////////////////////////////////////////////////////
            ///            Decode Ensemble Structure.
            ////////////////////////////////////////////////////////////////////////

            ///      Datatype offset and Datatype ID  per data type.
            for (int i = 0; i < NbrDataType; i++)
            {
                Record0.EnsembleStruct.Description.DataTypeOffset[i] = TempsRecord0[(i * 2) + 6] + (TempsRecord0[(i * 2) + 7] * 256);
                Record0.EnsembleStruct.Description.DataTypeID[i] = TempsRecord0[Record0.EnsembleStruct.Description.DataTypeOffset[i]] + TempsRecord0[Record0.EnsembleStruct.Description.DataTypeOffset[i] + 1] * 256;

                if (Record0.EnsembleStruct.Description.DataTypeID.Length > 8)
                {
                    if (Record0.EnsembleStruct.Description.DataTypeID[8] == 0) { Record0.EnsembleStruct.Description.DataTypeID[8] = 51; }
                }
                Record0.EnsembleStruct.Description.ID2Offset.Add(Record0.EnsembleStruct.Description.DataTypeID[i], Record0.EnsembleStruct.Description.DataTypeOffset[i]);
            }

            ///      Get  Number Of bytes per data type.
            for (int i = 0; i < NbrDataType - 1; i++)
            {
                Record0.EnsembleStruct.Description.DataTypeNbrBytes[i] = Record0.EnsembleStruct.Description.DataTypeOffset[i + 1] - Record0.EnsembleStruct.Description.DataTypeOffset[i];
            }
            Record0.EnsembleStruct.Description.DataTypeNbrBytes[NbrDataType - 1] = TempsRecord0.Length - Record0.EnsembleStruct.Description.DataTypeOffset[NbrDataType - 1];

            /////     creates tables  in structInt0
            Record0.EnsembleStruct.EnsBytes = new byte[Record0.EnsembleStruct.Description.NbrDataType][];
            for (int i = 0; i < NbrDataType; i++)
            {
                Record0.EnsembleStruct.EnsBytes[i] = new byte[Record0.EnsembleStruct.Description.DataTypeNbrBytes[i]];
                Record0.EnsembleStruct.Description.ID2Byte.Add(Record0.EnsembleStruct.Description.DataTypeID[i], Record0.EnsembleStruct.EnsBytes[i]);
            }

            //                         Datatype names.
            for (int i = 0; i < NbrDataType; i++)
            {
                if (RefDataType0.ContainsKey(Record0.EnsembleStruct.Description.DataTypeID[i]))
                {
                    Record0.EnsembleStruct.Description.DataTypeName[i] = RefDataType0[Record0.EnsembleStruct.Description.DataTypeID[i]];
                }
                else
                {   //  data not reconized
                    Record0.EnsembleStruct.Description.DataTypeName[i] = "Data type not reconized";
                }
            }

            /////   Copy bytes from Current_ensemble into    StructInt0.EnsByte 
            for (int i = 0; i < NbrDataType; i++)
            {
                Array.Copy(TempsRecord0, Record0.EnsembleStruct.Description.DataTypeOffset[i], Record0.EnsembleStruct.EnsBytes[i], 0, Record0.EnsembleStruct.Description.DataTypeNbrBytes[i]);
            }

            ///  Start decoder
            ///  decode each data type witht the appropriate decoder
            for (int i = 0; i < NbrDataType; i++)
            {

                //  decode non profiles   data ////  decode non profiles   data //////////////////////

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 0)
                {
                    DecodeDataFixedLeader(Record0.EnsembleStruct.EnsBytes[i]);
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1)
                {
                    DecodeDataFixedLeader2(Record0.EnsembleStruct.EnsBytes[i]);
                }

                //  variable leader
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 128)
                {
                    DecodeDataVariableLeader(Record0.EnsembleStruct.EnsBytes[i]);
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 129)
                {
                    DecodeDataVariableLeader2(Record0.EnsembleStruct.EnsBytes[i]);
                }

                // bottom track
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1536)
                {
                    DecodeDataBottomTrack(Record0.EnsembleStruct.EnsBytes[i]);
                }
                // WinRiverGGA
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 8449)
                {
                    DecodeDataWinRiverGGA(Record0.EnsembleStruct.EnsBytes[i]);
                }

                //  WinRiver II  GGA   2101


                //  Vmdas Navigation
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 8192)
                {
                    DecodeVmDasNavigation(Record0.EnsembleStruct.EnsBytes[i]);
                }

                //  WinRiver surface data
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 16)
                {
                    DecodeSurfaceDataLeader(Record0.EnsembleStruct.EnsBytes[i]);
                }

                //  Explorer GGA
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 21521)
                {
                    DecodeExplorerGGA(Record0.EnsembleStruct.EnsBytes[i]);
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 21526)
                {
                   DecodeExplorerVTG(Record0.EnsembleStruct.EnsBytes[i]);
                }

                ///////////////////////////////////////  decode velocity profiles   data //////////////////////
                //   Velocity 1
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 256)
                {
                    Record0.EnsembleStruct.Velocity1 = DecodeDataProfile2bytes(Record0.EnsembleStruct.EnsBytes[i], 256, "Velocity 1");
                }
                //  velocity 2
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 257)
                {
                    Record0.EnsembleStruct.Velocity2 = DecodeDataProfile2bytes2(Record0.EnsembleStruct.EnsBytes[i], 257, "Velocity 2");
                }
                //  Correlation
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 512)
                {
                    Record0.EnsembleStruct.Correlation = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 512, "Correlation");
                }
                //  Echo Int
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 768)
                {
                    Record0.EnsembleStruct.EchoInt = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 768, "Echo Int16");
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1024)
                {
                    Record0.EnsembleStruct.PercentGood = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 1024, "Percent Good");
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1280)
                {
                    Record0.EnsembleStruct.Status = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 1024, "Status");
                }

                // surface profile
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 272)
                {
                    Record0.EnsembleStruct.SurfaceVelocity = DecodeDataProfile2bytes(Record0.EnsembleStruct.EnsBytes[i], 272, "Surface Velocity");
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 528)
                {
                    Record0.EnsembleStruct.SurfaceCorrelation = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 528, "Surface correlation");
                }

                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 784)
                {
                    Record0.EnsembleStruct.SurfaceEchoInt = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 784, "Surface echo Int");
                }
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1040)
                {
                    Record0.EnsembleStruct.SurfacePercentGood = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 1040, "Surface Percent good");
                }
                if (Record0.EnsembleStruct.Description.DataTypeID[i] == 1296)
                {
                    Record0.EnsembleStruct.SurfaceSatus = DecodeDataProfile1bytes(Record0.EnsembleStruct.EnsBytes[i], 1296, "Surface status");
                }

            }
            return true;
        }


        //  Fixed leader
        int CoordinateInt;
        private void DecodeDataFixedLeader(Byte[] ByteIn)
        {


            Record0.EnsembleStruct.FixedLeader.FimwareVersion = ByteIn[2].ToString("00");
            Record0.EnsembleStruct.FixedLeader.firmwareRevision = ByteIn[3].ToString("00");
            Record0.EnsembleStruct.FixedLeader.SystemConfigurationLow = ByteIn[4];


            switch (ByteIn[4] & 7)
            {
                case 0:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "75kHz";
                    break;
                case 1:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "150kHz";
                    break;
                case 2:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "300kHz";
                    break;
                case 3:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "600kHz";
                    break;
                case 4:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "1200kHz";
                    break;
                case 5:
                    Record0.EnsembleStruct.FixedLeader.SystFreq = "2400kHz";
                    break;
                case 6:

                    break;
                case 7:

                    break;


                default:
                    break;
            }

            switch (ByteIn[5] & 3)
            {
                case 0:
                    Record0.EnsembleStruct.FixedLeader.SystBeamAngle = 15;
                    break;
                case 1:
                    Record0.EnsembleStruct.FixedLeader.SystBeamAngle = 20;
                    break;
                case 2:
                    Record0.EnsembleStruct.FixedLeader.SystBeamAngle = 30;
                    break;
                default:
                    Record0.EnsembleStruct.FixedLeader.SystBeamAngle = 45;
                    break;
            }


            Record0.EnsembleStruct.FixedLeader.LagLength = ByteIn[7];
            Record0.EnsembleStruct.FixedLeader.NbrBeam = ByteIn[8];
            Record0.EnsembleStruct.FixedLeader.NumberOfDepthCells = ByteIn[9];
            Record0.EnsembleStruct.FixedLeader.PingPerEnsemble = ByteIn[11] * 256 + ByteIn[10];
            Record0.EnsembleStruct.FixedLeader.DepthCellLength = ByteIn[13] * 256 + ByteIn[12];
            Record0.EnsembleStruct.FixedLeader.BlankAfterTransmit = ByteIn[15] * 256 + ByteIn[14];
            Record0.EnsembleStruct.FixedLeader.ProfilingMode = ByteIn[16];
            Record0.EnsembleStruct.FixedLeader.LowCorThreshold = ByteIn[17];
            Record0.EnsembleStruct.FixedLeader.NbrCodeRep = ByteIn[18];

            Record0.EnsembleStruct.FixedLeader.TP = ByteIn[22].ToString("00") + ":" + ByteIn[23].ToString("00") + "." + ByteIn[24].ToString("00");

            CoordinateInt = ByteIn[25];

            switch (CoordinateInt & 24)
            {
                case 24:
                    Record0.EnsembleStruct.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Earth;
                    break;
                case 16:
                    Record0.EnsembleStruct.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Ship;
                    break;
                case 8:
                    Record0.EnsembleStruct.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Instrument;
                    break;
                case 0:
                    Record0.EnsembleStruct.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Beam;
                    break;
            }

            Record0.EnsembleStruct.FixedLeader.LookingDownInt = -1;
            if ((Record0.EnsembleStruct.FixedLeader.SystemConfigurationLow & 128) == 128)
            {
                Record0.EnsembleStruct.FixedLeader.LookingDown = false;
                Record0.EnsembleStruct.FixedLeader.LookingDownInt = 1;
            }
            else
            {
                Record0.EnsembleStruct.FixedLeader.LookingDown = true;
            }






            Record0.EnsembleStruct.FixedLeader.EA = (float)(decimal.Divide((ByteIn[27] * 256 + ByteIn[26]), 100));
            Record0.EnsembleStruct.FixedLeader.EB = (float)(decimal.Divide((ByteIn[29] * 256 + ByteIn[28]), 100));

            Record0.EnsembleStruct.FixedLeader.SensorSource = ByteIn[30].ToString();
            Record0.EnsembleStruct.FixedLeader.SensorAvailable = ByteIn[31].ToString();
            Record0.EnsembleStruct.FixedLeader.RangeToBin1 = ByteIn[33] * 256 + ByteIn[32];

            if (ByteIn.Length > 58)
            {
                Record0.EnsembleStruct.FixedLeader.SystemSN = (ByteIn[57] * 16777216 + ByteIn[56] * 65536 + ByteIn[55] * 256 + ByteIn[54]).ToString();
                Record0.EnsembleStruct.FixedLeader.Bandwidth = ByteIn[50] * 256 + ByteIn[51];
                //Record0.EnsembleStruct.FixedLeader.SystBeamAngle = ByteIn[58];
            }

        }

        private void DecodeDataFixedLeader2(Byte[] ByteIn)
        {


            Record0.EnsembleStruct.FixedLeader2.FimwareVersion = ByteIn[2].ToString("00");
            Record0.EnsembleStruct.FixedLeader2.firmwareRevision = ByteIn[3].ToString("00");
            Record0.EnsembleStruct.FixedLeader2.SystemConfigurationLow = ByteIn[4];
            Record0.EnsembleStruct.FixedLeader2.LagLength = ByteIn[7];
            Record0.EnsembleStruct.FixedLeader2.NbrBeam = ByteIn[8];
            Record0.EnsembleStruct.FixedLeader2.NumberOfDepthCells = ByteIn[9];
            Record0.EnsembleStruct.FixedLeader2.PingPerEnsemble = ByteIn[11] * 256 + ByteIn[10];
            Record0.EnsembleStruct.FixedLeader2.DepthCellLength = ByteIn[13] * 256 + ByteIn[12];
            Record0.EnsembleStruct.FixedLeader2.BlankAfterTransmit = ByteIn[15] * 256 + ByteIn[14];
            Record0.EnsembleStruct.FixedLeader2.ProfilingMode = ByteIn[16];
            Record0.EnsembleStruct.FixedLeader2.LowCorThreshold = ByteIn[17];
            Record0.EnsembleStruct.FixedLeader2.NbrCodeRep = ByteIn[18];

            Record0.EnsembleStruct.FixedLeader2.TP = ByteIn[22].ToString("00") + ":" + ByteIn[23].ToString("00") + "." + ByteIn[24].ToString("00");

            CoordinateInt = ByteIn[25];

            switch (CoordinateInt & 24)
            {
                case 24:
                    Record0.EnsembleStruct.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Earth;
                    break;
                case 16:
                    Record0.EnsembleStruct.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Ship;
                    break;
                case 8:
                    Record0.EnsembleStruct.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Instrument;
                    break;
                case 0:
                    Record0.EnsembleStruct.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Beam;
                    break;
            }

            Record0.EnsembleStruct.FixedLeader2.LookingDownInt = -1;
            if ((Record0.EnsembleStruct.FixedLeader2.SystemConfigurationLow & 128) == 128)
            {
                Record0.EnsembleStruct.FixedLeader2.LookingDown = false;
                Record0.EnsembleStruct.FixedLeader2.LookingDownInt = 1;
            }
            else
            {
                Record0.EnsembleStruct.FixedLeader2.LookingDown = true;
            }
            Record0.EnsembleStruct.FixedLeader2.EA = (float)(decimal.Divide((ByteIn[27] * 256 + ByteIn[26]), 100));
            Record0.EnsembleStruct.FixedLeader2.EB = (float)(decimal.Divide((ByteIn[29] * 256 + ByteIn[28]), 100));

            Record0.EnsembleStruct.FixedLeader2.SensorSource = ByteIn[30].ToString();
            Record0.EnsembleStruct.FixedLeader2.SensorAvailable = ByteIn[31].ToString();
            Record0.EnsembleStruct.FixedLeader2.RangeToBin1 = ByteIn[33] * 256 + ByteIn[32];

            if (ByteIn.Length > 58)
            {
                Record0.EnsembleStruct.FixedLeader2.SystemSN = (ByteIn[57] * 16777216 + ByteIn[56] * 65536 + ByteIn[55] * 256 + ByteIn[54]).ToString();
                Record0.EnsembleStruct.FixedLeader2.Bandwidth = ByteIn[50] * 256 + ByteIn[51];
                Record0.EnsembleStruct.FixedLeader2.SystBeamAngle = ByteIn[58];
            }
        }

        //  Variable leader
        private void DecodeDataVariableLeader(Byte[] ByteIn)
        {//  Le tableau commence a 0, la doc de RDI commence a 1
            Record0.EnsembleStruct.VariableLeader.EnsNumber = ByteIn[2] + ByteIn[3] * 256 + ByteIn[11] * 65536;
            Record0.EnsembleStruct.VariableLeader.BitTest = ByteIn[12] + ByteIn[13] * 256;

            Record0.EnsembleStruct.VariableLeader.Year = ByteIn[4];
            Record0.EnsembleStruct.VariableLeader.Month = ByteIn[5];
            Record0.EnsembleStruct.VariableLeader.DayE = ByteIn[6];
            Record0.EnsembleStruct.VariableLeader.Hour = ByteIn[7];
            Record0.EnsembleStruct.VariableLeader.Minutes = ByteIn[8];
            Record0.EnsembleStruct.VariableLeader.Secondes = ByteIn[9];
            Record0.EnsembleStruct.VariableLeader.HundredofSecondes = ByteIn[10];
            Record0.EnsembleStruct.VariableLeader.BitResult = ByteIn[12] + ByteIn[13] * 256;
            Record0.EnsembleStruct.VariableLeader.SpeedOfSound = ByteIn[14] + ByteIn[15] * 256;
            Record0.EnsembleStruct.VariableLeader.XCDRDepth = ByteIn[16] + ByteIn[17] * 256;
            Record0.EnsembleStruct.VariableLeader.Heading = ByteIn[18] + ByteIn[19] * 256;
            Record0.EnsembleStruct.VariableLeader.Heading = Record0.EnsembleStruct.VariableLeader.Heading / 100;

            Record0.EnsembleStruct.VariableLeader.Pitch = ByteIn[20] + ByteIn[21] * 256;
            if (Record0.EnsembleStruct.VariableLeader.Pitch > 32767) { Record0.EnsembleStruct.VariableLeader.Pitch -= 65536; }  //  SHOULD BE 65635
            Record0.EnsembleStruct.VariableLeader.Pitch = Record0.EnsembleStruct.VariableLeader.Pitch / 100;

            Record0.EnsembleStruct.VariableLeader.Roll = ByteIn[22] + ByteIn[23] * 256;
            if (Record0.EnsembleStruct.VariableLeader.Roll > 32767) { Record0.EnsembleStruct.VariableLeader.Roll -= 65536; }  //  SHOULD BE 65635
            Record0.EnsembleStruct.VariableLeader.Roll = Record0.EnsembleStruct.VariableLeader.Roll / 100;

            Record0.EnsembleStruct.VariableLeader.Salinity = ByteIn[24] + ByteIn[25] * 256;
            Record0.EnsembleStruct.VariableLeader.Temperature = ByteIn[26] + ByteIn[27] * 256;

            if (ByteIn.Length > 50)
            {
                Record0.EnsembleStruct.VariableLeader.Pressure = ByteIn[51] * 16777216 + ByteIn[50] * 65536 + ByteIn[49] * 256 + ByteIn[48];
            }

            string DateString = Record0.EnsembleStruct.VariableLeader.DayE.ToString("00") + "/" + Record0.EnsembleStruct.VariableLeader.Month.ToString("00") + "/" + Record0.EnsembleStruct.VariableLeader.Year.ToString("00") + " " + Record0.EnsembleStruct.VariableLeader.Hour.ToString("00") + ":" + Record0.EnsembleStruct.VariableLeader.Minutes.ToString("00") + ":" + Record0.EnsembleStruct.VariableLeader.Secondes.ToString("00") + "." + Record0.EnsembleStruct.VariableLeader.HundredofSecondes.ToString("00");
            Record0.EnsembleStruct.VariableLeader.EnsTime = DateTime.Parse(DateString, culture);
        }

        private void DecodeDataVariableLeader2(Byte[] ByteIn)
        {//  Le tableau commence a 0, la doc de RDI commence a 1
            Record0.EnsembleStruct.VariableLeader2.EnsNumber = ByteIn[2] + ByteIn[3] * 256 + ByteIn[11] * 65536;
            Record0.EnsembleStruct.VariableLeader2.BitTest = ByteIn[12] + ByteIn[13] * 256;

            Record0.EnsembleStruct.VariableLeader2.Year = ByteIn[4];
            Record0.EnsembleStruct.VariableLeader2.Month = ByteIn[5];
            Record0.EnsembleStruct.VariableLeader2.DayE = ByteIn[6];
            Record0.EnsembleStruct.VariableLeader2.Hour = ByteIn[7];
            Record0.EnsembleStruct.VariableLeader2.Minutes = ByteIn[8];
            Record0.EnsembleStruct.VariableLeader2.Secondes = ByteIn[9];
            Record0.EnsembleStruct.VariableLeader2.HundredofSecondes = ByteIn[10];
            Record0.EnsembleStruct.VariableLeader2.BitResult = ByteIn[12] + ByteIn[13] * 256;
            Record0.EnsembleStruct.VariableLeader2.SpeedOfSound = ByteIn[14] + ByteIn[15] * 256;
            Record0.EnsembleStruct.VariableLeader2.XCDRDepth = ByteIn[16] + ByteIn[17] * 256;
            Record0.EnsembleStruct.VariableLeader2.Heading = ByteIn[18] + ByteIn[19] * 256;
            Record0.EnsembleStruct.VariableLeader2.Heading = Record0.EnsembleStruct.VariableLeader.Heading / 100;

            Record0.EnsembleStruct.VariableLeader2.Pitch = ByteIn[20] + ByteIn[21] * 256;
            if (Record0.EnsembleStruct.VariableLeader2.Pitch > 32767) { Record0.EnsembleStruct.VariableLeader.Pitch -= 65536; }  //  SHOULD BE 65635
            Record0.EnsembleStruct.VariableLeader2.Pitch = Record0.EnsembleStruct.VariableLeader.Pitch / 100;

            Record0.EnsembleStruct.VariableLeader2.Roll = ByteIn[22] + ByteIn[23] * 256;
            if (Record0.EnsembleStruct.VariableLeader2.Roll > 32767) { Record0.EnsembleStruct.VariableLeader.Roll -= 65536; }  //  SHOULD BE 65635
            Record0.EnsembleStruct.VariableLeader2.Roll = Record0.EnsembleStruct.VariableLeader.Roll / 100;

            Record0.EnsembleStruct.VariableLeader2.Salinity = ByteIn[24] + ByteIn[25] * 256;
            Record0.EnsembleStruct.VariableLeader2.Temperature = ByteIn[26] + ByteIn[27] * 256;

            if (ByteIn.Length > 50)
            {
                Record0.EnsembleStruct.VariableLeader2.Pressure = ByteIn[51] * 16777216 + ByteIn[50] * 65536 + ByteIn[49] * 256 + ByteIn[48];
            }

            string DateString = Record0.EnsembleStruct.VariableLeader2.DayE + "/" + Record0.EnsembleStruct.VariableLeader2.Month + "/" + Record0.EnsembleStruct.VariableLeader2.Year + " " + Record0.EnsembleStruct.VariableLeader2.Hour + ":" + Record0.EnsembleStruct.VariableLeader2.Minutes + ":" + Record0.EnsembleStruct.VariableLeader2.Secondes + "." + Record0.EnsembleStruct.VariableLeader2.HundredofSecondes;
            Record0.EnsembleStruct.VariableLeader2.EnsTime = DateTime.Parse(DateString, culture);
        }


        ///   Bottom track decoder
        private void DecodeDataBottomTrack(Byte[] ByteIn)
        {
            int[] TempInt = new int[4];
            int[] TempInt2 = new int[4];
            Double[] TempDouble = new Double[4];

            Record0.EnsembleStruct.BottomTrack.PingPerEns = ByteIn[2] + ByteIn[3] * 256;
            Record0.EnsembleStruct.BottomTrack.DelayBeforeReacquire = ByteIn[4] + ByteIn[5] * 256;
            Record0.EnsembleStruct.BottomTrack.CorrMagMin = ByteIn[6];
            Record0.EnsembleStruct.BottomTrack.EvalAmpMin = ByteIn[7];
            Record0.EnsembleStruct.BottomTrack.PercentGoodMin = ByteIn[8];
            Record0.EnsembleStruct.BottomTrack.Mode = ByteIn[9];
            Record0.EnsembleStruct.BottomTrack.ErrorVelMax = ByteIn[10] + ByteIn[11] * 256;
            if (ByteIn.Length > 80)
            {
                Record0.EnsembleStruct.BottomTrack.Range1 = ByteIn[16] + ByteIn[17] * 256 + 65536 * ByteIn[77];
                Record0.EnsembleStruct.BottomTrack.Range2 = ByteIn[18] + ByteIn[19] * 256 + 65536 * ByteIn[78];
                Record0.EnsembleStruct.BottomTrack.Range3 = ByteIn[20] + ByteIn[21] * 256 + 65536 * ByteIn[79];
                Record0.EnsembleStruct.BottomTrack.Range4 = ByteIn[22] + ByteIn[23] * 256 + 65536 * ByteIn[80];
            }
            else
            {
                Record0.EnsembleStruct.BottomTrack.Range1 = ByteIn[16] + ByteIn[17] * 256;// +65536 * ByteIn[77];
                Record0.EnsembleStruct.BottomTrack.Range2 = ByteIn[18] + ByteIn[19] * 256;// +65536 * ByteIn[78];
                Record0.EnsembleStruct.BottomTrack.Range3 = ByteIn[20] + ByteIn[21] * 256;// +65536 * ByteIn[79];
                Record0.EnsembleStruct.BottomTrack.Range4 = ByteIn[22] + ByteIn[23] * 256;// +65536 * ByteIn[80];
            }

            TempDouble[0] = Record0.EnsembleStruct.BottomTrack.Range1;
            TempDouble[1] = Record0.EnsembleStruct.BottomTrack.Range2;
            TempDouble[2] = Record0.EnsembleStruct.BottomTrack.Range3;
            TempDouble[3] = Record0.EnsembleStruct.BottomTrack.Range4;

            Record0.EnsembleStruct.BottomTrack.Ranges = TempDouble;
            Record0.EnsembleStruct.BottomTrack.RangeAverage = AveragedRange(TempDouble);

            Record0.EnsembleStruct.BottomTrack.Velocity1 = ByteIn[24] + ByteIn[25] * 256;
            if (Record0.EnsembleStruct.BottomTrack.Velocity1 > 32767) { Record0.EnsembleStruct.BottomTrack.Velocity1 -= 65536; }
            TempInt[0] = Record0.EnsembleStruct.BottomTrack.Velocity1;

            Record0.EnsembleStruct.BottomTrack.Velocity2 = ByteIn[26] + ByteIn[27] * 256;
            if (Record0.EnsembleStruct.BottomTrack.Velocity2 > 32767) { Record0.EnsembleStruct.BottomTrack.Velocity2 -= 65536; }
            TempInt[1] = Record0.EnsembleStruct.BottomTrack.Velocity2;

            Record0.EnsembleStruct.BottomTrack.Velocity3 = ByteIn[28] + ByteIn[29] * 256;
            if (Record0.EnsembleStruct.BottomTrack.Velocity3 > 32767) { Record0.EnsembleStruct.BottomTrack.Velocity3 -= 65536; }
            TempInt[2] = Record0.EnsembleStruct.BottomTrack.Velocity3;

            Record0.EnsembleStruct.BottomTrack.Velocity4 = ByteIn[30] + ByteIn[31] * 256;
            if (Record0.EnsembleStruct.BottomTrack.Velocity4 > 32767) { Record0.EnsembleStruct.BottomTrack.Velocity4 -= 65536; }
            TempInt[3] = Record0.EnsembleStruct.BottomTrack.Velocity4;

            Record0.EnsembleStruct.BottomTrack.Velocities = TempInt;

            Record0.EnsembleStruct.BottomTrack.Correlation1 = ByteIn[32];
            Record0.EnsembleStruct.BottomTrack.Correlation2 = ByteIn[33];
            Record0.EnsembleStruct.BottomTrack.Correlation3 = ByteIn[34];
            Record0.EnsembleStruct.BottomTrack.Correlation4 = ByteIn[35];
            Record0.EnsembleStruct.BottomTrack.EvaluationAmplitude1 = ByteIn[36];
            Record0.EnsembleStruct.BottomTrack.EvaluationAmplitude2 = ByteIn[37];
            Record0.EnsembleStruct.BottomTrack.EvaluationAmplitude3 = ByteIn[38];
            Record0.EnsembleStruct.BottomTrack.EvaluationAmplitude4 = ByteIn[39];
            Record0.EnsembleStruct.BottomTrack.PercentGood1 = ByteIn[40];
            Record0.EnsembleStruct.BottomTrack.PercentGood2 = ByteIn[41];
            Record0.EnsembleStruct.BottomTrack.PercentGood3 = ByteIn[42];
            Record0.EnsembleStruct.BottomTrack.PercentGood4 = ByteIn[43];
            Record0.EnsembleStruct.BottomTrack.RefLayerMin = ByteIn[44] + ByteIn[45] * 256;
            Record0.EnsembleStruct.BottomTrack.RefLayerNear = ByteIn[46] + ByteIn[47] * 256;
            Record0.EnsembleStruct.BottomTrack.RefLayerFar = ByteIn[48] + ByteIn[49] * 256;
            
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocity1 = ByteIn[50] + ByteIn[51] * 256;
            if (Record0.EnsembleStruct.BottomTrack.RefLayerVelocity1 > 32767) { Record0.EnsembleStruct.BottomTrack.RefLayerVelocity1 -= 65536; }
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocity2 = ByteIn[52] + ByteIn[53] * 256;
            if (Record0.EnsembleStruct.BottomTrack.RefLayerVelocity2 > 32767) { Record0.EnsembleStruct.BottomTrack.RefLayerVelocity2 -= 65536; }
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocity3 = ByteIn[54] + ByteIn[55] * 256;
            if (Record0.EnsembleStruct.BottomTrack.RefLayerVelocity3 > 32767) { Record0.EnsembleStruct.BottomTrack.RefLayerVelocity3 -= 65536; }
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocity4 = ByteIn[56] + ByteIn[57] * 256;
            if (Record0.EnsembleStruct.BottomTrack.RefLayerVelocity4 > 32767) { Record0.EnsembleStruct.BottomTrack.RefLayerVelocity4 -= 65536; }

            Record0.EnsembleStruct.BottomTrack.RefLayerVelocities = TempInt2;
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocities[0] = Record0.EnsembleStruct.BottomTrack.RefLayerVelocity1;
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocities[1] = Record0.EnsembleStruct.BottomTrack.RefLayerVelocity2;
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocities[2] = Record0.EnsembleStruct.BottomTrack.RefLayerVelocity3;
            Record0.EnsembleStruct.BottomTrack.RefLayerVelocities[3] = Record0.EnsembleStruct.BottomTrack.RefLayerVelocity4;

            Record0.EnsembleStruct.BottomTrack.RefLayerCorrelation1 = ByteIn[58];
            Record0.EnsembleStruct.BottomTrack.RefLayerCorrelation2 = ByteIn[59];
            Record0.EnsembleStruct.BottomTrack.RefLayerCorrelation3 = ByteIn[60];
            Record0.EnsembleStruct.BottomTrack.RefLayerCorrelation4 = ByteIn[61];

            Record0.EnsembleStruct.BottomTrack.RefLayerIntensity1 = ByteIn[62];
            Record0.EnsembleStruct.BottomTrack.RefLayerIntensity2 = ByteIn[63];
            Record0.EnsembleStruct.BottomTrack.RefLayerIntensity3 = ByteIn[64];
            Record0.EnsembleStruct.BottomTrack.RefLayerIntensity4 = ByteIn[65];


        }


        private double AveragedRange(double[] Rg)
        {
            double AvG = 0;
            int Divis = 0;
            foreach (double item in Rg)
            {
                if (item != 0) { AvG += item; Divis += 1; }
            }

            if (Divis == 0) { return -32768; }

            return AvG / Divis;
        }



        ///   WinRiver GGA decoder
        Double TempDouble0, TempDouble1, TempDouble2;
        private void DecodeDataWinRiverGGA(Byte[] ByteIn)
        {
            Record0.EnsembleStruct.WinRiverGGA.Header = "Ok";
            string GGAStringtemp = System.Text.Encoding.ASCII.GetString(ByteIn);
            int GGAStart = GGAStringtemp.IndexOf('$');
            int GGAEnd = GGAStringtemp.IndexOf("\r\n");
            if (GGAStart > -1 && GGAEnd > GGAStart)
            {

                Record0.EnsembleStruct.WinRiverGGA.GGAString = GGAStringtemp.Substring(GGAStart, GGAEnd - GGAStart);
                string[] GGATable = Record0.EnsembleStruct.WinRiverGGA.GGAString.Split(',');


                //   no checksum check ?

                int titi = GGATable[1].IndexOf('.');
                string CentSec;
                if (titi == -1)
                { CentSec = "00"; }
                else
                { CentSec = GGATable[1].Substring(titi + 1); }
                Record0.EnsembleStruct.WinRiverGGA.GGATime = new DateTime(1900, 1, 1, Convert.ToInt32(GGATable[1].Substring(0, 2)), Convert.ToInt32(GGATable[1].Substring(2, 2)), Convert.ToInt32(GGATable[1].Substring(4, 2)), Convert.ToInt32(CentSec));

                if (GGATable[2].Length > 1)
                {
                    double.TryParse(GGATable[2], out TempDouble0);
                    TempDouble1 = Math.Floor(TempDouble0 / 100);
                }
                TempDouble2 = TempDouble0 - (TempDouble1 * 100);
                Record0.EnsembleStruct.WinRiverGGA.LatConvertedToDeg = TempDouble1 + (TempDouble2 / 60);
                Record0.EnsembleStruct.WinRiverGGA.NorthSouth = GGATable[3];
                if (GGATable[3] == "S")
                { Record0.EnsembleStruct.WinRiverGGA.LatConvertedToDeg = -Record0.EnsembleStruct.WinRiverGGA.LatConvertedToDeg; }

                if (GGATable[4].Length > 3)
                {
                    double.TryParse(GGATable[4], out TempDouble0);
                    TempDouble1 = Math.Floor(TempDouble0 / 100);
                }
                TempDouble2 = TempDouble0 - (TempDouble1 * 100);
                Record0.EnsembleStruct.WinRiverGGA.LongConvertedToDeg = TempDouble1 + TempDouble2 / 60;
                Record0.EnsembleStruct.WinRiverGGA.EastWest = GGATable[5];
                if (GGATable[5] == "W")
                { Record0.EnsembleStruct.WinRiverGGA.LongConvertedToDeg = -Record0.EnsembleStruct.WinRiverGGA.LongConvertedToDeg; }

                //WinRiverGGA0.
                //WinRiverGGA0.Altitude = int.tryParse(GGATable[9]);
                float.TryParse(GGATable[9], out Record0.EnsembleStruct.WinRiverGGA.Altitude);
                int.TryParse(GGATable[6], out Record0.EnsembleStruct.WinRiverGGA.Quality);
            }
        }



        /// Vmdas Navigation decoder
        private void DecodeVmDasNavigation(Byte[] ByteIn)
        {
            Record0.EnsembleStruct.VmDasNavigation.Header = "Ok";
            //   correct number  0.0000000838190317153931
            DateTime tempD;
            int TempInt;
            DateTime.TryParse(ByteIn[2].ToString() + "/" + ByteIn[3].ToString() + "/" + (ByteIn[4] + ByteIn[5] * 256).ToString(), out tempD);
            Record0.EnsembleStruct.VmDasNavigation.UTCDate = tempD;
            //Record0.EnsembleStruct.VmDasNavigation.UTC_TIME_OF_FIRST_FIX=ByteIn[7]+ByteIn[8]*256+ByteIn[9]*65536+ByteIn[10]*16580608;
            Record0.EnsembleStruct.VmDasNavigation.UTC_TIME_OF_FIRST_FIX = ByteIn[6] + ByteIn[7] * 256 + ByteIn[8] * 65536 + ByteIn[9] * 16777216;

            Record0.EnsembleStruct.VmDasNavigation.PC_CLOCK_OFFSET_FROM_UTC = ByteIn[10] + ByteIn[11] * 256 + ByteIn[12] * 65536 + ByteIn[13] * 16777216;

            //4244832255 / 180 = 23582401.416666666666666666666667;  11791200.70833333333333333333333
            // TempInt = ByteIn[14]+ByteIn[15]*256+ByteIn[16]*65536+ByteIn[17]*16580608;
            TempInt = ByteIn[14] + ByteIn[15] * 256 + ByteIn[16] * 65536 + ByteIn[17] * 16777216;
            // Record0.EnsembleStruct.VmDasNavigation.FIRST_LATITUDE = TempInt / 11791200.70833333333333333333333;
            Record0.EnsembleStruct.VmDasNavigation.FIRST_LATITUDE = TempInt * 0.0000000838190317153931;
            TempInt = ByteIn[18] + ByteIn[19] * 256 + ByteIn[20] * 65536 + ByteIn[21] * 16777216;
            //Record0.EnsembleStruct.VmDasNavigation.FIRST_LONGITUDE = TempInt / 11791200.70833333333333333333333;
            Record0.EnsembleStruct.VmDasNavigation.FIRST_LONGITUDE = TempInt * 0.0000000838190317153931;

            Record0.EnsembleStruct.VmDasNavigation.UTC_TIME_OF_LAST_FIX = ByteIn[22] + ByteIn[23] * 256 + ByteIn[24] * 65536 + ByteIn[25] * 16777216;
            TempInt = ByteIn[26] + ByteIn[27] * 256 + ByteIn[28] * 65536 + ByteIn[29] * 16777216;
            //Record0.EnsembleStruct.VmDasNavigation.LAST_LATITUDE = TempInt / 11791200.70833333333333333333333;
            Record0.EnsembleStruct.VmDasNavigation.LAST_LATITUDE = TempInt * 0.0000000838190317153931;
            TempInt = ByteIn[30] + ByteIn[31] * 256 + ByteIn[32] * 65536 + ByteIn[33] * 16777216;
            //Record0.EnsembleStruct.VmDasNavigation.LAST_LATITUDE = TempInt / 11791200.70833333333333333333333;
            Record0.EnsembleStruct.VmDasNavigation.LAST_LONGITUDE = TempInt * 0.0000000838190317153931;

            Record0.EnsembleStruct.VmDasNavigation.SPEED_MADE_GOOD = (double)(ByteIn[40] + ByteIn[41] * 256) / 1000;
            Record0.EnsembleStruct.VmDasNavigation.DIRECTION_MADE_GOOD = (double)(ByteIn[42] + ByteIn[43] * 256) * 0.005493164;

            //  NMEA FACTOR NUMBER NEEDS TO BE VERIFIED
            Record0.EnsembleStruct.VmDasNavigation.NMEAPitch = (float)((ByteIn[62] + ByteIn[63] * 256) * 0.005493164);
            Record0.EnsembleStruct.VmDasNavigation.NMEARoll = (float)((ByteIn[64] + ByteIn[65] * 256) * 0.005493164);
            Record0.EnsembleStruct.VmDasNavigation.NMEAHeading = (float)((ByteIn[66] + ByteIn[67] * 256) * 0.005493164);

        }


        //  WinRiver   River Ray  surface data
        private void DecodeSurfaceDataLeader(Byte[] ByteIn)
        {
            Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT = ByteIn[2];
            Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_SIZE = ByteIn[3] + ByteIn[4] * 256;
            Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_1_DISTANCE = ByteIn[5] + ByteIn[6] * 256;
        }

        private void DecodeExplorerGGA(Byte[] ByteIn)
        {
            Record0.EnsembleStruct.ExplorerGGAStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 0);
            Record0.EnsembleStruct.ExplorerGGAStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 4);
            Record0.EnsembleStruct.ExplorerGGAStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 8);
            Record0.EnsembleStruct.ExplorerGGAStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 12);
            Record0.EnsembleStruct.ExplorerGGAStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 16);
            Record0.EnsembleStruct.ExplorerGGAStruct0.UTCHours = ByteIn[21];
            Record0.EnsembleStruct.ExplorerGGAStruct0.UTCMinutes = ByteIn[18];
            Record0.EnsembleStruct.ExplorerGGAStruct0.UTCSeconds = ByteIn[19];
            Record0.EnsembleStruct.ExplorerGGAStruct0.UTC100ofSeconds = ByteIn[20];
            Record0.EnsembleStruct.ExplorerGGAStruct0.LatDegrees = ByteIn[23];
            Record0.EnsembleStruct.ExplorerGGAStruct0.LatMinutes = BitConverter.ToInt32(ByteIn, 24);
            Record0.EnsembleStruct.ExplorerGGAStruct0.LongDegrees = ByteIn[31];
            Record0.EnsembleStruct.ExplorerGGAStruct0.LongMinutes = BitConverter.ToInt32(ByteIn, 32);
            Record0.EnsembleStruct.ExplorerGGAStruct0.Quality = ByteIn[36];
            Record0.EnsembleStruct.ExplorerGGAStruct0.NbrStas = ByteIn[37];
            Record0.EnsembleStruct.ExplorerGGAStruct0.HDOP = BitConverter.ToInt32(ByteIn, 24);
            Record0.EnsembleStruct.ExplorerGGAStruct0.Altitude = BitConverter.ToInt32(ByteIn, 24);
            Record0.EnsembleStruct.ExplorerGGAStruct0.GeoidalSep = BitConverter.ToInt32(ByteIn, 24);
            Record0.EnsembleStruct.ExplorerGGAStruct0.DiffAge = BitConverter.ToInt32(ByteIn, 24);
            Record0.EnsembleStruct.ExplorerGGAStruct0.DiffRef = BitConverter.ToInt32(ByteIn, 24);
        }

        private void DecodeExplorerVTG(Byte[] ByteIn)
        {
            Record0.EnsembleStruct.ExplorerVTGStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 0);
            Record0.EnsembleStruct.ExplorerGGAStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 4);
            Record0.EnsembleStruct.ExplorerGGAStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 8);
            Record0.EnsembleStruct.ExplorerGGAStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 12);
            Record0.EnsembleStruct.ExplorerGGAStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 16);
            Record0.EnsembleStruct.ExplorerVTGStruct0.TrueGroundCourse = BitConverter.ToInt32(ByteIn, 16);
            Record0.EnsembleStruct.ExplorerVTGStruct0.MagGroundCourse = BitConverter.ToInt32(ByteIn, 16);
            Record0.EnsembleStruct.ExplorerVTGStruct0.GroundSpeedKnots = BitConverter.ToInt32(ByteIn, 16);
            Record0.EnsembleStruct.ExplorerVTGStruct0.GroundSpeedKm = BitConverter.ToInt32(ByteIn, 16);

        }





        // Decode profiles

        int[] TempInt;
        int[][] tempbuffer;
        int[] TempVelInt;
        int NbrDepthCells;
        int NbrBeams;
        int TempInt1;
        VelocityStruct TempVel = new VelocityStruct();
        //  Velocity profile decoder  data  2 bytes signed
        private VelocityStruct DecodeDataProfile2bytes(Byte[] ByteIn, int DataID, string DataName)
        {

            TempVel.ID = DataID;
            TempVel.DisplayName = DataName;
            switch (Record0.EnsembleStruct.FixedLeader.CoordinateSystem)
            {
                case CoordinateSystemEnum.Earth:
                    TempVel.Data1Name = "Vel east";
                    TempVel.Data2Name = "Vel North";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Ship:
                    TempVel.Data1Name = "Vel accross";
                    TempVel.Data2Name = "Vel along";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Instrument:
                    TempVel.Data1Name = "Vel beam 3-4";
                    TempVel.Data2Name = "Vel beam 2-1";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Beam:
                    TempVel.Data1Name = "Vel beam 1";
                    TempVel.Data2Name = "Vel beam 2";
                    TempVel.Data3Name = "Vel beam 3";
                    TempVel.Data4Name = "Vel beam 4";
                    break;
            }



            //  do not use number of beams !!!
            NbrBeams = Record0.EnsembleStruct.FixedLeader.NbrBeam;
            NbrBeams = 4;
            NbrDepthCells = Record0.EnsembleStruct.FixedLeader.NumberOfDepthCells;

            if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }

            tempbuffer = new int[NbrBeams][];
            //TempInt = new int[NbrDepthCells];
            TempInt = new int[NbrBeams];
            TempVelInt = new int[NbrBeams * NbrDepthCells];

            for (int i = 0; i < NbrBeams; i++)
            {
                tempbuffer[i] = new int[NbrDepthCells];
            }

            for (int j = 0; j < NbrDepthCells; j++)
            {
                for (int i = 0; i < NbrBeams; i++)
                {
                    TempInt1 = i * 2 + j * 2 * NbrBeams;
                    TempInt[i] = ByteIn[TempInt1 + 2] + 256 * ByteIn[TempInt1 + 3];
                    if (TempInt[i] > 32767) { TempInt[i] = TempInt[i] - 65536; }
                    tempbuffer[i][j] = TempInt[i];
                    TempVelInt[i + NbrBeams * j] = tempbuffer[i][j];
                }
            }

            TempVel.Velocity = tempbuffer;
            TempVel.Velocities = TempVelInt;
            return TempVel;
        }

        private VelocityStruct DecodeDataProfile2bytes2(Byte[] ByteIn, int DataID, string DataName)
        {

            TempVel.ID = DataID;
            TempVel.DisplayName = DataName;
            switch (Record0.EnsembleStruct.FixedLeader2.CoordinateSystem)
            {
                case CoordinateSystemEnum.Earth:
                    TempVel.Data1Name = "Vel east";
                    TempVel.Data2Name = "Vel North";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Ship:
                    TempVel.Data1Name = "Vel accross";
                    TempVel.Data2Name = "Vel along";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Instrument:
                    TempVel.Data1Name = "Vel beam 3-4";
                    TempVel.Data2Name = "Vel beam 2-1";
                    TempVel.Data3Name = "Vel Up";
                    TempVel.Data4Name = "Vel error";
                    break;
                case CoordinateSystemEnum.Beam:
                    TempVel.Data1Name = "Vel beam 1";
                    TempVel.Data2Name = "Vel beam 2";
                    TempVel.Data3Name = "Vel beam 3";
                    TempVel.Data4Name = "Vel beam 4";
                    break;
            }



            //  do not use number of beams !!!
            NbrBeams = Record0.EnsembleStruct.FixedLeader2.NbrBeam;
            NbrBeams = 4;
            NbrDepthCells = Record0.EnsembleStruct.FixedLeader2.NumberOfDepthCells;

            if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }

            tempbuffer = new int[NbrBeams][];
            //TempInt = new int[NbrDepthCells];
            TempInt = new int[NbrBeams];
            TempVelInt = new int[NbrBeams * NbrDepthCells];

            for (int i = 0; i < NbrBeams; i++)
            {
                tempbuffer[i] = new int[NbrDepthCells];
            }

            for (int j = 0; j < NbrDepthCells; j++)
            {
                for (int i = 0; i < NbrBeams; i++)
                {
                    TempInt1 = i * 2 + j * 2 * NbrBeams;
                    TempInt[i] = ByteIn[TempInt1 + 2] + 256 * ByteIn[TempInt1 + 3];
                    if (TempInt[i] > 32767) { TempInt[i] = TempInt[i] - 65536; }
                    tempbuffer[i][j] = TempInt[i];
                    TempVelInt[i + NbrBeams * j] = tempbuffer[i][j];
                }
            }

            TempVel.Velocity = tempbuffer;
            TempVel.Velocities = TempVelInt;
            return TempVel;
        }


        private int[][] DecodeDataProfile1bytes(Byte[] ByteIn, int DataID, string DataName)
        {
            NbrBeams = Record0.EnsembleStruct.FixedLeader.NbrBeam;
            //  do not use number of beams
            NbrBeams = 4;
            NbrDepthCells = Record0.EnsembleStruct.FixedLeader.NumberOfDepthCells;

            if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.EnsembleStruct.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }


            tempbuffer = new int[NbrBeams][];
            //TempInt = new int[NbrDepthCells];
            TempInt = new int[NbrBeams];

            for (int i = 0; i < NbrBeams; i++)
            {
                tempbuffer[i] = new int[NbrDepthCells];
            }

            for (int j = 0; j < NbrDepthCells; j++)
            {
                for (int i = 0; i < NbrBeams; i++)
                {
                    TempInt1 = i + j * NbrBeams;
                    TempInt[i] = ByteIn[TempInt1 + 2];
                    if (TempInt[i] > 32767) { TempInt[i] = TempInt[i] - 65536; }
                    tempbuffer[i][j] = TempInt[i];
                }
            }


            return tempbuffer;
        }

        #endregion

        #region Decode packet
        private bool DecodePacket(byte[] TempsRecord0)
        {

            return true;
        }

        #endregion

        #endregion

        public class ReadFile
        {
            public string FilePath
            { get { return File_path0; } }

            public long CurrentPositionInFile
            { get { return CurrentPositionInFile0; } }

            public long FileSize
            { get { return FileSize0; } }

            public int CurrentRecordSize
            { get { return CurrentRecordSize0; } }

            public byte[] CurrentPlaybackRecord
            { get { return CurrentRecord0; } }

            public RecordType CurrentRecordType
            { get { return CurrentRecordType0; } }

            //  Public Method
            public RecordType GetFirstRecord()
            {
                return Get_Record(0);
            }

            public RecordType GetNextRecord()
            {
                return Get_Record(CurrentPositionInFile0);
            }

            public RecordType GetPreviousRecord()
            {
                return Get_Record(CurrentPositionInFile0 - (CurrentRecordSize0 * 2));
            }

            public void CloseFile()
            {
                r0.Close();
                fs0.Close();
            }

            //  class  read file constructor
            internal ReadFile(string File_path00)
            {
                File_path0 = File_path00;

                if (File.Exists(File_path0))
                {
                    fs0 = new FileStream(File_path0, FileMode.Open, FileAccess.Read, FileShare.Read);
                    FileSize0 = fs0.Length;
                    r0 = new BinaryReader(fs0);
                }

            }


            //private Dictionary<int, string> RefDataType0 = new Dictionary<int, string>();
            //  Variable associated to properties
            private string File_path0;
            private long FileSize0;
            private long CurrentPositionInFile0;
            private int CurrentRecordSize0;
            private byte[] CurrentRecord0;
            private RecordType CurrentRecordType0;

            //  variable de fonctionnement
            private FileStream fs0;
            private BinaryReader r0;

            //private long Last_Ens_Position = 0;

            private RecordType Get_Record(long Pos5)
            {

                byte[] TempRecord = null;
                byte byte0;
                byte byte1;
                long TempPos = Pos5;

                if (Pos5 < 0) { Pos5 = 0; }
                fs0.Position = Pos5;


                byte TempRecordSize0;
                byte TempRecordSize1;
                int TempRecordSize = 0;

                for (int i = 0; i < fs0.Length; i++)
                {
                    try
                    {

                        byte0 = r0.ReadByte();
                        TempPos = fs0.Position;
                        byte1 = r0.ReadByte();

                        //  Case ensemble         //  search  for ensemble
                        if (byte0 == 127 && byte1 == 127)
                        {
                            TempRecordSize0 = r0.ReadByte();
                            TempRecordSize1 = r0.ReadByte();
                            TempRecordSize = TempRecordSize1 * 256 + TempRecordSize0 + 2;
                            if (TempRecordSize > 9000 | TempRecordSize < 7) { TempRecordSize = 7; }
                            TempRecord = new byte[TempRecordSize];
                            TempRecord[0] = 127;
                            TempRecord[1] = 127;
                            TempRecord[2] = TempRecordSize0;
                            TempRecord[3] = TempRecordSize1;
                            r0.Read(TempRecord, 4, TempRecordSize - 4);

                            if (ChecksumVerify(TempRecord))
                            {
                                CurrentRecordSize0 = TempRecordSize;
                                CurrentRecord0 = TempRecord;
                                CurrentRecordType0 = RecordType.Ensemble;
                                CurrentPositionInFile0 = fs0.Position;
                                return CurrentRecordType0;
                            }
                            else
                            {
                                TempRecordSize = 0;
                                CurrentRecord0 = null; ;
                                CurrentRecordType0 = RecordType.None;
                                CurrentPositionInFile0 = TempPos;
                                //   ne retourne pas d'info, refait la boucle while
                                //return CurrentRecordType0;
                            }

                        }

                            //  Waves Record
                        else if (byte0 == 127 && byte1 == 121)
                        {

                            TempRecord = null;
                            TempRecordSize0 = r0.ReadByte();   //  offset to checksum 1
                            TempRecordSize1 = r0.ReadByte();   //  offset to checksum 2
                            TempRecordSize = TempRecordSize1 * 256 + TempRecordSize0 + 2;

                            TempRecord = new byte[TempRecordSize];
                            //  faire verification que OffsetToCheckSumm > 3
                            TempRecord[0] = 127;
                            TempRecord[1] = 121;
                            TempRecord[2] = TempRecordSize0;        //  offset to checksum 1
                            TempRecord[3] = TempRecordSize1;        //  offset to checksum 2
                            //TempPacket[4] = r0.ReadByte();  //  Spare
                            //TempPacket[5] = r0.ReadByte();  //  Nbr data type                     
                            r0.Read(TempRecord, 4, TempRecordSize - 4);

                            //  verifie checksum
                            //TempChecksum0 = r0.ReadByte();
                            //TempChecksum1 = r0.ReadByte();
                            //TempChecksum = TempChecksum1 * 256 + TempChecksum0;

                            if (ChecksumVerify(TempRecord))
                            {
                                CurrentRecordSize0 = TempRecordSize;
                                CurrentRecord0 = TempRecord;
                                CurrentRecordType0 = RecordType.WavePacket;
                                CurrentPositionInFile0 = fs0.Position;

                                return CurrentRecordType0;
                            }
                            else
                            {
                                TempRecordSize = 0;
                                CurrentRecord0 = null; ;
                                CurrentRecordType0 = RecordType.None;
                                CurrentPositionInFile0 = TempPos;
                                //   ne retourne pas d'info, refait la boucle while
                                //return CurrentRecordType0;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (e is EndOfStreamException)
                        {
                            return RecordType.EndFile;
                        }
                        return RecordType.ProcessError;
                    }
                }
                return RecordType.None;
            }

        }

        public class RealTime
        {

            public byte[] CurrentRealTimeRecord
            { get { return CurrentRecord0; } }

            public RecordType CurrentRecordType
            { get { return CurrentRecordType0; } }

            public RecordType AddByteToBufferIN(Byte[] Input)
            {
                //AddByteAndAnalyseBuffer(Input);
                return AddByteAndAnalyseBuffer(Input);
            }

            //private Dictionary<int, string> RefDataType0 = new Dictionary<int, string>();
            //  Variable associated to properties
            private List<Byte> BufferIn = new List<Byte>();
            //private int CurrentRecordSize0;
            private byte[] CurrentRecord0;
            private RecordType CurrentRecordType0;
            //private int TempByteLoc;
            private int EnsSize;


            private RecordType AddByteAndAnalyseBuffer(byte[] BytesIN)
            {
                BufferIn.AddRange(BytesIN);

                if (BufferIn.Count < 10) { return Class_PD0.RecordType.None; }


                //  Search for ensemble in Buffer
                int Index127 = SearchBuffer(0);
                if (Index127 > BufferIn.Count - 4) { return Class_PD0.RecordType.None; }

                if (Index127 != -1)
                {
                    //   check for ensemble
                    EnsSize = BufferIn[Index127 + 3] * 256 + BufferIn[Index127 + 2] + 2;
                    if (BufferIn.Count < EnsSize + Index127) { return Class_PD0.RecordType.None; }
                    // CurrentRecord0 = new Byte[EnsSize];
                    CurrentRecord0 = BufferIn.GetRange(Index127, EnsSize).ToArray();

                    if (ChecksumVerify(CurrentRecord0))
                    {
                        CurrentRecordType0 = Class_PD0.RecordType.Ensemble;
                        BufferIn.RemoveRange(0, Index127 + EnsSize);
                        return CurrentRecordType0;
                    }
                    else
                    {
                        BufferIn.RemoveRange(0, Index127 + 2);
                    }
                }

                return Class_PD0.RecordType.None;
            }


            int tempIndex;
            private int SearchBuffer(int IndexIn)
            {
                while (IndexIn < BufferIn.Count)
                {
                    IndexIn = BufferIn.FindIndex(IndexIn, Byte127);
                    if (IndexIn == -1) { return -1; }
                    tempIndex = BufferIn.FindIndex(IndexIn + 1, Byte127);
                    if (tempIndex == -1) { return -1; }
                    if (tempIndex == IndexIn + 1) { return IndexIn; }
                    IndexIn = tempIndex + 1;
                }
                return -1;
            }

            private bool Byte127(Byte toto)
            {
                if (toto == 127) { return true; }
                else { return false; }
            }



        }

        public class RotateBeam2Inst
        {
            double a, b, d;
            //   constructor
            public  RotateBeam2Inst(int BeamAng)
            {
                double BeamAngRad = Math.PI * BeamAng / 180;
                a = (double)(1 / (2 * Math.Sin(BeamAngRad)));
                b = (double)(1 / (4 * Math.Cos(BeamAngRad)));
                d = (double)(a / (Math.Pow(2, 0.5)));
                if (BeamAng == 30) { a = 1; }
            }

            public byte[] Rotate(byte[] EnsIn)
            { 
                byte[] EnsOut = new  byte[EnsIn.Length];
                Array.Copy(EnsIn, EnsOut, EnsIn.Length);
                
                
                return EnsOut;
            }
        }




        #region Utils

        //////////////////  Calculate PD0 binary checksum   
        private static int ChecksumCompute(byte[] Ens0)
        {
            //  verify checksum
            int CalculatedCheckSum = 0;
            for (int i = 0; (i <= (Ens0.Length - 3)); i++)
            {
                CalculatedCheckSum = (CalculatedCheckSum + Ens0[i]);
            }
            CalculatedCheckSum = (65535 & CalculatedCheckSum);
            return CalculatedCheckSum;
        }

        private static bool ChecksumVerify(Byte[] EnsIn)
        {
            int TempCheckSum = EnsIn[EnsIn.Length - 2] + EnsIn[EnsIn.Length - 1] * 256;

            return (TempCheckSum == ChecksumCompute(EnsIn));
        }

        private byte[] ChecksumAdjust0(byte[] EnsIn)
        {
            //  ReCalculate checksum
            int tempLSB;
            int tempMSB;
            int EnsInLength = EnsIn.Length;
            byte[] EnsOut = EnsIn;

            EnsOut[EnsInLength - 2] = 0;
            EnsOut[EnsInLength - 1] = 0;
            int Newchecksum = ChecksumCompute(EnsOut);
            tempMSB = Math.DivRem(Newchecksum, 256, out tempLSB);
            EnsOut[EnsInLength - 2] = (byte)tempLSB;
            EnsOut[EnsInLength - 1] = (byte)tempMSB;
            return EnsOut;

        }


        //////////////////  Calculate PD0 binary checksum   //////////////////


        //   Detect ADCP data file
        private bool IsADCPDataFile0(string FileP)
        {
            bool YesNo = true;
            Class_PD0 PD1 = new Class_PD0();
            Class_PD0.ReadFile PD1Read = new Class_PD0.ReadFile(FileP);
            Class_PD0.RecordType PD1RecordType = PD1Read.GetFirstRecord();
            if (PD1RecordType == Class_PD0.RecordType.EndFile || PD1RecordType == Class_PD0.RecordType.None || PD1RecordType == Class_PD0.RecordType.ProcessError)
            { YesNo = false; }

            PD1 = null;
            PD1Read = null;

            return YesNo;
        }

        #endregion


        #region Brouillons


        public EnsembleStruct AverageEns(EnsembleStruct[] EnsIn)
        { return Averaged(EnsIn); }



        //  average ensemble
        private EnsembleStruct Averaged(EnsembleStruct[] EnsIn0)
        {
            int NbrEnsToAverage = EnsIn0.Length;
            //  Paraneters to average
            EnsembleStruct Averaged2;

            Averaged2 = EnsIn0[0];

            for (int i = 0; i < NbrEnsToAverage; i++)
            {
                Averaged2.VariableLeader.Heading += EnsIn0[i].VariableLeader.Heading;
            }

            Averaged2.VariableLeader.Heading = (float)(Averaged2.VariableLeader.Heading / NbrEnsToAverage);

            return Averaged2;
        }


        #endregion


        // byte[] InputBuffer0 = new byte[3];

        //Byte[] CurrentRecordByte0;

        //RecordType CurrentRecordType0;



        //Byte[] LastEnsembleByte0;
        //EnsembleStruct Record0.EnsembleStruct;

        //Byte[] LastWavesPacketByte0;
        //FullBurstStruct FullBurst0;
        //FullWavesLeaderStruct FullWavesLeader0;
        //FullWavesPacketWavesPingStruct FullWavesPacketWavesPing0;
        //FullWavesPacketsLastLeaderStruct FullWavesPacketsLastLeader0;


        //  Ensemble
        //public Byte[] LastEnsembleByte
        //{ get { return LastEnsembleByte0; } }

        // public EnsembleStruct Ensemble
        // { get { return Record0.EnsembleStruct; } }




    }
}

