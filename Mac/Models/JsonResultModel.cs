using System.Linq;
using System.Collections.Generic;

namespace Mac.Models
{
    public class JsonResultModel
    {
        public object Collection { get; set; }
        
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
