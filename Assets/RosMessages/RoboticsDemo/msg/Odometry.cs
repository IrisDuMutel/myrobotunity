//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RosMessageGeneration;

namespace RosMessageTypes.RoboticsDemo
{
    public class Odometry : Message
    {
        public const string RosMessageName = "robotics_demo/Odometry";

        public float pos_x;
        public float pos_y;
        public float pos_z;
        public float orient_1;
        public float orient_2;
        public float orient_3;
        public float vel_x;
        public float vel_y;
        public float vel_z;
        public float ang_x;
        public float ang_y;
        public float ang_z;

        public Odometry()
        {
            this.pos_x = 0.0f;
            this.pos_y = 0.0f;
            this.pos_z = 0.0f;
            this.orient_1 = 0.0f;
            this.orient_2 = 0.0f;
            this.orient_3 = 0.0f;
            this.vel_x = 0.0f;
            this.vel_y = 0.0f;
            this.vel_z = 0.0f;
            this.ang_x = 0.0f;
            this.ang_y = 0.0f;
            this.ang_z = 0.0f;
        }

        public Odometry(float pos_x, float pos_y, float pos_z, float orient_1, float orient_2, float orient_3, float vel_x, float vel_y, float vel_z, float ang_x, float ang_y, float ang_z)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.pos_z = pos_z;
            this.orient_1 = orient_1;
            this.orient_2 = orient_2;
            this.orient_3 = orient_3;
            this.vel_x = vel_x;
            this.vel_y = vel_y;
            this.vel_z = vel_z;
            this.ang_x = ang_x;
            this.ang_y = ang_y;
            this.ang_z = ang_z;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.pos_x));
            listOfSerializations.Add(BitConverter.GetBytes(this.pos_y));
            listOfSerializations.Add(BitConverter.GetBytes(this.pos_z));
            listOfSerializations.Add(BitConverter.GetBytes(this.orient_1));
            listOfSerializations.Add(BitConverter.GetBytes(this.orient_2));
            listOfSerializations.Add(BitConverter.GetBytes(this.orient_3));
            listOfSerializations.Add(BitConverter.GetBytes(this.vel_x));
            listOfSerializations.Add(BitConverter.GetBytes(this.vel_y));
            listOfSerializations.Add(BitConverter.GetBytes(this.vel_z));
            listOfSerializations.Add(BitConverter.GetBytes(this.ang_x));
            listOfSerializations.Add(BitConverter.GetBytes(this.ang_y));
            listOfSerializations.Add(BitConverter.GetBytes(this.ang_z));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.pos_x = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.pos_y = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.pos_z = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.orient_1 = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.orient_2 = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.orient_3 = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.vel_x = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.vel_y = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.vel_z = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.ang_x = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.ang_y = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.ang_z = BitConverter.ToSingle(data, offset);
            offset += 4;

            return offset;
        }

        public override string ToString()
        {
            return "Odometry: " +
            "\npos_x: " + pos_x.ToString() +
            "\npos_y: " + pos_y.ToString() +
            "\npos_z: " + pos_z.ToString() +
            "\norient_1: " + orient_1.ToString() +
            "\norient_2: " + orient_2.ToString() +
            "\norient_3: " + orient_3.ToString() +
            "\nvel_x: " + vel_x.ToString() +
            "\nvel_y: " + vel_y.ToString() +
            "\nvel_z: " + vel_z.ToString() +
            "\nang_x: " + ang_x.ToString() +
            "\nang_y: " + ang_y.ToString() +
            "\nang_z: " + ang_z.ToString();
        }
    }
}
