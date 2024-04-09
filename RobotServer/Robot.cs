using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RobotServer
{
    class Robot
    {
        public int id;
        public Vector3 coordinates;
        public float Pitch;
        public float Jaw;
        public float Roll;
        public float Grippervalue;

        public Robot(int _id, Vector3 _coordinates, float _Pitch, float _Jaw, float _Roll, float _Grippervalue)
        {
            id = _id;
            coordinates = _coordinates;
            Pitch = _Pitch;
            Jaw = _Jaw;
            Roll = _Roll;
            Grippervalue = _Grippervalue;

        }


    }
}
