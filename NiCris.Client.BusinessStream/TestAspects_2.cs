using NiCris.Client.BusinessStream.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace NiCris.Client.BusinessStream
{
    class TestAspects_2
    {
        static void Main_2(string[] args)
        {
            System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            for (int i = 0; i < 2; i++)
            {
                var patient = new Patient("FullName: " + i.ToString(), i + 20, DateTime.Now.AddYears(-i));
                var device = new Device("Serial: " + i.ToString(), DateTime.Now.AddYears(-i * 2));

                Patient.Save(patient);
                Device.Save(device);
            }
        }
    }

    public class Patient 
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        public Patient(){}
        public Patient(string fullName, int age, DateTime dob)
        {
            this.FullName = fullName;
            this.Age = age;
            this.DOB = dob;
        }

        [BizMsgAspect_2("FullName", AppId = "Patient")]
        public static void Save(Patient patient)
        {
            Thread.Sleep(100);
        }
    }

    public class Device
    {
        public string Serial { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Device(string serial, DateTime releaseDate)
        {
            this.Serial = serial;
            this.ReleaseDate = releaseDate;
        }

        [BizMsgAspect_2("Serial", AppId = "Device")]
        public static void Save(Device device)
        {
            Thread.Sleep(100);
        }
    }
}
