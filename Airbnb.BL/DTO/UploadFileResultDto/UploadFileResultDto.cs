using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.BL
{
    public class UploadFileResultDto
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public string URL { get; set; } = string.Empty;

        public UploadFileResultDto( bool isSuccess , string message , string url  )
        {
            IsSuccess = isSuccess;
            Message = message;
            URL = url;

        }

    }
}
