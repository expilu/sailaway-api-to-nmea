using NMEAServerLib;
using RestSharp.Deserializers;
using SailawayToNMEA.App;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
***REMOVED***

namespace SailawayToNMEA.Model
***REMOVED***
    public class BoatInfo
    ***REMOVED***
        [DeserializeAs(Name = "usrnr")]
        public Int64 UserNumber ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "usrname")]
        public string UserName ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtnr")]
        public Int64 BoatNumber ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtname")]
        public string BoatName ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtlat")]
        public double Latitude ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtlon")]
        public double Longitude ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtheading")]
        public double Heading ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtspeed")]
        public double Speed ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubbtpnr")]
        public int BoatType ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtmisnr")]
        public Int64 MissionNumber ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "online")]
        public bool Online ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubttruewinddir")]
        public Nullable<double> TrueWindDirection ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubttruewindangle")]
        public Nullable<double> TrueWindAngle ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtappwindangle")]
        public Nullable<double> ApparentWindAngle ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubttruewindspeed")]
        public Nullable<double> TrueWindSpeed ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtappwindspeed")]
        public Nullable<double> ApparentWindSpeed ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtranaground")]
        public bool RunAground ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtcourseoverground")]
        public Nullable<double> CourseOverGround ***REMOVED*** get; set; ***REMOVED***

        [DeserializeAs(Name = "ubtspeedoverground")]
        public Nullable<double> SpeedOverGround ***REMOVED*** get; set; ***REMOVED***

        public void toInstrumentsData(ref InstrumentsData instrumentsData)
        ***REMOVED***
            int awa = Convert.ToInt32(ApparentWindAngle);
            int awa360 = awa < 0 ? awa + 360 : awa;
            instrumentsData.ApparentWindAngle = awa360;
            instrumentsData.ApparentWindSpeed = ApparentWindSpeed * Conf.MS_TO_KNOTS;
            instrumentsData.CourseOverGround = Convert.ToInt32(CourseOverGround);
            instrumentsData.Heading = Convert.ToInt32(Heading);
            instrumentsData.Lat = Latitude;
            instrumentsData.Lon = Longitude;
            instrumentsData.SpeedOverGround = SpeedOverGround * Conf.MS_TO_KNOTS;
            int twa = Convert.ToInt32(TrueWindAngle);
            int twa360 = twa < 0 ? twa + 360 : twa;
            instrumentsData.TrueWindAngle = twa360;
            instrumentsData.TrueWindSpeed = TrueWindSpeed * Conf.MS_TO_KNOTS;
            instrumentsData.WaterSpeed = Speed * Conf.MS_TO_KNOTS;
    ***REMOVED***
***REMOVED***
***REMOVED***
