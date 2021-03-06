//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using RosMessageGeneration;

namespace RosMessageTypes.RoboticsDemo
{
    public class PWM : Message
    {
        public const string RosMessageName = "robotics_demo/PWM";

        public float pwm_left;
        public float pwm_right;

        public PWM()
        {
            this.pwm_left = 0.0f;
            this.pwm_right = 0.0f;
        }

        public PWM(float pwm_left, float pwm_right)
        {
            this.pwm_left = pwm_left;
            this.pwm_right = pwm_right;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.pwm_left));
            listOfSerializations.Add(BitConverter.GetBytes(this.pwm_right));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.pwm_left = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.pwm_right = BitConverter.ToSingle(data, offset);
            offset += 4;

            return offset;
        }

        public override string ToString()
        {
            return "PWM: " +
            "\npwm_left: " + pwm_left.ToString() +
            "\npwm_right: " + pwm_right.ToString();
        }
    }
}
