using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Sum(int a, int b);

        [OperationContract]
        int Diff(int a, int b);

        [OperationContract]
        int Mul(int a, int b);

        [OperationContract]
        int Div(int a, int b);
    }
}
