using NMEAServerLib;
using RestSharp.Deserializers;
using SailawayToNMEA.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NMEAServerLib.InstrumentsData;

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

        [DeserializeAs(Name = "depth")]
        public Nullable<double> Depth { get; set; }

        public Nullable<FixQualityType> FixQuality { get; set; }

        public DateTime FixTime { get; set; }

        public void toInstrumentsData(ref InstrumentsData instrumentsData)
        {
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
            instrumentsData.Depth = Depth;
            instrumentsData.TransducerDepth = 0;
            instrumentsData.FixQuality = FixQuality;
        }
    }
}
