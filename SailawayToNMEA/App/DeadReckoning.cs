using SailawayToNMEA.App.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailawayToNMEA.App
{
    class DeadReckoning
    {
        public static bool Active { get; set; }

        public static void StartDeadReckoningTask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (Global.Instance.Boat != null && Active)
                    {

                        double currentLat = Global.Instance.Boat.Latitude;
                        double currentLon = Global.Instance.Boat.Longitude;
                        double timeElapsed = ((TimeSpan) (DateTime.Now - Global.Instance.Boat.FixTime)).TotalMilliseconds / 1000;
                        double speed = Global.Instance.Boat.SpeedOverGround ?? 0;
                        double distance = speed * timeElapsed;
                        double heading = Global.Instance.Boat.CourseOverGround ?? Global.Instance.Boat.Heading;
                        double radius = 6371 * 1000;
                        double δ = distance / radius;
                        double θ = toRadians(heading);
                        double φ1 = toRadians(currentLat);
                        double λ1 = toRadians(currentLon);
                        double sinφ1 = Math.Sin(φ1);
                        double cosφ1 = Math.Cos(φ1);
                        double sinδ = Math.Sin(δ);
                        double cosδ = Math.Cos(δ);
                        double sinθ = Math.Sin(θ);
                        double cosθ = Math.Cos(θ);
                        double sinφ2 = sinφ1 * cosδ + cosφ1 * sinδ * cosθ;
                        double φ2 = Math.Asin(sinφ2);
                        double y = sinθ * sinδ * cosφ1;
                        double x = cosδ - sinφ1 * sinφ2;
                        double λ2 = λ1 + Math.Atan2(y, x);

                        double newLat = toDegrees(φ2);
                        double newLon = (toDegrees(λ2) + 540) % 360 - 180;

                        Global.Instance.Boat.Latitude = newLat;
                        Global.Instance.Boat.Longitude = newLon;

                        Global.Instance.Boat.FixQuality = NMEAServerLib.InstrumentsData.FixQualityType.ESTIMATED_DEAD_RECKONING;

                        Global.Instance.MessageHub.PublishAsync(new SelectedBoatRefreshed(Global.Instance, Global.Instance.Boat));
                    }

                    await Task.Delay(Conf.DEAD_RECKONING_RATE);
                }
            });
        }

        private static double toRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private static double toDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
