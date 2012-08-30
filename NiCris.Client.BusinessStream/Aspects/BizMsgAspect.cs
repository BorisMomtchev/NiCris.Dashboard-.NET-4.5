using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace NiCris.Client.BusinessStream.Aspects
{
    [Serializable]
    public sealed class BizMsgAspect : OnMethodBoundaryAspect
    {
        // Assigned and serialized at build time, then deserialized and read at runtime.
        private string MethodName { get; set; }
        private ParameterInfo[] ParameterInfo { get; set; }

        // Requires
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        // Optional
        public string Description { get; set; }
        public string AppId { get; set; }
        public string ServiceId { get; set; }
        public string StyleId { get; set; }
        public string Roles { get; set; }

        // C~tor
        public BizMsgAspect(string name)
        {
            this.Name = name;
            this.Date = DateTime.Now;
            this.User = string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name) ? "Empty" : WindowsIdentity.GetCurrent().Name;
        }

        // This method is executed at build-time, inside PostSharp.
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            // Computes the field value at build-time so that reflection is not necessary at runtime.
            this.MethodName = method.DeclaringType.FullName + "." + method.Name;
            this.ParameterInfo = method.GetParameters();
        }

        // This method is executed at runtime inside your application, before target methods
        public override void OnEntry(MethodExecutionArgs args)
        {
            // Trace.WriteLine(MethodName + "\n\n - OnEntry");
            Trace.WriteLine(string.Format("Name: {0}, Date: {1}, User: {2}", Name, Date.ToString(), User));
            Trace.WriteLine(string.Format("MethodName: {0}", MethodName));
            Trace.WriteLine(args.Method.DeclaringType.Name);

            // TODOs:
            // 1. Find the index of the arg
            // 2. Use the name of the property; shall be specified in the this.Name by convention
            // 3. Get the value; construct the BizMsg and send to REST
            var oVal = args.Arguments.GetArgument(0);
            Trace.WriteLine(args.Method.DeclaringType.GetProperty(Name).GetValue(oVal, null));

            /*
            var val = GetPropValue(oVal, Name);
            Trace.WriteLine(val);
            */

            /*
            Type oType = args.Method.GetParameters()[0].ParameterType;
            var con = Convert.ChangeType(oVal, oType);
            var someObj = Activator.CreateInstance(oType, oVal);
            */
        }

        // This method is executed at runtime inside your application, when target methods exit with success
        public override void OnSuccess(MethodExecutionArgs args)
        {
            // Trace.WriteLine(MethodName + " - OnSuccess");
        }

        // This method is executed at runtime inside your application, when target methods exit with an exception
        public override void OnException(MethodExecutionArgs args)
        {
            // Trace.WriteLine(MethodName + " - OnException\n" + args.Exception.Message);
        }


        // *** HELPERS
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static T CastHelper<T>(object input)
        {
            return (T)input;
        }

        public T ConvertHelper<T>(object input)
        {
            return (T)Convert.ChangeType(input, typeof(T));
        }

    }
}
