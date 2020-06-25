using graphql.poc.core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.poc.server.Helper
{
    public class ContextHelper
    {
        public ITeamRepository TeamRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ITeamRepository>();
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
