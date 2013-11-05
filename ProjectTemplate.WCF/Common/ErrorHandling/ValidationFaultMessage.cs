using System.Runtime.Serialization;

namespace ProjectTemplate.WCF.Common.ErrorHandling
{
    [DataContract]
    public class ValidationFaultMessage
    {
        [DataMember]
        public string Field { get; set; }

        [DataMember]
        public string Text { get; set; }
    }
}
