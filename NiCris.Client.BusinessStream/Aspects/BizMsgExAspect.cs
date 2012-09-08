using NiCris.BusinessObjects;
using PostSharp.Aspects;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace NiCris.Client.BusinessStream.Aspects
{
    [Serializable]
    public class BizMsgExAspect : OnMethodBoundaryAspect
    {
        // Assigned and serialized at build time, then deserialized and read at runtime.
        private string MethodName { get; set; }
        private ParameterInfo[] ParameterInfo { get; set; }

        // *** Required and Supplied by User
        public string EntityName { get; set; }
        public string EntityAction { get; set; }

        // *** Derived at Runtime
        public string EntityType { get; set; }
        public string EntityValue { get; set; }

        public string EntityStatus { get; set; }
        public string EntityErrorMessage { get; set; }
        public string EntityStackTrace { get; set; }

        public DateTime Date { get; set; }
        public string User { get; set; }

        // C~tor
        public BizMsgExAspect(string entityName, string entityAction)
        {
            this.EntityName = entityName;
            this.EntityAction = entityAction;
        }

        // This method is executed at runtime inside your application, before target methods
        public override void OnEntry(MethodExecutionArgs args)
        {
            object oVal = args.Arguments.GetArgument(0);
            Type oType = args.Method.GetParameters()[0].ParameterType;

            this.EntityValue = args.Method.DeclaringType.GetProperty(EntityName).GetValue(oVal, null).ToString();
            this.EntityType = oType.ToString();

            this.Date = DateTime.Now;
            this.User = string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name) ? "Empty" : WindowsIdentity.GetCurrent().Name;
        }


        // This method is executed at runtime inside your application, when target methods exit with success
        public override void OnSuccess(MethodExecutionArgs args)
        {
            // Trace.WriteLine(MethodName + " - OnSuccess");

            var bizMsgExDTO = new BizMsgExDTO
            {
                EntityName = this.EntityName,
                EntityAction = this.EntityAction,

                EntityType = this.EntityType,
                EntityValue = this.EntityValue,

                EntityStatus = "Success",

                Date = this.Date,
                User = this.User
            };

            Trace.WriteLine(string.Format("EntityName: {0}, EntityAction: {1}", this.EntityName, this.EntityAction));
            Trace.WriteLine(string.Format("EntityValue: {0}, EntityType: {1}, Date: {2}, User: {3}", this.EntityValue, this.EntityType, Date.ToString(), User));
            Trace.WriteLine("---\n");

            HttpHelper.RunClient(bizMsgExDTO);
        }

        // This method is executed at runtime inside your application, when target methods exit with an exception
        public override void OnException(MethodExecutionArgs args)
        {
            // Trace.WriteLine(MethodName + " - OnException\n" + args.Exception.Message);

            var bizMsgExDTO = new BizMsgExDTO
            {
                EntityName = this.EntityName,
                EntityAction = this.EntityAction,

                EntityType = this.EntityType,
                EntityValue = this.EntityValue,

                EntityStatus =  "Error",
                EntityErrorMessage = args.Exception.Message,
                EntityStackTrace = args.Exception.StackTrace,

                Date = this.Date,
                User = this.User
            };

            Trace.WriteLine(string.Format("EntityName: {0}, EntityAction: {1}", this.EntityName, this.EntityAction));
            Trace.WriteLine(string.Format("EntityValue: {0}, EntityType: {1}, Date: {2}, User: {3}", this.EntityValue, this.EntityType, Date.ToString(), User));
            Trace.WriteLine("---\n");

            HttpHelper.RunClient(bizMsgExDTO);
        }
    }
}
