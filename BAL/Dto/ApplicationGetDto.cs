using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallForPappersService_BAL.Dto
{
    public class ApplicationGetDto
    {
        public DateTime? SubmittedAfter { get; set; }
        public DateTime? UnsubmittedOlder { get; set; }
    }
}
