using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.ResponseHandling
{
    public class ErrorResponseValidation : CustomException
    {
        public ErrorResponseValidation() : base(500)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
