using NiCris.Client.BusinessStream.Aspects;
using System;
using System.Diagnostics;
using System.Threading;

namespace NiCris.Client.BusinessStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            for (int i = 0; i < 5; i++)
            {
                var patient = new Patient2("FullName: " + i.ToString(), i + 20, DateTime.Now.AddYears(-i));
                var device = new Device2("Serial: " + i.ToString(), DateTime.Now.AddYears(-i * 2));

                Patient2.Save(patient);
                Device2.Update(device);
            }
        }
    }

    public class Patient2
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }

        public Patient2(string fullName, int age, DateTime dob)
        {
            this.FullName = fullName;
            this.Age = age;
            this.DOB = dob;
        }

        [BizMsgExAspect("FullName", "Save Patient2")]
        public static void Save(Patient2 patient)
        {
            Thread.Sleep(100);
        }
    }

    public class Device2
    {
        public string Serial { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Device2(string serial, DateTime releaseDate)
        {
            this.Serial = serial;
            this.ReleaseDate = releaseDate;
        }

        [BizMsgExAspect("Serial", "Update Device2")]
        public static void Update(Device2 device)
        {
            Thread.Sleep(100);
        }
    }
}
