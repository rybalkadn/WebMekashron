using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMekashron.Models
{

    public class LoginResponse : CustomerInfoResponse
    {

        public int EntityId { get; set; }

        public int Status { get; set; }

    }
}