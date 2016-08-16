using System.Net;
using System.Web;
using UnibenWeb.Infra.CrossCutting.Log.Context;
using UnibenWeb.Infra.Data.Interfaces;

namespace UnibenWeb.Infra.Data.Context
{
    public class ContextManager: IContextManager
    {

        private const string ContextKey = "ContextManager.Context";
        private const string ContextLogKey = "ContextManager.ContextLog";

        public UnibenContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new UnibenContext();
                
            }

            return (UnibenContext) HttpContext.Current.Items[ContextKey];
        }

        public UnibenLogContext GetContextLog()
        {
            if (HttpContext.Current.Items[ContextLogKey] == null)
            {
                HttpContext.Current.Items[ContextLogKey] = new UnibenLogContext();

            }

            return (UnibenLogContext)HttpContext.Current.Items[ContextLogKey];
        }



    }
}