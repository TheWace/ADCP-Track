using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace BottomTrackExport
{
    public class Class_PD0_55
    {

        #region Public

                public Class_PD0_55()
                { Load_Data_Type0(); }

                /// <summary>
                /// Open file and look for first ensemble
                /// </summary>
                /// <param name="FilePath"></param>
                /// <returns></returns>
                public bool FileOpen(string  FilePath)
                {
                    return ReadFile0(FilePath);
                }

                public bool Fileclose()
                {
                    return CloseFile0();
                }



                /// <summary>
                /// read next ensemble
                /// </summary>
                public bool  FileReadNext()
                {
                    return Get_RecordNext0();
                }

                // Read previous ensemble
                public bool FileReadPrevious()
                {
                   return  Get_RecordPrevious0();
                }


                /// <summary>
                /// Read first ensemble
                /// </summary>
                /// <returns></returns>
                public bool FileReadFirst()
                {
                    return Get_RecordFirst0();
                }



                /// <summary>
                ///  raise event when record is found
                /// </summary>
                /// <param name="BytesIn"></param>
                /// 

                public delegate void IORecordReceived(Object sender, byte[] e);
                public event IORecordReceived RecordReceivedEvent;


                public void AddtoBuffer(byte[] BytesIn)
                {                    AddBufferIN0(BytesIn);                }


                public Record DecodeCurrentRecord()
                {
                    DecodeRecord0(CurrentRecord0);
                    return Record0;
                }


                public byte[] AdjustChecksum(byte[] BytesIn)
                {
                    return ChecksumAdjust0(BytesIn);
                }

        #endregion

        #region Properties

                public int EnsembleSize
                { get { return EnsembleSize0; } }

                public long PositionInFile
                { get { return EnsembleSize0; } }

                public Record CurRecord
                { get { return Record0; } }

                public RawRecord CurRawRecord
                { get { return RawRecord0; } }

                public string PlaybackFile
                { get { return File_Path0; } }

        #endregion

        #region Private_Variable

            public enum RecordTypeEnum { None, Ensemble, WavePacket, EndFile, ProcessError,record }
            public enum CoordinateSystemEnum { Beam, Instrument, Ship, Earth };
            public enum PacketTypeEnum { None, FirstLeader, WavesPacket, LastLeader }

            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            private Dictionary<int, string> RefDataType0 = new Dictionary<int, string>();
            private Dictionary<int, bool> RefDataTypeYesNo0 = new Dictionary<int, bool>();

            private int EnsembleSize0=-1;
            private RawRecord RawRecord0;
            private byte[] CurrentRecord0;
            private Record Record0;

        //   variable used for real time 
            private List<Byte> BufferIn = new List<Byte>();

        //  variables used in playback

            private String File_Path0="-1";
            private double FileSize0 = -1;

            private FileStream fs0;
            // BufferedStream fs0;
            //private BinaryReader r0;
            private long PositionInFile0 = -1;
        
        
        #endregion

        #region Private_method

            /// <summary>
            /// Load table used to read data
            /// </summary>
            private void Load_Data_Type0()
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

                
            //River Ray  
            RefDataType0.Add(0x0010, "Surface Layer Leader"); //16
            RefDataType0.Add(0x0110, "Surface Layer Velocity"); //272
            RefDataType0.Add(0x0210, "Surface Correlation Magnitude"); //528
            RefDataType0.Add(0x0310, "Surface Echo Intensity"); //784
            RefDataType0.Add(0x0410, "Surface Percent-Good"); //1040
            RefDataType0.Add(0x0510, "Surface Status"); //1296

            RefDataType0.Add(0x4400, "Firmware Status"); //17408            
            RefDataType0.Add(0x4401, "Automatic Mode Setup"); //17409
            RefDataType0.Add(0x4100, "Vertical beam Range"); //1296

            RefDataType0.Add(0x2000, "VmDas Navigation");           //8192
            RefDataType0.Add(0x2022, "NMEA structure");     //8226   /////////////////////////////    
            RefDataType0.Add(1048226, "WinRiver 2+ GGA");
            RefDataType0.Add(1058226, "WinRiver 2+ VTG");
            RefDataType0.Add(1068226, "WinRiver 2+ DBT");
            RefDataType0.Add(1078226, "WinRiver 2+ HDT");

            RefDataType0.Add(0x2100, "WinRiver II  NMEA  $xxDBT");  //844

            RefDataType0.Add(0x2101, "WinRiver GGA (GPS) Data");    //8449     ///
            RefDataType0.Add(0x2102, "WinRiver VTG (GPS) Data");    //8450
            RefDataType0.Add(0x2103, "WinRiver GSA (GPS) Data");    //8451

            RefDataType0.Add(0x5411, "Explorer GGA");  // 21521
            RefDataType0.Add(0x5416, "Explorer VTG"); //  21526
            RefDataType0.Add(0x5404, "Explorer HDT"); //  21508
            RefDataType0.Add(0x5410, "Explorer RMC"); //  21520

            RefDataType0.Add(0x3200, "type 3200"); //   12800

            RefDataTypeYesNo0.Add(0x000, false);
            RefDataTypeYesNo0.Add(0x001, false);
            RefDataTypeYesNo0.Add(0x0080, false);   //128
            RefDataTypeYesNo0.Add(0x0081, false);
            RefDataTypeYesNo0.Add(0x0100, false);   // 256
            RefDataTypeYesNo0.Add(0x0101, false);
            RefDataTypeYesNo0.Add(0x0200, false);   //512
            RefDataTypeYesNo0.Add(0x0201, false);
            RefDataTypeYesNo0.Add(0x0300, false);   // 768
            RefDataTypeYesNo0.Add(0x0301, false);
            RefDataTypeYesNo0.Add(0x0400, false);   //  1024
            RefDataTypeYesNo0.Add(0x0401, false);
            RefDataTypeYesNo0.Add(0x0500, false);
            RefDataTypeYesNo0.Add(0x0600, false);   //  1536
            RefDataTypeYesNo0.Add(0x0800, false);   //  2048
            RefDataTypeYesNo0.Add(0x2000, false);   //  8192
            RefDataTypeYesNo0.Add(0x2101, false);   //  8449
            RefDataTypeYesNo0.Add(0x2102, false);   //  8450
            RefDataTypeYesNo0.Add(0x2103, false);   //  8451

            RefDataTypeYesNo0.Add(0x2022, false);   //8226      WinRiver2  GGA ???
            RefDataTypeYesNo0.Add(1048226, false);   //8226      WinRiver2  GGA 
            RefDataTypeYesNo0.Add(1058226, false);   //8226      WinRiver2  VTG 
            RefDataTypeYesNo0.Add(1068226, false);   //8226      WinRiver2  DBT 
            RefDataTypeYesNo0.Add(1078226, false);   //8226      WinRiver2  HDT 

            RefDataTypeYesNo0.Add(0x2100, false);  //8448
            //RefDataTypeYesNo0.Add(0x2101, "WinRiver II  NMEA  $xxGGA");  // 
            //RefDataTypeYesNo0.Add(0x2102, "WinRiver II  NMEA  $xxVTG");
            //RefDataTypeYesNo0.Add(0x2104, "WinRiver II  NMEA  $xxHDT");

            RefDataTypeYesNo0.Add(0x0010, false); //16
            RefDataTypeYesNo0.Add(0x0110, false); //272
            RefDataTypeYesNo0.Add(0x0210, false); //528
            RefDataTypeYesNo0.Add(0x0310, false); //784
            RefDataTypeYesNo0.Add(0x0410, false); //1040
            RefDataTypeYesNo0.Add(0x0510, false); //1296
            RefDataTypeYesNo0.Add(0x4401, false); //17409
            RefDataTypeYesNo0.Add(0x4400, false); //17408
            RefDataTypeYesNo0.Add(0x5411, false);  // 21521
            RefDataTypeYesNo0.Add(0x5416, false); //  21526
            RefDataTypeYesNo0.Add(0x5404, false); //  21508
            RefDataTypeYesNo0.Add(0x5410, false); //  21520

            RefDataTypeYesNo0.Add(0x4100, false); //  21526
            RefDataTypeYesNo0.Add(0x3200, false); //  21508
            //RefDataTypeYesNo0.Add(0x2022, false); //  21520


        }

            /// <summary>
            /// Real time data process.
            /// </summary>
            /// <param name="ByteIn"></param>
            /// 
            private int RecordSizeRT;
            private byte[] CurrentRecordRT;

            private void AddBufferIN0(byte[] ByteIn)
            {
                if (ByteIn != null) { BufferIn.AddRange(ByteIn); }

                int EnsStart = BufferIn.FindIndex(0, Byte127);   ////   ca ne marchera pas pour les waves !!!!!!
                ///// pas de debut d'ensemble trouvé.
                if (EnsStart == -1)
                { 
                    BufferIn.Clear(); // vide le buffer
                    return; //   fini la fonction
                }

                //  enlève tous les byte precedant le marquer de debut d'ensemble.
                BufferIn.RemoveRange(0, EnsStart);

                //   127 a ete trouve, cherche ensemble.
                if (BufferIn[1] == 127 || BufferIn[ 1] == 121)
                {
                    //  determine la taille du record.
                    RecordSizeRT = BufferIn[3] * 256 + BufferIn[ 2] + 2;
                    // verifie assez de bytes ds le buffer pour l'ensemble entier
                    if (RecordSizeRT > BufferIn.Count)
                    { // attendre prochaine arrivée de donnée
                        return;
                    }

                    CurrentRecordRT = BufferIn.GetRange(0, RecordSizeRT).ToArray();
                    if (ChecksumVerify0(CurrentRecordRT))
                    {
                        BufferIn.RemoveRange(0, RecordSizeRT);
                        //
                        CurrentRecord0 = CurrentRecordRT;
                        //  raiseEvent Record found
                        RecordReceivedEvent(this, CurrentRecordRT);
                    }
                    else
                    {
                        BufferIn.RemoveRange(0, 1);
                        AddBufferIN0(null);
                    }

                }
                else   //   si le bit suivant n'est pas 127 ou 121
                {
                    BufferIn.RemoveAt(0);
                    AddBufferIN0(null);  // relance la fonction
                }

            }

            /// <summary>
            /// Playback data process
            /// </summary>
            /// <param name="File_path0"></param>
            private bool ReadFile0(string File_path0)
            {
                try
                {
                    File_Path0 = File_path0;
                    
                    fs0 = new FileStream(File_path0, FileMode.Open, FileAccess.Read, FileShare.Read);
                    //BufferedStream fs0 = new BufferedStream(fs1);
                    FileSize0 = fs0.Length;

                    //   addded for file that does not start by a record : 
                    int TempByte=fs0.ReadByte();
                    while (TempByte!=127 && TempByte!=121)
	                {
                        TempByte = fs0.ReadByte();
	                }

                    if (Get_Record0(fs0.Position - 1).RecordTypeR == RecordTypeEnum.record) { return true; }
                }
                catch (Exception Ex)
                { 
                    //ClassSaveErrorLog.SaveError(Ex.Message, Ex.ToString(), "Class PD0 line 264 ");
                    System.Windows.Forms.MessageBox.Show(Ex.Message);
                }
                return false;
             }

            private bool CloseFile0()
            {
                if (fs0 != null)
                { fs0.Close(); fs0 = null;  return true; }
                else
                { System.Windows.Forms.MessageBox.Show("Open File first !"); return false; }
            }

            private RawRecord Get_Record0(long Pos5)
            {
                
                byte[] TempRecord = null;
                int Int0, Int1, TempRecordSize0, TempRecordSize1;
                
                int TempRecordSize = 0;

                
                RawRecord0.RecordTypeR = RecordTypeEnum.None;
                RawRecord0.RecordByteR = TempRecord;

                if (Pos5 < 0) { Pos5 = 0; }
                if (Pos5 > fs0.Length - 5)
                { RawRecord0.RecordTypeR = RecordTypeEnum.EndFile; CurrentRecord0 = null; return RawRecord0; }
               
                for (int i = 0; i < fs0.Length; i++)
                {
                    fs0.Position = Pos5;
                    try
                    {
                        Int0=fs0.ReadByte();
                        if (Int0==127)
                        {
                            Int1=fs0.ReadByte();
                            if (Int1 == 127 || Int1 == 121)
                            {
                                TempRecordSize0 = fs0.ReadByte();
                                TempRecordSize1 = fs0.ReadByte();
                                TempRecordSize = TempRecordSize1 * 256 + TempRecordSize0 + 2;
                                TempRecord = new byte[TempRecordSize];
                                fs0.Read(TempRecord, 4, TempRecordSize - 4);

                                TempRecord[0] = (byte)Int0;
                                TempRecord[1] = (byte)Int1;
                                TempRecord[2] = (byte)TempRecordSize0;
                                TempRecord[3] = (byte)TempRecordSize1;

                                if (ChecksumVerify0(TempRecord))
                                {
                                    RawRecord0.RecordTypeR = RecordTypeEnum.record;
                                    RawRecord0.RecordByteR = TempRecord;
                                    EnsembleSize0 = TempRecord.Length;
                                    PositionInFile0 = fs0.Position;
                                    CurrentRecord0 = TempRecord;
                                    return RawRecord0;
                                }
                                else
                                {
                                    RawRecord0.RecordTypeR = RecordTypeEnum.ProcessError;
                                    PositionInFile0 = fs0.Position;
                                }
                            } 
                        }
                        Pos5 += 1;
                    }
                    catch (Exception e)
                    {
                        if (e is EndOfStreamException)
                        { RawRecord0.RecordTypeR = RecordTypeEnum.EndFile; }

                        RawRecord0.RecordTypeR = RecordTypeEnum.None;
                        return RawRecord0;
                    }
                }
                RawRecord0.RecordTypeR = RecordTypeEnum.ProcessError;
                return RawRecord0;
            }

            //  read First
            private bool Get_RecordFirst0()
            {
                if (fs0 != null)
                {
                    Get_Record0(0);
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Open File first !");
                    return false;
                }
            }

            //  read Next
            private bool Get_RecordNext0()
            {
                if (fs0!=null)
                {
                    Get_Record0(PositionInFile0 );
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Open File first !");
                    return false;
                }
            }

            //  Read previous  //   attention aux changement ensembles packets
            private bool Get_RecordPrevious0()
            {
                if (fs0 != null)
                {
                    Get_Record0(PositionInFile0 - (2*EnsembleSize0));
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Open File first !");
                    return false;
                }
            }

            private bool Byte127(Byte toto)
            {
                if (toto == 127) { return true; }
                else { return false; }
            }

            private bool Byte121(Byte toto)
            {
                if (toto == 121) { return true; }
                else { return false; }
            }

        //////////////////////////////////////////Structures  ///////////////////////////////////
            public struct RawRecord
            {
                public RecordTypeEnum RecordTypeR;
                public Byte[] RecordByteR;
            }

            #region recordStructure
                public struct Record
                {
                    public RecordTypeEnum RecordType;
                    public EnsembleStruct Ensemble;
                    public PacketStruct Packet;
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
                public ExplorerHDTStruct ExplorerHDTStruct0;
                public ExplorerRMCStruct ExplorerRMCStruct0;

                public RiverPro_NMEA_INT_GGA RiverPro_NMEA_INT_GGA0;
                public RiverPro_NMEA_GGA RiverPro_NMEA_GGA0;
                public RiverPro_NMEA_HDT RiverPro_NMEA_HDT0;
                public RiverPro_NMEA_DBT RiverPro_NMEA_DBT0;
                ///  public Dictionary<int,bool> 
                
            }

            public struct DescriptionStruct
            {
                public int EnsembleSize;
                public int NbrDataType;
                public int[] DataTypeID;
                public int[] DataTypeOffset;
                public int[] DataTypeNbrBytes;
                public string[] DataTypeName;
                public Dictionary<int, int> ID2Offset;
                public Dictionary<int, Byte[]> ID2Byte;
                public Dictionary<int, bool> RefDataTypePresent;
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
                public Double[] Ranges; //=new double[4];
                public double[] Velocities; //=new int[4];
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
                public int RefLayerDistanceToMiddle;
                public double[] RefLayerVelocities;//  = new int[4];
                public int RefLayerCorrelation1;
                public int RefLayerCorrelation2;
                public int RefLayerCorrelation3;
                public int RefLayerCorrelation4;
                public int RefLayerIntensity1;
                public int RefLayerIntensity2;
                public int RefLayerIntensity3;
                public int RefLayerIntensity4;

                //public BottomTrackStruct()
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


            public struct RiverPro_NMEA_INT_GGA
            {
                public int NMEAIdCode;
                public int NMEAMessageId;

                public DateTime UTCtime;
                public double Latitude;
                public char NS;
                public double Longitude;
                public char EW;
                public int Quality;
                public int NbrSat;
                public float HDOP;
                public double Altitude;
                public char AltUnit;
                public float Geoid;
                public char GeoidUnit;
                public float AgeDGPS;
                public int RefStationId;
            }

            public struct RiverPro_NMEA_GGA
            {
                public int NMEAIdCode;
                public int NMEAMessageId;

                public DateTime UTCtime;
                public double Latitude;
                public char NS;
                public double Longitude;
                public char EW;
                public int Quality;
                public int NbrSat;
                public float HDOP;
                public double Altitude;
                public char AltUnit;
                public float Geoid;
                public char GeoidUnit;
                public float AgeDGPS;
                public int RefStationId;
            }

            public struct RiverPro_NMEA_HDT
            {
                public int NMEAIdCode;
                public int NMEAMessageId;

                public string Header;
                public double dHeading;
                public char TrueIndicator;
            }

            public struct RiverPro_NMEA_DBT
            {
                public int NMEAIdCode;
                public int NMEAMessageId;

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
                public DateTime UTC_Date_Time_First_Fix;
                public int PC_CLOCK_OFFSET_FROM_UTC;
                public double FIRST_LATITUDE;
                public double FIRST_LONGITUDE;
                public long UTC_TIME_OF_LAST_FIX;
                public DateTime UTC_Date_Time_Last_Fix;
                public double LAST_LATITUDE;
                public double LAST_LONGITUDE;
                public float NMEAHeading;
                public float NMEAPitch;
                public float NMEARoll;
                public double SPEED_MADE_GOOD;
                public double DIRECTION_MADE_GOOD;
                public double VTG_SPEED_mm_per_sec;
                public double VTG_DIRECTION;

                public float NMEAHeadingADCPFrame;
                public float NMEAPitchADCPFrame;
                public float NMEARollADCPFrame;

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
                public DateTime UTCtime;
                public int LatDegrees;
                public double LatMinutes;
                public double Latitude;
                public Char NS;
                public int LongDegrees;
                public double LongMinutes;
                public double longitude;
                public Char EW;
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

            public struct ExplorerHDTStruct
            {
                public double TimeTag;
                public double SampleTime;
                public double DataAvailable;
                public double ErrorBit0;
                public double ErrorBit1;
                public double Heading;
                public double Pitch;
                public double Roll;
            }

            public struct ExplorerRMCStruct
            {
                public double TimeTag;
                public double SampleTime;
                public double DataAvailable;
                public double ErrorBit0;
                public double ErrorBit1;
                public char FixStatus;
                public int UTCMonth;
                public int UTCDays;
                public int UTCYears;
                public int UTCHours;
                public int UTCMinutes;
                public int UTCSeconds;
                public int UTC100ofSeconds;
                public DateTime UTCtime;
                public int LatDegrees;
                public double LatMinutes;
                public double Latitude;
                public char NS;
                public int LongDegrees;
                public double LongMinutes;
                public double Longitude;
                public char EW;
                public double GroundSpeed;
                public double GroundCourse;
                public double Variation;
                public double Altitude;
            }
            #endregion

            #region Burst structure

            public struct PacketStruct
            {
                public byte[] PacketByte;
                public PacketTypeEnum PacketType;
                public WavesPacketHeaderStruct WavesPacketHeader;
                public WavesPacketLeaderStruct WavesPacketLeader;
                public WavesPacketWavesPingStruct WavesPacketWavesPing;
                public WavesPacketsHPRStruct WavesPacketsHPR;
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
                public double TimeSinceStart;                  //      4 bytes     Time since beginning of burst hund. Sec.       
                public double Pressure;                        //      4 bytes     Pressure deca Pa
                public double[] Dist2Surf;                       //      16 bytes    Range to surface for 4 beams (-1 = bad) mm
                public double[] Velocity;                      //      Tableau de bytes  2*bins Beam radial velocity for selected bins
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

        ///////////////////////////////////////////////////////////////////////////////////

            #region DecodeRecord
        /// <summary>
        /// Decode record
        /// </summary>
        /// <param name="tempRecord0"></param>
        /// <returns></returns>
            private bool DecodeRecord0(Byte[] tempRecord0)
            {

                if (tempRecord0 == null) { Record0.RecordType = RecordTypeEnum.EndFile; return false; }

                if (tempRecord0[0] == 127 && tempRecord0[1] == 127)
                {
                    Record0.RecordType = RecordTypeEnum.Ensemble;
                    return DecodeEnsemble(tempRecord0);
                }

                if (tempRecord0[0] == 127 && tempRecord0[1] == 121)
                {
                    Record0.RecordType = RecordTypeEnum.WavePacket;
                    return DecodePacket(tempRecord0);
                }
                return false;
            }///////////  decide if ensemble or packet  set record type

            private bool DecodeEnsemble(byte[] TempsRecord0)
            {
                Record0.Ensemble.EnsBytesAll = TempsRecord0;
                int NbrDataType = TempsRecord0[5];
                Record0.Ensemble.Description.EnsembleSize = TempsRecord0.Length;
                Record0.Ensemble.Description.NbrDataType = NbrDataType;
                Record0.Ensemble.Description.DataTypeID = new int[NbrDataType];
                Record0.Ensemble.Description.DataTypeOffset = new int[NbrDataType];
                Record0.Ensemble.Description.DataTypeNbrBytes = new int[NbrDataType];
                Record0.Ensemble.Description.DataTypeName = new string[NbrDataType];
                Record0.Ensemble.Description.ID2Offset = new Dictionary<int, int>();
                Record0.Ensemble.Description.ID2Byte = new Dictionary<int, Byte[]>();
                Record0.Ensemble.Description.RefDataTypePresent = new Dictionary<int, bool>(RefDataTypeYesNo0);

                ////////////////////////////////////////////////////////////////////////
                ///            Decode Ensemble Structure.
                ////////////////////////////////////////////////////////////////////////
                ///      Datatype offset and Datatype ID  per data type.
                for (int i = 0; i < NbrDataType; i++)
                {
                    Record0.Ensemble.Description.DataTypeOffset[i] = TempsRecord0[(i * 2) + 6] + (TempsRecord0[(i * 2) + 7] * 256);
                    Record0.Ensemble.Description.DataTypeID[i] = TempsRecord0[Record0.Ensemble.Description.DataTypeOffset[i]] + TempsRecord0[Record0.Ensemble.Description.DataTypeOffset[i] + 1] * 256;

                    if (Record0.Ensemble.Description.DataTypeID[i]==8226)   ///   sub types WinRiver II     1048226
                    {
                        Record0.Ensemble.Description.DataTypeID[i] = Record0.Ensemble.Description.DataTypeID[i] + BitConverter.ToInt16(TempsRecord0, Record0.Ensemble.Description.DataTypeOffset[i] + 2) * 10000;
                    }
                    if (Record0.Ensemble.Description.DataTypeID.Length > 8)
                   {
                        if (Record0.Ensemble.Description.DataTypeID[8] == 0) { Record0.Ensemble.Description.DataTypeID[8] = 51; }
                    }



                    if (!Record0.Ensemble.Description.ID2Offset.ContainsKey(Record0.Ensemble.Description.DataTypeID[i]))
                    {
                        Record0.Ensemble.Description.ID2Offset.Add(Record0.Ensemble.Description.DataTypeID[i], Record0.Ensemble.Description.DataTypeOffset[i]);
                        Record0.Ensemble.Description.RefDataTypePresent[Record0.Ensemble.Description.DataTypeID[i]] = true;
                    }
                    else
                    {
                        //   code to control WinRiver //  si la clee existe deja dans la liste des datatype
                        NbrDataType = i;
                        Record0.Ensemble.Description.NbrDataType = i;
                    }
                }

                ///      Get  Number Of bytes per data type.
                for (int i = 0; i < NbrDataType - 1; i++)
                {
                    Record0.Ensemble.Description.DataTypeNbrBytes[i] = Record0.Ensemble.Description.DataTypeOffset[i + 1] - Record0.Ensemble.Description.DataTypeOffset[i];
                }
                Record0.Ensemble.Description.DataTypeNbrBytes[NbrDataType - 1] = TempsRecord0.Length - Record0.Ensemble.Description.DataTypeOffset[NbrDataType - 1];

                /////     creates tables  in structInt0
                Record0.Ensemble.EnsBytes = new byte[Record0.Ensemble.Description.NbrDataType][];
                for (int i = 0; i < NbrDataType; i++)
                {
                    Record0.Ensemble.EnsBytes[i] = new byte[Record0.Ensemble.Description.DataTypeNbrBytes[i]];
                    if (!Record0.Ensemble.Description.ID2Byte.ContainsKey(Record0.Ensemble.Description.DataTypeID[i]))
                    {
                        Record0.Ensemble.Description.ID2Byte.Add(Record0.Ensemble.Description.DataTypeID[i], Record0.Ensemble.EnsBytes[i]);
                    }
                }

                //   fill up 




                //                         Datatype names.
                for (int i = 0; i < NbrDataType; i++)
                {
                    if (RefDataType0.ContainsKey(Record0.Ensemble.Description.DataTypeID[i]))
                    {
                        Record0.Ensemble.Description.DataTypeName[i] = RefDataType0[Record0.Ensemble.Description.DataTypeID[i]];
                    }
                    else
                    {   //  data not reconized
                        Record0.Ensemble.Description.DataTypeName[i] = "Data type not reconized";
                    }
                }

                /////   Copy bytes from Current_ensemble into    StructInt0.EnsByte 
                for (int i = 0; i < NbrDataType; i++)
                {
                    Array.Copy(TempsRecord0, Record0.Ensemble.Description.DataTypeOffset[i], Record0.Ensemble.EnsBytes[i], 0, Record0.Ensemble.Description.DataTypeNbrBytes[i]);
                }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////     Initialise few variables   /////////////////////////////////////////

                Record0.Ensemble.ExplorerGGAStruct0.NS = (char)'0';
                Record0.Ensemble.ExplorerGGAStruct0.EW = (char)'0';
                Record0.Ensemble.ExplorerRMCStruct0.NS = (char)'0';
                Record0.Ensemble.ExplorerRMCStruct0.EW = (char)'0';

                
                Record0.Ensemble.BottomTrack.Velocities = new double[4];
                Record0.Ensemble.BottomTrack.Velocities[0] = -32768;
                Record0.Ensemble.BottomTrack.Velocities[1] = -32768;
                Record0.Ensemble.BottomTrack.Velocities[2] = -32768;
                Record0.Ensemble.BottomTrack.Velocities[3] = -32768;

                Record0.Ensemble.FixedLeader.SystemSN = "0";

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ///  Start decoder
                ///  decode each data type witht the appropriate decoder
                for (int i = 0; i < NbrDataType; i++)
                {

                    //  decode non profiles   data ////  decode non profiles   data //////////////////////

                    if (Record0.Ensemble.Description.DataTypeID[i] == 0)
                    {
                        DecodeDataFixedLeader(Record0.Ensemble.EnsBytes[i]);
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 1)
                    {
                        DecodeDataFixedLeader2(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  variable leader
                    if (Record0.Ensemble.Description.DataTypeID[i] == 128)
                    {
                        DecodeDataVariableLeader(Record0.Ensemble.EnsBytes[i]);
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 129)
                    {
                        DecodeDataVariableLeader2(Record0.Ensemble.EnsBytes[i]);
                    }

                    // bottom track
                    if (Record0.Ensemble.Description.DataTypeID[i] == 1536)
                    {
                        DecodeDataBottomTrack(Record0.Ensemble.EnsBytes[i]);
                    }
                    // WinRiverGGA
                    if (Record0.Ensemble.Description.DataTypeID[i] == 8449)
                    {
                        DecodeDataWinRiverGGA(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  WinRiver II  GGA   2101


                    //  Vmdas Navigation
                    if (Record0.Ensemble.Description.DataTypeID[i] == 8192)
                    {
                        DecodeVmDasNavigation(Record0.Ensemble.EnsBytes[i]);
                    }



                    //  Explorer GGA
                    if (Record0.Ensemble.Description.DataTypeID[i] == 21521)
                    {
                        DecodeExplorerGGA(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  Explorer RMC
                    if (Record0.Ensemble.Description.DataTypeID[i] == 21520)
                    {
                        DecodeExplorerRMC(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  Explorer VTG
                    if (Record0.Ensemble.Description.DataTypeID[i] == 21526)
                    {
                        DecodeExplorerVTG(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  Explorer HDT
                    if (Record0.Ensemble.Description.DataTypeID[i] == 21508)
                    {
                        DecodeExplorerHDT(Record0.Ensemble.EnsBytes[i]);
                    }

                    //  River Ray    External GPS  /  Internal GPS    2022
                    if (Record0.Ensemble.Description.DataTypeID[i] == 8226 || Record0.Ensemble.Description.DataTypeID[i] == 1048226)
                    {
                        DecodeNMEA_Encapsulated(Record0.Ensemble.EnsBytes[i]);
                    }
                    






                    ///////////////////////////////////////  decode velocity profiles   data //////////////////////
                    //   Velocity 1
                    if (Record0.Ensemble.Description.DataTypeID[i] == 256)
                    {
                        Record0.Ensemble.Velocity1 = DecodeDataProfile2bytes(Record0.Ensemble.EnsBytes[i], 256, "Velocity 1");
                    }
                    //  velocity 2
                    if (Record0.Ensemble.Description.DataTypeID[i] == 257)
                    {
                        Record0.Ensemble.Velocity2 = DecodeDataProfile2bytes2(Record0.Ensemble.EnsBytes[i], 257, "Velocity 2");
                    }
                    //  Correlation
                    if (Record0.Ensemble.Description.DataTypeID[i] == 512)
                    {
                        Record0.Ensemble.Correlation = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 512, "Correlation");
                    }
                    //  Echo Int
                    if (Record0.Ensemble.Description.DataTypeID[i] == 768)
                    {
                        Record0.Ensemble.EchoInt = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 768, "Echo Int16");
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 1024)
                    {
                        Record0.Ensemble.PercentGood = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 1024, "Percent Good");
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 1280)
                    {
                        Record0.Ensemble.Status = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 1024, "Status");
                    }

                    // surface profile

                    //  WinRiver surface data
                    if (Record0.Ensemble.Description.DataTypeID[i] == 16)
                    {
                        DecodeSurfaceDataLeader(Record0.Ensemble.EnsBytes[i]);
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 272)
                    {
                        Record0.Ensemble.SurfaceVelocity = DecodeDataProfile2bytes(Record0.Ensemble.EnsBytes[i], 272, "Surface Velocity");
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 528)
                    {
                        Record0.Ensemble.SurfaceCorrelation = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 528, "Surface correlation");
                    }

                    if (Record0.Ensemble.Description.DataTypeID[i] == 784)
                    {
                        Record0.Ensemble.SurfaceEchoInt = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 784, "Surface echo Int");
                    }
                    if (Record0.Ensemble.Description.DataTypeID[i] == 1040)
                    {
                        Record0.Ensemble.SurfacePercentGood = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 1040, "Surface Percent good");
                    }
                    if (Record0.Ensemble.Description.DataTypeID[i] == 1296)
                    {
                        Record0.Ensemble.SurfaceSatus = DecodeDataProfile1bytes(Record0.Ensemble.EnsBytes[i], 1296, "Surface status");
                    }
                }
                return true;
            }

            //  Fixed leader
            int CoordinateInt;
            private void DecodeDataFixedLeader(Byte[] ByteIn)
            {
                Record0.Ensemble.FixedLeader.FimwareVersion = ByteIn[2].ToString("00");
                Record0.Ensemble.FixedLeader.firmwareRevision = ByteIn[3].ToString("00");
                Record0.Ensemble.FixedLeader.SystemConfigurationLow = ByteIn[4];

                switch (ByteIn[4] & 7)
                {
                    case 0:
                        Record0.Ensemble.FixedLeader.SystFreq = "75kHz";
                        break;
                    case 1:
                        Record0.Ensemble.FixedLeader.SystFreq = "150kHz";
                        break;
                    case 2:
                        Record0.Ensemble.FixedLeader.SystFreq = "300kHz";
                        break;
                    case 3:
                        Record0.Ensemble.FixedLeader.SystFreq = "600kHz";
                        break;
                    case 4:
                        Record0.Ensemble.FixedLeader.SystFreq = "1200kHz";
                        break;
                    case 5:
                        Record0.Ensemble.FixedLeader.SystFreq = "2400kHz";
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
                        Record0.Ensemble.FixedLeader.SystBeamAngle = 15;
                        break;
                    case 1:
                        Record0.Ensemble.FixedLeader.SystBeamAngle = 20;
                        break;
                    case 2:
                        Record0.Ensemble.FixedLeader.SystBeamAngle = 30;
                        break;
                    default:
                        Record0.Ensemble.FixedLeader.SystBeamAngle = 45;
                        break;
                }


                Record0.Ensemble.FixedLeader.LagLength = ByteIn[7];
                Record0.Ensemble.FixedLeader.NbrBeam = ByteIn[8];
                Record0.Ensemble.FixedLeader.NumberOfDepthCells = ByteIn[9];
                Record0.Ensemble.FixedLeader.PingPerEnsemble = ByteIn[11] * 256 + ByteIn[10];
                Record0.Ensemble.FixedLeader.DepthCellLength = ByteIn[13] * 256 + ByteIn[12];
                Record0.Ensemble.FixedLeader.BlankAfterTransmit = ByteIn[15] * 256 + ByteIn[14];
                Record0.Ensemble.FixedLeader.ProfilingMode = ByteIn[16];
                Record0.Ensemble.FixedLeader.LowCorThreshold = ByteIn[17];
                Record0.Ensemble.FixedLeader.NbrCodeRep = ByteIn[18];

                Record0.Ensemble.FixedLeader.TP = ByteIn[22].ToString("00") + ":" + ByteIn[23].ToString("00") + "." + ByteIn[24].ToString("00");

                CoordinateInt = ByteIn[25];

                switch (CoordinateInt & 24)
                {
                    case 24:
                        Record0.Ensemble.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Earth;
                        break;
                    case 16:
                        Record0.Ensemble.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Ship;
                        break;
                    case 8:
                        Record0.Ensemble.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Instrument;
                        break;
                    case 0:
                        Record0.Ensemble.FixedLeader.CoordinateSystem = CoordinateSystemEnum.Beam;
                        break;
                }

                Record0.Ensemble.FixedLeader.LookingDownInt = -1;
                if ((Record0.Ensemble.FixedLeader.SystemConfigurationLow & 128) == 128)
                {
                    Record0.Ensemble.FixedLeader.LookingDown = false;
                    Record0.Ensemble.FixedLeader.LookingDownInt = 1;
                }
                else
                {
                    Record0.Ensemble.FixedLeader.LookingDown = true;
                }

                Record0.Ensemble.FixedLeader.EA = (ByteIn[27] * 256 + ByteIn[26]);
                if (Record0.Ensemble.FixedLeader.EA > 32767) { Record0.Ensemble.FixedLeader.EA -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.FixedLeader.EA = (float)(Record0.Ensemble.FixedLeader.EA / 100);

                Record0.Ensemble.FixedLeader.EB = (float)(decimal.Divide((ByteIn[29] * 256 + ByteIn[28]), 100));
                if (Record0.Ensemble.FixedLeader.EB > 32767) { Record0.Ensemble.FixedLeader.EB -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.FixedLeader.EB = (float)(Record0.Ensemble.FixedLeader.EB / 100);

                Record0.Ensemble.FixedLeader.SensorSource = ByteIn[30].ToString();
                Record0.Ensemble.FixedLeader.SensorAvailable = ByteIn[31].ToString();
                Record0.Ensemble.FixedLeader.RangeToBin1 = ByteIn[33] * 256 + ByteIn[32];

                if (ByteIn.Length > 58)
                {
                    Record0.Ensemble.FixedLeader.SystemSN = (ByteIn[57] * 16777216 + ByteIn[56] * 65536 + ByteIn[55] * 256 + ByteIn[54]).ToString();

                    Record0.Ensemble.FixedLeader.SystemSN = (BitConverter.ToInt32(ByteIn, 54)).ToString();

                    Record0.Ensemble.FixedLeader.Bandwidth = ByteIn[50] * 256 + ByteIn[51];
                    Record0.Ensemble.FixedLeader.SystBeamAngle = ByteIn[58];
                }

            }

            private void DecodeDataFixedLeader2(Byte[] ByteIn)
            {
                Record0.Ensemble.FixedLeader2.FimwareVersion = ByteIn[2].ToString("00");
                Record0.Ensemble.FixedLeader2.firmwareRevision = ByteIn[3].ToString("00");
                Record0.Ensemble.FixedLeader2.SystemConfigurationLow = ByteIn[4];
                Record0.Ensemble.FixedLeader2.LagLength = ByteIn[7];
                Record0.Ensemble.FixedLeader2.NbrBeam = ByteIn[8];
                Record0.Ensemble.FixedLeader2.NumberOfDepthCells = ByteIn[9];
                Record0.Ensemble.FixedLeader2.PingPerEnsemble = ByteIn[11] * 256 + ByteIn[10];
                Record0.Ensemble.FixedLeader2.DepthCellLength = ByteIn[13] * 256 + ByteIn[12];
                Record0.Ensemble.FixedLeader2.BlankAfterTransmit = ByteIn[15] * 256 + ByteIn[14];
                Record0.Ensemble.FixedLeader2.ProfilingMode = ByteIn[16];
                Record0.Ensemble.FixedLeader2.LowCorThreshold = ByteIn[17];
                Record0.Ensemble.FixedLeader2.NbrCodeRep = ByteIn[18];

                Record0.Ensemble.FixedLeader2.TP = ByteIn[22].ToString("00") + ":" + ByteIn[23].ToString("00") + "." + ByteIn[24].ToString("00");

                CoordinateInt = ByteIn[25];

                switch (CoordinateInt & 24)
                {
                    case 24:
                        Record0.Ensemble.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Earth;
                        break;
                    case 16:
                        Record0.Ensemble.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Ship;
                        break;
                    case 8:
                        Record0.Ensemble.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Instrument;
                        break;
                    case 0:
                        Record0.Ensemble.FixedLeader2.CoordinateSystem = CoordinateSystemEnum.Beam;
                        break;
                }

                Record0.Ensemble.FixedLeader2.LookingDownInt = -1;
                if ((Record0.Ensemble.FixedLeader2.SystemConfigurationLow & 128) == 128)
                {
                    Record0.Ensemble.FixedLeader2.LookingDown = false;
                    Record0.Ensemble.FixedLeader2.LookingDownInt = 1;
                }
                else
                {
                    Record0.Ensemble.FixedLeader2.LookingDown = true;
                }


                Record0.Ensemble.FixedLeader.EA = (ByteIn[27] * 256 + ByteIn[26]);
                if (Record0.Ensemble.FixedLeader.EA > 32767) { Record0.Ensemble.FixedLeader.EA -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.FixedLeader.EA = (float)(Record0.Ensemble.FixedLeader.EA / 100);

                Record0.Ensemble.FixedLeader.EB = (float)(decimal.Divide((ByteIn[29] * 256 + ByteIn[28]), 100));
                if (Record0.Ensemble.FixedLeader.EB > 32767) { Record0.Ensemble.FixedLeader.EB -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.FixedLeader.EB = (float)(Record0.Ensemble.FixedLeader.EB / 100);

                Record0.Ensemble.FixedLeader2.SensorSource = ByteIn[30].ToString();
                Record0.Ensemble.FixedLeader2.SensorAvailable = ByteIn[31].ToString();
                Record0.Ensemble.FixedLeader2.RangeToBin1 = ByteIn[33] * 256 + ByteIn[32];

                if (ByteIn.Length > 58)
                {
                    Record0.Ensemble.FixedLeader2.SystemSN = (ByteIn[57] * 16777216 + ByteIn[56] * 65536 + ByteIn[55] * 256 + ByteIn[54]).ToString();

                    Record0.Ensemble.FixedLeader2.Bandwidth = ByteIn[50] * 256 + ByteIn[51];
                    Record0.Ensemble.FixedLeader2.SystBeamAngle = ByteIn[58];
                }
            }

            //  Variable leader
            private void DecodeDataVariableLeader(Byte[] ByteIn)
            {//  Le tableau commence a 0, la doc de RDI commence a 1
                Record0.Ensemble.VariableLeader.EnsNumber = ByteIn[2] + ByteIn[3] * 256 + ByteIn[11] * 65536;
                Record0.Ensemble.VariableLeader.BitTest = ByteIn[12] + ByteIn[13] * 256;

                Record0.Ensemble.VariableLeader.Year = ByteIn[4];
                Record0.Ensemble.VariableLeader.Month = ByteIn[5];
                Record0.Ensemble.VariableLeader.DayE = ByteIn[6];
                Record0.Ensemble.VariableLeader.Hour = ByteIn[7];
                Record0.Ensemble.VariableLeader.Minutes = ByteIn[8];
                Record0.Ensemble.VariableLeader.Secondes = ByteIn[9];
                Record0.Ensemble.VariableLeader.HundredofSecondes = ByteIn[10];
                Record0.Ensemble.VariableLeader.BitResult = ByteIn[12] + ByteIn[13] * 256;
                Record0.Ensemble.VariableLeader.SpeedOfSound = ByteIn[14] + ByteIn[15] * 256;
                Record0.Ensemble.VariableLeader.XCDRDepth = ByteIn[16] + ByteIn[17] * 256;
                Record0.Ensemble.VariableLeader.Heading = ByteIn[18] + ByteIn[19] * 256;
                Record0.Ensemble.VariableLeader.Heading = Record0.Ensemble.VariableLeader.Heading / 100;

                Record0.Ensemble.VariableLeader.Pitch = ByteIn[20] + ByteIn[21] * 256;
                if (Record0.Ensemble.VariableLeader.Pitch > 32767) { Record0.Ensemble.VariableLeader.Pitch -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.VariableLeader.Pitch = Record0.Ensemble.VariableLeader.Pitch / 100;

                Record0.Ensemble.VariableLeader.Roll = ByteIn[22] + ByteIn[23] * 256;
                if (Record0.Ensemble.VariableLeader.Roll > 32767) { Record0.Ensemble.VariableLeader.Roll -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.VariableLeader.Roll = Record0.Ensemble.VariableLeader.Roll / 100;

                Record0.Ensemble.VariableLeader.Salinity = ByteIn[24] + ByteIn[25] * 256;
                Record0.Ensemble.VariableLeader.Temperature = ByteIn[26] + ByteIn[27] * 256;

                if (ByteIn.Length > 50)
                {
                    Record0.Ensemble.VariableLeader.Pressure = ByteIn[51] * 16777216 + ByteIn[50] * 65536 + ByteIn[49] * 256 + ByteIn[48];
                }

                string DateString = Record0.Ensemble.VariableLeader.DayE.ToString("00") + "/" + Record0.Ensemble.VariableLeader.Month.ToString("00") + "/" + Record0.Ensemble.VariableLeader.Year.ToString("00") + " " + Record0.Ensemble.VariableLeader.Hour.ToString("00") + ":" + Record0.Ensemble.VariableLeader.Minutes.ToString("00") + ":" + Record0.Ensemble.VariableLeader.Secondes.ToString("00") + "." + Record0.Ensemble.VariableLeader.HundredofSecondes.ToString("00");
                Record0.Ensemble.VariableLeader.EnsTime = DateTime.Parse(DateString, culture);
            }

            private void DecodeDataVariableLeader2(Byte[] ByteIn)
            {//  Le tableau commence a 0, la doc de RDI commence a 1
                Record0.Ensemble.VariableLeader2.EnsNumber = ByteIn[2] + ByteIn[3] * 256 + ByteIn[11] * 65536;
                Record0.Ensemble.VariableLeader2.BitTest = ByteIn[12] + ByteIn[13] * 256;

                Record0.Ensemble.VariableLeader2.Year = ByteIn[4];
                Record0.Ensemble.VariableLeader2.Month = ByteIn[5];
                Record0.Ensemble.VariableLeader2.DayE = ByteIn[6];
                Record0.Ensemble.VariableLeader2.Hour = ByteIn[7];
                Record0.Ensemble.VariableLeader2.Minutes = ByteIn[8];
                Record0.Ensemble.VariableLeader2.Secondes = ByteIn[9];
                Record0.Ensemble.VariableLeader2.HundredofSecondes = ByteIn[10];
                Record0.Ensemble.VariableLeader2.BitResult = ByteIn[12] + ByteIn[13] * 256;
                Record0.Ensemble.VariableLeader2.SpeedOfSound = ByteIn[14] + ByteIn[15] * 256;
                Record0.Ensemble.VariableLeader2.XCDRDepth = ByteIn[16] + ByteIn[17] * 256;
                Record0.Ensemble.VariableLeader2.Heading = ByteIn[18] + ByteIn[19] * 256;
                Record0.Ensemble.VariableLeader2.Heading = Record0.Ensemble.VariableLeader.Heading / 100;

                Record0.Ensemble.VariableLeader2.Pitch = ByteIn[20] + ByteIn[21] * 256;
                if (Record0.Ensemble.VariableLeader2.Pitch > 32767) { Record0.Ensemble.VariableLeader.Pitch -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.VariableLeader2.Pitch = Record0.Ensemble.VariableLeader.Pitch / 100;

                Record0.Ensemble.VariableLeader2.Roll = ByteIn[22] + ByteIn[23] * 256;
                if (Record0.Ensemble.VariableLeader2.Roll > 32767) { Record0.Ensemble.VariableLeader.Roll -= 65536; }  //  SHOULD BE 65635
                Record0.Ensemble.VariableLeader2.Roll = Record0.Ensemble.VariableLeader.Roll / 100;

                Record0.Ensemble.VariableLeader2.Salinity = ByteIn[24] + ByteIn[25] * 256;
                Record0.Ensemble.VariableLeader2.Temperature = ByteIn[26] + ByteIn[27] * 256;

                if (ByteIn.Length > 50)
                {
                    Record0.Ensemble.VariableLeader2.Pressure = ByteIn[51] * 16777216 + ByteIn[50] * 65536 + ByteIn[49] * 256 + ByteIn[48];
                }

                string DateString = Record0.Ensemble.VariableLeader2.DayE + "/" + Record0.Ensemble.VariableLeader2.Month + "/" + Record0.Ensemble.VariableLeader2.Year + " " + Record0.Ensemble.VariableLeader2.Hour + ":" + Record0.Ensemble.VariableLeader2.Minutes + ":" + Record0.Ensemble.VariableLeader2.Secondes + "." + Record0.Ensemble.VariableLeader2.HundredofSecondes;
                Record0.Ensemble.VariableLeader2.EnsTime = DateTime.Parse(DateString, culture);
            }

            ///   Bottom track decoder
            private void DecodeDataBottomTrack(Byte[] ByteIn)
            {
                double[] TempInt1 = new double[4];
                double[] TempInt2 = new double[4];
                Double[] TempDouble = new Double[4];

                Record0.Ensemble.BottomTrack.PingPerEns = ByteIn[2] + ByteIn[3] * 256;
                Record0.Ensemble.BottomTrack.DelayBeforeReacquire = ByteIn[4] + ByteIn[5] * 256;
                Record0.Ensemble.BottomTrack.CorrMagMin = ByteIn[6];
                Record0.Ensemble.BottomTrack.EvalAmpMin = ByteIn[7];
                Record0.Ensemble.BottomTrack.PercentGoodMin = ByteIn[8];
                Record0.Ensemble.BottomTrack.Mode = ByteIn[9];
                Record0.Ensemble.BottomTrack.ErrorVelMax = ByteIn[10] + ByteIn[11] * 256;
                if (ByteIn.Length > 80)
                {
                    Record0.Ensemble.BottomTrack.Range1 = ByteIn[16] + ByteIn[17] * 256 + 65536 * ByteIn[77];
                    Record0.Ensemble.BottomTrack.Range2 = ByteIn[18] + ByteIn[19] * 256 + 65536 * ByteIn[78];
                    Record0.Ensemble.BottomTrack.Range3 = ByteIn[20] + ByteIn[21] * 256 + 65536 * ByteIn[79];
                    Record0.Ensemble.BottomTrack.Range4 = ByteIn[22] + ByteIn[23] * 256 + 65536 * ByteIn[80];
                }
                else
                {
                    Record0.Ensemble.BottomTrack.Range1 = ByteIn[16] + ByteIn[17] * 256;// +65536 * ByteIn[77];
                    Record0.Ensemble.BottomTrack.Range2 = ByteIn[18] + ByteIn[19] * 256;// +65536 * ByteIn[78];
                    Record0.Ensemble.BottomTrack.Range3 = ByteIn[20] + ByteIn[21] * 256;// +65536 * ByteIn[79];
                    Record0.Ensemble.BottomTrack.Range4 = ByteIn[22] + ByteIn[23] * 256;// +65536 * ByteIn[80];
                }

                TempDouble[0] = Record0.Ensemble.BottomTrack.Range1;
                TempDouble[1] = Record0.Ensemble.BottomTrack.Range2;
                TempDouble[2] = Record0.Ensemble.BottomTrack.Range3;
                TempDouble[3] = Record0.Ensemble.BottomTrack.Range4;

                Record0.Ensemble.BottomTrack.Ranges = TempDouble;
                Record0.Ensemble.BottomTrack.RangeAverage = AveragedRange(TempDouble);

                //  Bottom track velocities
                TempInt1[0] = ByteIn[24] + ByteIn[25] * 256;
                if (TempInt1[0] > 32767) { TempInt1[0] -= 65536; }
                TempInt1[1] = ByteIn[26] + ByteIn[27] * 256;
                if (TempInt1[1] > 32767) { TempInt1[1] -= 65536; }
                TempInt1[2] = ByteIn[28] + ByteIn[29] * 256;
                if (TempInt1[2] > 32767) { TempInt1[2] -= 65536; }
                TempInt1[3] = ByteIn[30] + ByteIn[31] * 256;
                if (TempInt1[3] > 32767) { TempInt1[3] -= 65536; }
                Record0.Ensemble.BottomTrack.Velocities = TempInt1;

                Record0.Ensemble.BottomTrack.Correlation1 = ByteIn[32];
                Record0.Ensemble.BottomTrack.Correlation2 = ByteIn[33];
                Record0.Ensemble.BottomTrack.Correlation3 = ByteIn[34];
                Record0.Ensemble.BottomTrack.Correlation4 = ByteIn[35];
                Record0.Ensemble.BottomTrack.EvaluationAmplitude1 = ByteIn[36];
                Record0.Ensemble.BottomTrack.EvaluationAmplitude2 = ByteIn[37];
                Record0.Ensemble.BottomTrack.EvaluationAmplitude3 = ByteIn[38];
                Record0.Ensemble.BottomTrack.EvaluationAmplitude4 = ByteIn[39];
                Record0.Ensemble.BottomTrack.PercentGood1 = ByteIn[40];
                Record0.Ensemble.BottomTrack.PercentGood2 = ByteIn[41];
                Record0.Ensemble.BottomTrack.PercentGood3 = ByteIn[42];
                Record0.Ensemble.BottomTrack.PercentGood4 = ByteIn[43];
                Record0.Ensemble.BottomTrack.RefLayerMin = ByteIn[44] + ByteIn[45] * 256;
                Record0.Ensemble.BottomTrack.RefLayerNear = ByteIn[46] + ByteIn[47] * 256;
                Record0.Ensemble.BottomTrack.RefLayerFar = ByteIn[48] + ByteIn[49] * 256;

                // water layer velocities
                TempInt2[0] = ByteIn[50] + ByteIn[51] * 256;
                if (TempInt2[0] > 32767) { TempInt2[0] -= 65536; }
                TempInt2[1] = ByteIn[52] + ByteIn[53] * 256;
                if (TempInt2[1] > 32767) { TempInt2[1] -= 65536; }
                TempInt2[2] = ByteIn[54] + ByteIn[55] * 256;
                if (TempInt2[2] > 32767) { TempInt2[2] -= 65536; }
                TempInt2[3] = ByteIn[56] + ByteIn[57] * 256;
                if (TempInt2[3] > 32767) { TempInt2[3] -= 65536; }

                Record0.Ensemble.BottomTrack.RefLayerVelocities = TempInt2;

                Record0.Ensemble.BottomTrack.RefLayerCorrelation1 = ByteIn[58];
                Record0.Ensemble.BottomTrack.RefLayerCorrelation2 = ByteIn[59];
                Record0.Ensemble.BottomTrack.RefLayerCorrelation3 = ByteIn[60];
                Record0.Ensemble.BottomTrack.RefLayerCorrelation4 = ByteIn[61];

                Record0.Ensemble.BottomTrack.RefLayerIntensity1 = ByteIn[62];
                Record0.Ensemble.BottomTrack.RefLayerIntensity2 = ByteIn[63];
                Record0.Ensemble.BottomTrack.RefLayerIntensity3 = ByteIn[64];
                Record0.Ensemble.BottomTrack.RefLayerIntensity4 = ByteIn[65];
            }

            ///   WinRiver GGA decoder
            Double TempDouble0, TempDouble1, TempDouble2;
            private void DecodeDataWinRiverGGA(Byte[] ByteIn)
            {
                Record0.Ensemble.WinRiverGGA.Header = "Ok";
                string GGAStringtemp = System.Text.Encoding.ASCII.GetString(ByteIn);
                int GGAStart = GGAStringtemp.IndexOf('$');
                int GGAEnd = GGAStringtemp.IndexOf("\r\n");
                if (GGAStart > -1 && GGAEnd > GGAStart)
                {

                    Record0.Ensemble.WinRiverGGA.GGAString = GGAStringtemp.Substring(GGAStart, GGAEnd - GGAStart);
                    string[] GGATable = Record0.Ensemble.WinRiverGGA.GGAString.Split(',');


                    //   no checksum check ?

                    int titi = GGATable[1].IndexOf('.');
                    string MiliSec;
                    if (titi == -1)
                    { MiliSec = "000"; }
                    else
                    { MiliSec = GGATable[1].Substring(titi + 1); }
                    int Hours3=0,Minutes3=0,Secondes3=0,MiliSec3=0;

                    if (GGATable[1].Length>=6)
                    {
                        int.TryParse(GGATable[1].Substring(0, 2),out Hours3);
                        int.TryParse(GGATable[1].Substring(2, 2), out Minutes3);
                        int.TryParse(GGATable[1].Substring(4, 2),out Secondes3);
                        int.TryParse(MiliSec, out MiliSec3);
                    }


                    Record0.Ensemble.WinRiverGGA.GGATime = new DateTime(1900, 1, 1, Hours3, Minutes3, Secondes3, MiliSec3);
                     // Record0.Ensemble.WinRiverGGA.GGATime = new DateTime(
                    if (GGATable[2].Length > 1)
                    {
                        double.TryParse(GGATable[2], out TempDouble0);
                        TempDouble1 = Math.Floor(TempDouble0 / 100);
                    }
                    TempDouble2 = TempDouble0 - (TempDouble1 * 100);
                    Record0.Ensemble.WinRiverGGA.LatConvertedToDeg = TempDouble1 + (TempDouble2 / 60);
                    Record0.Ensemble.WinRiverGGA.NorthSouth = GGATable[3];
                    if (GGATable[3] == "S")
                    { Record0.Ensemble.WinRiverGGA.LatConvertedToDeg = -Record0.Ensemble.WinRiverGGA.LatConvertedToDeg; }

                    if (GGATable[4].Length > 3)
                    {
                        double.TryParse(GGATable[4], out TempDouble0);
                        TempDouble1 = Math.Floor(TempDouble0 / 100);
                    }
                    TempDouble2 = TempDouble0 - (TempDouble1 * 100);
                    Record0.Ensemble.WinRiverGGA.LongConvertedToDeg = TempDouble1 + TempDouble2 / 60;
                    Record0.Ensemble.WinRiverGGA.EastWest = GGATable[5];
                    if (GGATable[5] == "W")
                    { Record0.Ensemble.WinRiverGGA.LongConvertedToDeg = -Record0.Ensemble.WinRiverGGA.LongConvertedToDeg; }

                    //WinRiverGGA0.
                    //WinRiverGGA0.Altitude = int.tryParse(GGATable[9]);
                    float.TryParse(GGATable[9], out Record0.Ensemble.WinRiverGGA.Altitude);
                    int.TryParse(GGATable[6], out Record0.Ensemble.WinRiverGGA.Quality);
                }
            }

            /// Vmdas Navigation decoder
             
            private void DecodeVmDasNavigation(Byte[] ByteIn)
            {
                Record0.Ensemble.VmDasNavigation.Header = "Ok";
                //   correct number  0.0000000838190317153931
                DateTime tempD;
                int TempInt;

                DateTime.TryParse(ByteIn[2].ToString() + "/" + ByteIn[3].ToString() + "/" + (ByteIn[4] + ByteIn[5] * 256).ToString(), out tempD);
                Record0.Ensemble.VmDasNavigation.UTCDate = tempD;
                //Record0.Ensemble.VmDasNavigation.UTC_TIME_OF_FIRST_FIX=ByteIn[7]+ByteIn[8]*256+ByteIn[9]*65536+ByteIn[10]*16580608;
                TimeSpan Time1;
                Record0.Ensemble.VmDasNavigation.UTC_TIME_OF_FIRST_FIX = ByteIn[6] + ByteIn[7] * 256 + ByteIn[8] * 65536 + ByteIn[9] * 16777216;
                Time1 = TimeSpan.FromMilliseconds(Record0.Ensemble.VmDasNavigation.UTC_TIME_OF_FIRST_FIX / 10);

                Record0.Ensemble.VmDasNavigation.UTC_Date_Time_First_Fix = Record0.Ensemble.VmDasNavigation.UTCDate + Time1;

                Record0.Ensemble.VmDasNavigation.PC_CLOCK_OFFSET_FROM_UTC = ByteIn[10] + ByteIn[11] * 256 + ByteIn[12] * 65536 + ByteIn[13] * 16777216;

                //4244832255 / 180 = 23582401.416666666666666666666667;  11791200.70833333333333333333333
                // TempInt = ByteIn[14]+ByteIn[15]*256+ByteIn[16]*65536+ByteIn[17]*16580608;
                TempInt = ByteIn[14] + ByteIn[15] * 256 + ByteIn[16] * 65536 + ByteIn[17] * 16777216;
                // Record0.Ensemble.VmDasNavigation.FIRST_LATITUDE = TempInt / 11791200.70833333333333333333333;
                Record0.Ensemble.VmDasNavigation.FIRST_LATITUDE = TempInt * 0.0000000838190317153931;
                TempInt = ByteIn[18] + ByteIn[19] * 256 + ByteIn[20] * 65536 + ByteIn[21] * 16777216;
                //Record0.Ensemble.VmDasNavigation.FIRST_LONGITUDE = TempInt / 11791200.70833333333333333333333;
                Record0.Ensemble.VmDasNavigation.FIRST_LONGITUDE = TempInt * 0.0000000838190317153931;

                Record0.Ensemble.VmDasNavigation.UTC_TIME_OF_LAST_FIX = ByteIn[22] + ByteIn[23] * 256 + ByteIn[24] * 65536 + ByteIn[25] * 16777216;

                Time1 = TimeSpan.FromMilliseconds(Record0.Ensemble.VmDasNavigation.UTC_TIME_OF_LAST_FIX / 10);

                Record0.Ensemble.VmDasNavigation.UTC_Date_Time_Last_Fix = Record0.Ensemble.VmDasNavigation.UTCDate + Time1;
                
                TempInt = ByteIn[26] + ByteIn[27] * 256 + ByteIn[28] * 65536 + ByteIn[29] * 16777216;
                //Record0.Ensemble.VmDasNavigation.LAST_LATITUDE = TempInt / 11791200.70833333333333333333333;
                Record0.Ensemble.VmDasNavigation.LAST_LATITUDE = TempInt * 0.0000000838190317153931;
                TempInt = ByteIn[30] + ByteIn[31] * 256 + ByteIn[32] * 65536 + ByteIn[33] * 16777216;
                //Record0.Ensemble.VmDasNavigation.LAST_LATITUDE = TempInt / 11791200.70833333333333333333333;
                Record0.Ensemble.VmDasNavigation.LAST_LONGITUDE = TempInt * 0.0000000838190317153931;

                Record0.Ensemble.VmDasNavigation.VTG_SPEED_mm_per_sec = (double)(ByteIn[34] + ByteIn[35] * 256);
                Record0.Ensemble.VmDasNavigation.VTG_DIRECTION = (double)(ByteIn[36] + ByteIn[37] * 256) * 0.005493164; //0.005493164


                Record0.Ensemble.VmDasNavigation.SPEED_MADE_GOOD = (double)(ByteIn[40] + ByteIn[41] * 256);
                Record0.Ensemble.VmDasNavigation.DIRECTION_MADE_GOOD = (double)(ByteIn[42] + ByteIn[43] * 256) * 0.005493164;

                //  NMEA FACTOR NUMBER NEEDS TO BE VERIFIED
                Record0.Ensemble.VmDasNavigation.NMEAPitch = (float)((ByteIn[62] + ByteIn[63] * 256) * 0.005493164);
                Record0.Ensemble.VmDasNavigation.NMEARoll = (float)((ByteIn[64] + ByteIn[65] * 256) * 0.005493164);
                Record0.Ensemble.VmDasNavigation.NMEAHeading = (float)((ByteIn[66] + ByteIn[67] * 256) * 0.005493164);

            }

            //  WinRiver   River Ray  surface data
            private void DecodeSurfaceDataLeader(Byte[] ByteIn)
            {
                Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT = ByteIn[2];
                Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_SIZE = ByteIn[3] + ByteIn[4] * 256;
                Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_1_DISTANCE = ByteIn[5] + ByteIn[6] * 256;
            }












            private void DecodeExplorerGGA(Byte[] ByteIn)
            {
                Record0.Ensemble.ExplorerGGAStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 2);
                Record0.Ensemble.ExplorerGGAStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 6);
                Record0.Ensemble.ExplorerGGAStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 10);
                Record0.Ensemble.ExplorerGGAStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 14);
                Record0.Ensemble.ExplorerGGAStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 18);
                Record0.Ensemble.ExplorerGGAStruct0.UTCHours = ByteIn[22];
                Record0.Ensemble.ExplorerGGAStruct0.UTCMinutes = ByteIn[23];
                Record0.Ensemble.ExplorerGGAStruct0.UTCSeconds = ByteIn[24];
                Record0.Ensemble.ExplorerGGAStruct0.UTC100ofSeconds = ByteIn[25];

                Record0.Ensemble.ExplorerGGAStruct0.UTCtime = new DateTime(1900, 1, 1, ByteIn[22], ByteIn[23], ByteIn[24], ByteIn[25]/10);


                if (ByteIn.Length == 58)
                {
                    //LAT
                    Record0.Ensemble.ExplorerGGAStruct0.LatDegrees = ByteIn[26];
                    if (Record0.Ensemble.ExplorerGGAStruct0.LatDegrees > 180) { Record0.Ensemble.ExplorerGGAStruct0.LatDegrees -= 256; }

                    //Record0.Ensemble.ExplorerGGAStruct0.LatMinutes = (double)(BitConverter.ToInt32(ByteIn, 27) )/ 10000000;
                    //if (Record0.Ensemble.ExplorerGGAStruct0.LatMinutes > 180) { Record0.Ensemble.ExplorerGGAStruct0.LatMinutes -= 256; }

                    int latmin = ByteIn[27] + 256 * ByteIn[28] + 65536 * ByteIn[29] + 16777216 * ByteIn[30];

                    Record0.Ensemble.ExplorerGGAStruct0.LatMinutes = latmin / 10000000;
                    //Record0.Ensemble.ExplorerGGAStruct0.LatMinutes = BitConverter.ToInt32(ByteIn, 27);


                    Record0.Ensemble.ExplorerGGAStruct0.Latitude = Record0.Ensemble.ExplorerGGAStruct0.LatDegrees + Record0.Ensemble.ExplorerGGAStruct0.LatMinutes / 60;



                    // LONG                                                                                /// 
                    Record0.Ensemble.ExplorerGGAStruct0.LongDegrees = ByteIn[31];
                    if (Record0.Ensemble.ExplorerGGAStruct0.LongDegrees > 180) { Record0.Ensemble.ExplorerGGAStruct0.LongDegrees -= 256; }

                    Record0.Ensemble.ExplorerGGAStruct0.LongMinutes = (double)(BitConverter.ToInt32(ByteIn, 32)) / 10000000;

                    Record0.Ensemble.ExplorerGGAStruct0.longitude = Record0.Ensemble.ExplorerGGAStruct0.LongDegrees + Record0.Ensemble.ExplorerGGAStruct0.LongMinutes / 60;


                    Record0.Ensemble.ExplorerGGAStruct0.Quality = ByteIn[36];
                    Record0.Ensemble.ExplorerGGAStruct0.NbrStas = ByteIn[37];

                    Record0.Ensemble.ExplorerGGAStruct0.HDOP = BitConverter.ToInt32(ByteIn, 38);
                    Record0.Ensemble.ExplorerGGAStruct0.Altitude = (double)(BitConverter.ToInt32(ByteIn, 42)) / 10000;
                    Record0.Ensemble.ExplorerGGAStruct0.GeoidalSep = BitConverter.ToInt32(ByteIn, 24);
                    Record0.Ensemble.ExplorerGGAStruct0.DiffAge = BitConverter.ToInt32(ByteIn, 24);
                    Record0.Ensemble.ExplorerGGAStruct0.DiffRef = BitConverter.ToInt32(ByteIn, 24);

                }
                else
                {
                    //LAT
                    Record0.Ensemble.ExplorerGGAStruct0.LatDegrees = ByteIn[26];
                    if (Record0.Ensemble.ExplorerGGAStruct0.LatDegrees > 180) { Record0.Ensemble.ExplorerGGAStruct0.LatDegrees -= 256; }

                    Record0.Ensemble.ExplorerGGAStruct0.LatMinutes = (double)(BitConverter.ToInt32(ByteIn, 27) * 60) / 10000000;

                    Record0.Ensemble.ExplorerGGAStruct0.Latitude = Record0.Ensemble.ExplorerGGAStruct0.LatDegrees + Record0.Ensemble.ExplorerGGAStruct0.LatMinutes / 60;

                    Record0.Ensemble.ExplorerGGAStruct0.NS = (char)ByteIn[31];

                    // LONG                                                                                /// 
                    Record0.Ensemble.ExplorerGGAStruct0.LongDegrees = ByteIn[32];
                    if (Record0.Ensemble.ExplorerGGAStruct0.LongDegrees > 180) { Record0.Ensemble.ExplorerGGAStruct0.LongDegrees -= 256; }

                    Record0.Ensemble.ExplorerGGAStruct0.LongMinutes = (double)(BitConverter.ToInt32(ByteIn, 33) * 60) / 10000000;

                    Record0.Ensemble.ExplorerGGAStruct0.longitude = Record0.Ensemble.ExplorerGGAStruct0.LongDegrees + Record0.Ensemble.ExplorerGGAStruct0.LongMinutes / 60;

                    Record0.Ensemble.ExplorerGGAStruct0.EW = (char)ByteIn[37];

                    Record0.Ensemble.ExplorerGGAStruct0.Quality = ByteIn[38];
                    Record0.Ensemble.ExplorerGGAStruct0.NbrStas = ByteIn[39];

                    Record0.Ensemble.ExplorerGGAStruct0.HDOP = BitConverter.ToInt32(ByteIn, 39);
                    Record0.Ensemble.ExplorerGGAStruct0.Altitude = (double)(BitConverter.ToInt32(ByteIn, 42)) / 10000;
                    //Record0.Ensemble.ExplorerGGAStruct0.GeoidalSep = BitConverter.ToInt32(ByteIn, 25);
                    //Record0.Ensemble.ExplorerGGAStruct0.DiffAge = BitConverter.ToInt32(ByteIn, 26);
                    //Record0.Ensemble.ExplorerGGAStruct0.DiffRef = BitConverter.ToInt32(ByteIn, 27);

                }
            }

            private void DecodeExplorerRMC(Byte[] ByteIn)
            {
                Record0.Ensemble.ExplorerRMCStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 2);
                Record0.Ensemble.ExplorerRMCStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 6);
                Record0.Ensemble.ExplorerRMCStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 10);
                Record0.Ensemble.ExplorerRMCStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 14);
                Record0.Ensemble.ExplorerRMCStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 18);

                Record0.Ensemble.ExplorerRMCStruct0.FixStatus =(char) ByteIn[22];

                Record0.Ensemble.ExplorerRMCStruct0.UTCMonth = ByteIn[23];
                Record0.Ensemble.ExplorerRMCStruct0.UTCDays = ByteIn[24];
                Record0.Ensemble.ExplorerRMCStruct0.UTCYears = ByteIn[25];
                Record0.Ensemble.ExplorerRMCStruct0.UTCHours = ByteIn[26];
                Record0.Ensemble.ExplorerRMCStruct0.UTCMinutes = ByteIn[27];
                Record0.Ensemble.ExplorerRMCStruct0.UTCSeconds = ByteIn[28];

                Record0.Ensemble.ExplorerRMCStruct0.LatDegrees = ByteIn[29];
                if (Record0.Ensemble.ExplorerRMCStruct0.LatDegrees > 180) { Record0.Ensemble.ExplorerRMCStruct0.LatDegrees -= 256; }

                Record0.Ensemble.ExplorerRMCStruct0.LatMinutes = (double)(BitConverter.ToInt32(ByteIn, 30) * 60) / 10000000;

                Record0.Ensemble.ExplorerRMCStruct0.Latitude = Record0.Ensemble.ExplorerRMCStruct0.LatDegrees + Record0.Ensemble.ExplorerRMCStruct0.LatMinutes / 60;

                Record0.Ensemble.ExplorerRMCStruct0.NS = (char)ByteIn[34];
                if (ByteIn[34] == 0) { Record0.Ensemble.ExplorerRMCStruct0.NS =(char)'0'; }

                // LONG                                                                                /// 
                Record0.Ensemble.ExplorerRMCStruct0.LongDegrees = ByteIn[35];
                if (Record0.Ensemble.ExplorerRMCStruct0.LongDegrees > 180) { Record0.Ensemble.ExplorerRMCStruct0.LongDegrees -= 256; }
                Record0.Ensemble.ExplorerRMCStruct0.LongMinutes = (double)(BitConverter.ToInt32(ByteIn, 36) * 60) / 10000000;

                Record0.Ensemble.ExplorerRMCStruct0.Longitude = Record0.Ensemble.ExplorerRMCStruct0.LongDegrees + Record0.Ensemble.ExplorerRMCStruct0.LongMinutes / 60;

                Record0.Ensemble.ExplorerRMCStruct0.EW = (char)ByteIn[40];

                Record0.Ensemble.ExplorerRMCStruct0.GroundSpeed = (double)(BitConverter.ToInt32(ByteIn, 41) * 60) / 10000000;

                Record0.Ensemble.ExplorerRMCStruct0.GroundCourse = (double)(BitConverter.ToInt32(ByteIn, 45) * 60) / 10000000;

                Record0.Ensemble.ExplorerRMCStruct0.Variation = ByteIn[49];

                Record0.Ensemble.ExplorerRMCStruct0.Altitude = 0;
            }


            private void DecodeExplorerVTG(Byte[] ByteIn)
            {
                Record0.Ensemble.ExplorerVTGStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 2);
                Record0.Ensemble.ExplorerVTGStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 6);
                Record0.Ensemble.ExplorerVTGStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 10);
                Record0.Ensemble.ExplorerVTGStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 14);
                Record0.Ensemble.ExplorerVTGStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 18);
                Record0.Ensemble.ExplorerVTGStruct0.TrueGroundCourse = (double)(BitConverter.ToInt32(ByteIn, 22)) / 100000;
                Record0.Ensemble.ExplorerVTGStruct0.MagGroundCourse = (double)(BitConverter.ToInt32(ByteIn, 26)) / 100000;
                Record0.Ensemble.ExplorerVTGStruct0.GroundSpeedKnots = (double)(BitConverter.ToInt32(ByteIn, 30)) / 100000;
                Record0.Ensemble.ExplorerVTGStruct0.GroundSpeedKm = (double)(BitConverter.ToInt32(ByteIn, 34) )/ 100000;

            }

            private void DecodeExplorerHDT(Byte[] ByteIn)
            {
                Record0.Ensemble.ExplorerHDTStruct0.TimeTag = BitConverter.ToInt32(ByteIn, 2);
                Record0.Ensemble.ExplorerHDTStruct0.SampleTime = BitConverter.ToInt32(ByteIn, 6);
                Record0.Ensemble.ExplorerHDTStruct0.DataAvailable = BitConverter.ToInt32(ByteIn, 10);
                Record0.Ensemble.ExplorerHDTStruct0.ErrorBit0 = BitConverter.ToInt32(ByteIn, 14);
                Record0.Ensemble.ExplorerHDTStruct0.ErrorBit1 = BitConverter.ToInt32(ByteIn, 18);
                Record0.Ensemble.ExplorerHDTStruct0.Heading =(double)( BitConverter.ToInt32(ByteIn, 22) )/ 100;
                Record0.Ensemble.ExplorerHDTStruct0.Pitch = (double)(BitConverter.ToInt32(ByteIn, 26)) / 1000;
                Record0.Ensemble.ExplorerHDTStruct0.Roll = (double)(BitConverter.ToInt32(ByteIn, 30) )/ 100;
            }


        ////  decode NMEA in RiverPro
        //    int MessageID,MessageID2,MessageSize;
            
        //    string titi,tata;
        //    private System.Text.Encoding enc = System.Text.Encoding.ASCII;
            int MessageSize = 0;
            Byte[] ByteNMEA;
            System.Globalization.CultureInfo cult0= new System.Globalization.CultureInfo("fr-FR");
             
            

            private void DecodeNMEA_Encapsulated(Byte[] ByteIn)
            { 
                cult0.NumberFormat.NumberDecimalSeparator = ".";
                Record0.Ensemble.RiverPro_NMEA_GGA0.NMEAIdCode = BitConverter.ToInt16(ByteIn, 0);
                Record0.Ensemble.RiverPro_NMEA_GGA0.NMEAMessageId = BitConverter.ToInt16(ByteIn, 2);
                MessageSize = BitConverter.ToInt16(ByteIn, 4);
                ByteNMEA = new Byte[MessageSize];
                 Array.Copy(ByteIn,14, ByteNMEA,0, MessageSize);


                switch (Record0.Ensemble.RiverPro_NMEA_GGA0.NMEAMessageId)   //   0x2022, "NMEA structure");     //8226
                {
                    case 4:   //  internal GPS GGA   //   River Pro
                                            string NMEAmessage = null; 
                                            NMEAmessage = System.Text.Encoding.ASCII.GetString(ByteNMEA);

                                            string[] Split = NMEAmessage.Split(',');
                                            if (Split.Length < 5) { return; }


                                            double Latdeg=0;
                                            double latMin=0;
                                            double LongDeg= 0;
                                            double LongMin= 0;
                                            double  TimeSec=0;

                                            int TimeH, TimeMin, TimeMsec, TimeSecInt,DateYear,DateMonth,DateDay;

                                            int.TryParse(Split[1].Substring(0, 2), out TimeH);
                                            int.TryParse(Split[1].Substring(2, 2), out TimeMin);
                                            Double.TryParse(Split[1].Substring(4), NumberStyles.Number, cult0.NumberFormat, out TimeSec);
                                            TimeMsec=(int)((TimeSec-Math.Floor(TimeSec))*1000);
                                            TimeSecInt = (int)Math.Floor(TimeSec);

                                            Record0.Ensemble.RiverPro_NMEA_INT_GGA0.UTCtime = new DateTime(1900, 01, 01, TimeH, TimeMin, TimeSecInt, TimeMsec, Calendar.CurrentEra);

                                            //GGAPosition0.GPSTime = DateTime.Parse(Split[1], "hhmmss");


                                            if (Split[2].Length > 1) { Double.TryParse(Split[2].Substring(0, 2), out Latdeg); }
                                            if (Split[2].Length > 2) { Double.TryParse(Split[2].Substring(2),NumberStyles.Number, cult0.NumberFormat, out latMin); }
                                            Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Latitude = Latdeg + latMin / 60;
                                            if (Split[3] == "S") { Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Latitude = -Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Latitude; }

                                            if (Split[4].Length > 2) { Double.TryParse(Split[4].Substring(0, 3), out LongDeg); }
                                            if (Split[4].Length > 3) { Double.TryParse(Split[4].Substring(3), NumberStyles.Number, cult0.NumberFormat, out LongMin); }
                                            Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Longitude = LongDeg + LongMin / 60;
                                            if (Split[5] == "W") { Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Longitude = -Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Longitude; }

                                            if (Split[9].Length > 0) { Double.TryParse(Split[9], out  Record0.Ensemble.RiverPro_NMEA_INT_GGA0.Altitude); }


                                            RefDataTypeYesNo0[0x2022] = true;

                        break;

                    case 104:   //  External GPS GGA

                        Record0.Ensemble.WinRiverGGA.Header = System.Text.Encoding.ASCII.GetString(ByteNMEA, 0, 7);
                        string GGATime = System.Text.Encoding.ASCII.GetString(ByteNMEA, 7, 10);
                        Record0.Ensemble.WinRiverGGA.LatConvertedToDeg = BitConverter.Int64BitsToDouble(BitConverter.ToInt64(ByteNMEA,17));
                        Record0.Ensemble.WinRiverGGA.NorthSouth = System.Text.Encoding.ASCII.GetString(ByteNMEA, 25, 1);

                        if (Record0.Ensemble.WinRiverGGA.NorthSouth == "S") { Record0.Ensemble.WinRiverGGA.LatConvertedToDeg = -Record0.Ensemble.WinRiverGGA.LatConvertedToDeg; }

                        Record0.Ensemble.WinRiverGGA.LongConvertedToDeg = BitConverter.Int64BitsToDouble(BitConverter.ToInt64(ByteNMEA, 26));
                        Record0.Ensemble.WinRiverGGA.EastWest = System.Text.Encoding.ASCII.GetString(ByteNMEA, 34, 1);

                        if (Record0.Ensemble.WinRiverGGA.EastWest == "W") { Record0.Ensemble.WinRiverGGA.LongConvertedToDeg = -Record0.Ensemble.WinRiverGGA.LongConvertedToDeg; }

                        Record0.Ensemble.WinRiverGGA.Quality = ByteNMEA[35];
                        Record0.Ensemble.WinRiverGGA.Altitude = BitConverter.ToSingle(ByteNMEA, 41);


                    break;

                    case (int)105:   //  External GPS VTG

                    break;

                    case (int)106:   //  External DBT

                    break;

                    case (int)107:   //  External HDT

                    break;
                }            



                
                
                 //titi = System.Text.Encoding.UTF8.GetString(ByteNMEA);
                 //  tata = enc.GetString(ByteNMEA);

            }





        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////// Decode profiles   //////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////
            
        
        
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
                switch (Record0.Ensemble.FixedLeader.CoordinateSystem)
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
                        TempVel.Data1Name = "Vel beam 1-2";
                        TempVel.Data2Name = "Vel beam 4-3";
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
                NbrBeams = Record0.Ensemble.FixedLeader.NbrBeam;
                NbrBeams = 4;
                NbrDepthCells = Record0.Ensemble.FixedLeader.NumberOfDepthCells;

                if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }

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
                switch (Record0.Ensemble.FixedLeader2.CoordinateSystem)
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
                        TempVel.Data1Name = "Vel beam 1-2";
                        TempVel.Data2Name = "Vel beam 4-3";
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
                NbrBeams = Record0.Ensemble.FixedLeader2.NbrBeam;
                NbrBeams = 4;
                NbrDepthCells = Record0.Ensemble.FixedLeader2.NumberOfDepthCells;

                if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }

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
                NbrBeams = Record0.Ensemble.FixedLeader.NbrBeam;
                //  do not use number of beams
                NbrBeams = 4;
                NbrDepthCells = Record0.Ensemble.FixedLeader.NumberOfDepthCells;

                if (DataName.StartsWith("Surface")) { NbrDepthCells = Record0.Ensemble.SurfaceLayerLeaderFormat.SURFACE_LAYER_CELL_COUNT; }


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
                Record0.Packet.PacketByte = TempsRecord0;
                int OffsetToCheckSum = TempsRecord0[3] * 256 + TempsRecord0[2];
                int NumberOfDataType = TempsRecord0[5];
                int[] offsetToEachDataType = new int[NumberOfDataType];
                int[] SizeOfEachDataType = new int[NumberOfDataType];
                //  set offset
                for (int i = 0; i < NumberOfDataType; i++)
                {
                    offsetToEachDataType[i] = TempsRecord0[6 + 2 * i];
                }
                //  need to determine the size of each data type
                for (int i = 0; i < NumberOfDataType; i++)
                {
                    if (i + 1 < NumberOfDataType)
                    {
                        SizeOfEachDataType[i] = offsetToEachDataType[i + 1] - offsetToEachDataType[i];
                    }
                    else
                    {
                        SizeOfEachDataType[i] = TempsRecord0.Length - offsetToEachDataType[i] - 2;
                    }
                }

                for (int i = 0; i < NumberOfDataType; i++)
                {
                    byte[] tempDatatype = new byte[SizeOfEachDataType[i]];
                    Array.Copy(TempsRecord0, offsetToEachDataType[i], tempDatatype, 0, SizeOfEachDataType[i]);
                    int DataType = tempDatatype[0] + tempDatatype[1] * 256;

                    Record0.Packet.PacketType = PacketTypeEnum.WavesPacket;

                    switch (DataType)
                    {
                        case 259://  First leader type
                            Record0.Packet.PacketType = PacketTypeEnum.FirstLeader;
                            Record0.Packet.WavesPacketLeader = decodeFirstLeader(tempDatatype);
                            //Record0.Packet.WavesPacketLeader=
                            break;
                        case 515:  //  Waves ping
                            Record0.Packet.WavesPacketWavesPing = decodeWavesping(tempDatatype);
                            break;
                        case 771:  //   Last leader
                            Record0.Packet.PacketType = PacketTypeEnum.LastLeader;
                            Record0.Packet.WavesPacketsLastLeader = decodeWavesLastLeader(tempDatatype);
                            break;
                        case 772:  //   HPR
                            Record0.Packet.WavesPacketsHPR = decodewavesHPR(tempDatatype);
                            break;
                        default:

                            break;
                    }

                }

                return true;
            }

            //   decode first leader  // Burst start
            private WavesPacketLeaderStruct decodeFirstLeader(byte[] tempDatatype)
            {
                WavesPacketLeaderStruct tempWLStruct = Record0.Packet.WavesPacketLeader;

                //TempWavesPacket.WavesPacketLeaderByte0 = tempDatatype;  // tableau de bytes
                tempWLStruct.FirmwareVersion = tempDatatype[2];
                tempWLStruct.FirmwareRevision = tempDatatype[3];
                tempWLStruct.Bitmap = tempDatatype[3] + tempDatatype[4] * 256;
                tempWLStruct.Nbins = tempDatatype[6];
                tempWLStruct.WaveRecPings = tempDatatype[7] + tempDatatype[8] * 256;
                tempWLStruct.BinLength = tempDatatype[9] + tempDatatype[10] * 256;
                tempWLStruct.TimeBetweenPing = tempDatatype[11] + tempDatatype[12] * 256;
                tempWLStruct.TimeBetweenBurst = tempDatatype[13] + tempDatatype[14] * 256;
                tempWLStruct.DistMidBin1 = tempDatatype[15] + tempDatatype[16] * 256;
                tempWLStruct.BinsOut = tempDatatype[17];
                tempWLStruct.SelectedData = tempDatatype[18] + tempDatatype[19] * 256;
                tempWLStruct.DWSBins = tempDatatype[20] + tempDatatype[21] * 256 + tempDatatype[22] * 65536 + tempDatatype[23] * 16777216;
                tempWLStruct.VelBins = tempDatatype[24] + tempDatatype[25] * 256 + tempDatatype[26] * 65536 + tempDatatype[27] * 16777216;


                //string DateString = VariableLeaderInt0.DayE + "/" + VariableLeaderInt0.Month + "/" + VariableLeaderInt0.Year + " " + VariableLeaderInt0.Hour + ":" + VariableLeaderInt0.Minutes + ":" + VariableLeaderInt0.Secondes + "." + VariableLeaderInt0.HundredofSecondes;
                //VariableLeaderInt0.EnsTime = DateTime.Parse(DateString, culture);

                string DateString = tempDatatype[55].ToString() + "/" + tempDatatype[54].ToString() + "/" + (tempDatatype[53] + 2000).ToString() + " " + tempDatatype[56].ToString() + ":" + tempDatatype[57].ToString() + ":" + tempDatatype[58].ToString() + "." + tempDatatype[59].ToString();

                tempWLStruct.StartTime = DateTime.Parse(DateString, culture);

                tempWLStruct.BurstNumber = tempDatatype[60] + tempDatatype[61] * 256 + tempDatatype[62] * 65536 + tempDatatype[63] * 16777216;
                tempWLStruct.SerialNumber = tempDatatype[64] + tempDatatype[65] + tempDatatype[66] + tempDatatype[67] + tempDatatype[68] + tempDatatype[69] + tempDatatype[70] + tempDatatype[71];
                tempWLStruct.Temperature = tempDatatype[72] + tempDatatype[73];
                tempWLStruct.Reserved = tempDatatype[74] + tempDatatype[75];

                return tempWLStruct;
            }

            private WavesPacketWavesPingStruct decodeWavesping(byte[] tempDatatype)
            {
                WavesPacketWavesPingStruct TempWaves = Record0.Packet.WavesPacketWavesPing;

                TempWaves.PingNumber = tempDatatype[2] + tempDatatype[3] * 256;
                TempWaves.TimeSinceStart = tempDatatype[4] + tempDatatype[5] * 256 + tempDatatype[6] * 65536 + tempDatatype[7] * 4294967296;
                TempWaves.Pressure = tempDatatype[8] + tempDatatype[9] * 256 + tempDatatype[10] * 65536 + tempDatatype[11] * 4294967296;
                for (int i = 0; i < 4; i++)
                {
                    TempWaves.Dist2Surf[i] = tempDatatype[12 + i * 4] + tempDatatype[13 + i * 4] * 256 + tempDatatype[14 + i * 4] * 65536 + tempDatatype[15 + i * 4] * 4294967296;
                }
                //for (int i = 0; i < 4; i++)
                //{
                //    TempWaves.Dist2Surf[i] = tempDatatype[12 + i * 4] + tempDatatype[13 + i * 4] * 256 + tempDatatype[14 + i * 4] * 65536 + tempDatatype[15 + i * 4] * 4294967296;
                //}

                //            public int WavesPacketWavesPingIDWord;      //      2 bytes     0x0203
                //public int PingNumber;                      //      2 Bytes     Sample #
                //public int TimeSinceStart;                  //      4 bytes     Time since beginning of burst hund. Sec.       
                //public int Pressure;                        //      4 bytes     Pressure deca Pa
                //public int[] Dist2Surf;                       //      16 bytes    Range to surface for 4 beams (-1 = bad) mm
                // public int[] Velocity;  
                return TempWaves;
            }

            private WavesPacketsHPRStruct decodewavesHPR(byte[] tempDatatype)
            {
                WavesPacketsHPRStruct TempHPRWaves = Record0.Packet.WavesPacketsHPR;

                TempHPRWaves.WavesPacketHPRIDWord = tempDatatype[0] + tempDatatype[1] * 256;
                TempHPRWaves.Heading = tempDatatype[2] + tempDatatype[3] * 256;
                TempHPRWaves.Pitch = tempDatatype[4] + tempDatatype[5] * 256;
                TempHPRWaves.Roll = tempDatatype[6] + tempDatatype[7] * 256;
                return TempHPRWaves;
            }

            private WavesPacketsLastLeaderStruct decodeWavesLastLeader(byte[] tempDatatype)
            {
                WavesPacketsLastLeaderStruct TempWavesLastLeader = Record0.Packet.WavesPacketsLastLeader;

                TempWavesLastLeader.WavesPacketsLastLeaderIDWord = tempDatatype[0] + tempDatatype[1] * 256;    //  2 bytes      ID 2 First leader ID word 0x0303
                TempWavesLastLeader.AvgDepth = tempDatatype[2] + tempDatatype[3] * 256;                        //  2 bytes      Average Depth dm
                TempWavesLastLeader.AvgC = tempDatatype[4] + tempDatatype[5] * 256;                            //  2 bytes      Average Speed of Sound m/s
                TempWavesLastLeader.AvgTemp = tempDatatype[6] + tempDatatype[7] * 256;                         //  2 bytes     Average Temperature 0.01 deg C
                TempWavesLastLeader.AvgHeading = tempDatatype[8] + tempDatatype[9] * 256;                      //  2 bytes     2 Average Heading 0.01 deg
                TempWavesLastLeader.StdHeading = tempDatatype[10] + tempDatatype[11] * 256;                      //  2 bytes     Standard Dev Heading 0.01 deg
                TempWavesLastLeader.AvgPitch = tempDatatype[12] + tempDatatype[13] * 256;                         // 2 bytes      Average Pitch 0.01 deg
                if (TempWavesLastLeader.AvgPitch > 32767) { TempWavesLastLeader.AvgPitch -= 65536; }
                TempWavesLastLeader.StdPitch = tempDatatype[14] + tempDatatype[15] * 256;                       // 2 bytes      Standard Dev Pitch 0.01 deg
                TempWavesLastLeader.AvgRoll = tempDatatype[16] + tempDatatype[17] * 256;                         // 2 bytes      Average Roll 0.01 deg
                if (TempWavesLastLeader.AvgRoll > 32767) { TempWavesLastLeader.AvgPitch -= 65536; }
                TempWavesLastLeader.StdRoll = tempDatatype[18] + tempDatatype[19] * 256;                         // 2 bytes      Standard Dev Roll 0.01 deg

                return TempWavesLastLeader;

            }


            #endregion



            #endregion

            #region Utils

            //////////////////  Calculate PD0 binary checksum   
            private static int ChecksumCompute0(byte[] Ens0)
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

            private static bool ChecksumVerify0(Byte[] EnsIn)
            {
                int TempCheckSum = EnsIn[EnsIn.Length - 2] + EnsIn[EnsIn.Length - 1] * 256;

                return (TempCheckSum == ChecksumCompute0(EnsIn));
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
                int Newchecksum = ChecksumCompute0(EnsOut);
                tempMSB = Math.DivRem(Newchecksum, 256, out tempLSB);
                EnsOut[EnsInLength - 2] = (byte)tempLSB;
                EnsOut[EnsInLength - 1] = (byte)tempMSB;
                return EnsOut;

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

            //////////////////  Calculate PD0 binary checksum   //////////////////


            ////   Detect ADCP data file
            //private bool IsADCPDataFile0(string FileP)
            //{
            //    bool YesNo = true;
            //    Class_PD0 PD1 = new Class_PD0();
            //    Class_PD0.ReadFile PD1Read = new Class_PD0.ReadFile(FileP);
            //    Class_PD0.RecordType PD1RecordType = PD1Read.GetFirstRecord();
            //    if (PD1RecordType == Class_PD0.RecordType.EndFile || PD1RecordType == Class_PD0.RecordType.None || PD1RecordType == Class_PD0.RecordType.ProcessError)
            //    { YesNo = false; }

            //    PD1 = null;
            //    PD1Read = null;

            //    return YesNo;
            //}

            #endregion
    }
}
