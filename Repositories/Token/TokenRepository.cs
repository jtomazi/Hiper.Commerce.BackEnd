using Hiper.Commerce.Api.Data;
using Hiper.Commerce.Api.Models;
using System;
using System.Threading.Tasks;

namespace Hiper.Commerce.Api.Repositories.Token
{
    public class TokenRepository : ITokenRepository
    {

        protected readonly HiperCommerceContext _context;

        public TokenRepository(HiperCommerceContext context)
        {
            _context = context;
        }

        public async Task<AccessControlHistory> SetHistory(AccessControlHistory accessControlHistory)
        {
            try
            {
                await _context.AccessControlHistories.AddAsync(accessControlHistory);
                await _context.SaveChangesAsync();
                return accessControlHistory;
            }
            catch (Exception ex)
            {
                accessControlHistory.AddError(ex.Message);
                return accessControlHistory;
            }

        }
    }
}
