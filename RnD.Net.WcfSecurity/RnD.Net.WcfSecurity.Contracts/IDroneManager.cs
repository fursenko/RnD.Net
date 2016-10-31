
namespace RnD.Net.WcfSecurity.Contracts
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IDroneManager
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        void KillSelf();

        [OperationContract]
        string GetInfo();
    }
}
