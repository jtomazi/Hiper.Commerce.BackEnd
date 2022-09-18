using Hiper.Commerce.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Hiper.Commerce.Api.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        protected readonly HiperCommerceContext _context;

        public UserRepository(HiperCommerceContext context)
        {
            _context = context;
        }

        public async Task<Models.User> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _context
                    .Users
                    .FirstOrDefaultAsync(x => x.Email == email && !x.Excluded);
            }
            catch (Exception ex)
            {
                var user = new Models.User();
                user.AddError($"Houve um erro ao buscar o usuário na base de dados. Mensagem original do erro: {ex.Message}");

                return user;
            }
        }

        public async Task<Models.User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context
                    .Users
                    .FirstOrDefaultAsync(x => x.Id == id && !x.Excluded);
            }
            catch (Exception ex)
            {
                var user = new Models.User();
                user.AddError($"Houve um erro ao buscar o usuário na base de dados. Mensagem original do erro: {ex.Message}");

                return user;
            }
        }

        public async Task<List<Models.User>> GetUsersAsync()
        {
            var users = new List<Models.User>();
            try
            {
                users = await _context
                    .Users
                    .AsNoTracking()
                    .Where(u => !u.Excluded)
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                users.FirstOrDefault().AddError($"Houve um erro ao buscar os usuários na base de dados. Mensagem original do erro: {ex.Message}");
                return users;
            }
        }

        public async Task<Models.User> UpdateUserAsync(Models.User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                user.AddError($"Houve um erro ao atualizar o usuário na base de dados. Mensagem original do erro: {ex.Message}");
                return user;
            }
        }

        public async Task<Models.User> SetUserAsync(Models.User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                user.AddError($"Houve um erro na criação de usuário na base de dados. Mensagem original do erro: {ex.Message}");
                return user;
            }
        }
    }
}
