using CallForPappersService_DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CallForPappersService_BAL.Dto
{
    public class ApplicationSubmitDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Outline { get; set; } = null!;
    }
}
