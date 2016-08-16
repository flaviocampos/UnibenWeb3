using UnibenWeb.Infra.Data.Context;

namespace UnibenWeb.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        UnibenContext GetContext();
    }
}