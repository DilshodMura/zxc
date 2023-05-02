using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO_models
{
    public sealed class JwtTokensDTO : IJwtTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
