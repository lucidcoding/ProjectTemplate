using System.Runtime.Serialization;

namespace ProjectTemplate.WCF.Common.ErrorHandling
{
    [DataContract]
    public class ApplicationFault
    {
        protected string _errorCode;

        public ApplicationFault(string errorCode)
        {
            _errorCode = errorCode;
        }

        [DataMember]
        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
}
