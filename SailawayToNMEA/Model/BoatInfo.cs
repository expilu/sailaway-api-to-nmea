using RestSharp.Deserializers;
using System;
***REMOVED***
***REMOVED***
***REMOVED***
***REMOVED***

namespace SailawayToNMEA.Model
***REMOVED***
    class BoatInfo
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
***REMOVED***
***REMOVED***
