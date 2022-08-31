using System.Collections.Generic;

namespace Skinet_API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(401)
        {

        }

        public IEnumerable<char> Errors { get; set; }
    }
}
