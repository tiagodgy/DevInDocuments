using DevInDocuments.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Exceptions
{
    [Serializable]
    public class UserNotFoundException: Exception
    {
        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException) { }

}
}
