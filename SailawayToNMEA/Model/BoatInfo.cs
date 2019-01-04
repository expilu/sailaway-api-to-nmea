using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.Model
{
    public class BoatInfo
    {
        [DeserializeAs(Name = "usrnr")]
        public Int64 UserNumber { get; set; }

        [DeserializeAs(Name = "usrname")]
        public string UserName { get; set; }

        [DeserializeAs(Name = "ubtnr")]
        public Int64 BoatNumber { get; set; }

        [DeserializeAs(Name = "ubtname")]
        public string BoatName { get; set; }

        [DeserializeAs(Name = "ubtlat")]
        public double Latitude { get; set; }

        [DeserializeAs(Name = "ubtlon")]
        public double Longitude { get; set; }

        [DeserializeAs(Name = "ubtheading")]
        public double Heading { get; set; }

        [DeserializeAs(Name = "ubtspeed")]
        public double Speed { get; set; }

        [DeserializeAs(Name = "ubbtpnr")]
        public int BoatType { get; set; }

        [DeserializeAs(Name = "ubtmisnr")]
        public Int64 MissionNumber { get; set; }

        [DeserializeAs(Name = "online")]
        public bool Online { get; set; }

        [DeserializeAs(Name = "ubttruewinddir")]
        public Nullable<double> TrueWindDirection { get; set; }

        [DeserializeAs(Name = "ubttruewindangle")]
        public Nullable<double> TrueWindAngle { get; set; }

        [DeserializeAs(Name = "ubtappwindangle")]
        public Nullable<double> ApparentWindAngle { get; set; }

        [DeserializeAs(Name = "ubttruewindspeed")]
        public Nullable<double> TrueWindSpeed { get; set; }

        [DeserializeAs(Name = "ubtappwindspeed")]
        public Nullable<double> ApparentWindSpeed { get; set; }

        [DeserializeAs(Name = "ubtranaground")]
        public bool RunAground { get; set; }

        [DeserializeAs(Name = "ubtcourseoverground")]
        public Nullable<double> CourseOverGround { get; set; }

        [DeserializeAs(Name = "ubtspeedoverground")]
        public Nullable<double> SpeedOverGround { get; set; }
    }
}
