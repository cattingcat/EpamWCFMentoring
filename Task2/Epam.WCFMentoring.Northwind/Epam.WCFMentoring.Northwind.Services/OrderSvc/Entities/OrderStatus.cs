using System.Runtime.Serialization;

namespace Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities
{
    [DataContract]
    public enum OrderStatus
    {
        [EnumMember]
        New = 0,

        [EnumMember]
        InProgress,

        [EnumMember]
        Done
    }
}
