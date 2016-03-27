using System.ServiceModel;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc
{
    [ServiceContract(SessionMode=SessionMode.Required, CallbackContract=typeof(IStatusChangeCallback))]
    public interface IPubSubService
    {
        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();
    }
}
