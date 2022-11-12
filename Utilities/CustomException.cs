using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace Utilities
{
    public class CustomException:Exception
    {
        public int ErrorCode { private set; get; }
        public CustomException(ErrorCodeEnum errorCode):base(errorCode.ToString())
        {
            this.ErrorCode = (int)ErrorCode;
        }
    }
}
