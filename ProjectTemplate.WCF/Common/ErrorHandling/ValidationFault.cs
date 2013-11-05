using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ProjectTemplate.Domain.Common;
using System.Linq;

namespace ProjectTemplate.WCF.Common.ErrorHandling
{
    [DataContract]
    public class ValidationFault
    {
        private List<ValidationFaultMessage> _messages;

        public ValidationFault(ValidationMessageCollection validationMessages)
        {
            _messages = new List<ValidationFaultMessage>();

            foreach(ValidationMessage validationMessage in validationMessages)
            {
                _messages.Add(new ValidationFaultMessage()
                {
                    Field = validationMessage.Field,
                    Text = validationMessage.Text
                });
            }
        }

        [DataMember]
        public List<ValidationFaultMessage> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        [DataMember]
        public string Summary
        {
            get
            {
                StringBuilder combinedMessage = new StringBuilder("The following validation errors occured: ");

                foreach (ValidationFaultMessage message in _messages)
                {
                    if (message != _messages.First()) combinedMessage.Append(", ");
                    combinedMessage.Append(message.Text);
                }

                return combinedMessage.ToString();
            }
            set { }
        }
    }
}
