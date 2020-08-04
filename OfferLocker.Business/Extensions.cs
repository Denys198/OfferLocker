using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfferLocker.Business
{
    public class Extensions
    {
        private IHttpContextAccessor _httpContextAccessor;

        public Extensions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLoggedUserId()
        {
            var result = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId").Value;
            return result;
        }
    }
}
