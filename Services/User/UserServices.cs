using Hiper.Commerce.Api.Models.ViewModels;
using Hiper.Commerce.Api.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Hiper.Commerce.Api.Services.User
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Models.User> GetUserDataAsync(string email, string passWord)
        {
            var usersModel = new Models.User()
            {
                Email = email,
                Password = passWord
            };

            var user = await ValidateUserAsync(usersModel);
            return user;
        }

        public async Task<UsersListModel> GetUsersAsync()
        {
            var allUsers = new UsersListModel()
            {
                Users = await _userRepository.GetUsersAsync(),
            };

            return allUsers;            
        }
          
        public async Task<Models.User> DeleteUserByIdAsync(int id)
        {
            var getUser = await _userRepository.GetUserByIdAsync(id);
            if (getUser is null)
            {
                var userError = new Models.User();
                userError.AddError("Usuário não encontrado na base de dados.");
                return userError;
            }

            getUser.Excluded = true;

            var userDeleted = await _userRepository.UpdateUserAsync(getUser);
            return userDeleted;
        }

        public async Task<Models.User> UpdateUserAsync(Models.User userModel)
        {
            ValidateEmailAndPasswordNullOrWhiteSpace(userModel);
            if (userModel.HasErrors())
                return userModel;

            var getUserDatabase = await _userRepository.GetUserByIdAsync(userModel.Id);
            if (getUserDatabase is null)
            {
                userModel.AddError("Usuário não encontrado na base de dados.");
                return userModel;
            }

            var userUpdated = await _userRepository.UpdateUserAsync(HandleUser(getUserDatabase, userModel));
            return userUpdated;
        }

        public async Task<Models.User> SetUserAsync(Models.User user)
        {
            ValidateEmailAndPasswordNullOrWhiteSpace(user);
            await ValidateEmailRepeatedAsync(user);
            if (user.HasErrors())
                return user;

            var userCreated = await _userRepository.SetUserAsync(user);
            return userCreated;
        }

        public async Task<Models.User> ValidateUserAsync(Models.User usersModel)
        {
            ValidateEmailAndPasswordNullOrWhiteSpace(usersModel);
            if (usersModel.HasErrors())
                return usersModel;

            var user = await _userRepository.GetUserByEmailAsync(usersModel.Email);
            if (user is null)
            {
                usersModel.AddError("E-mail não encontrado na base de usuários.");
                return usersModel;
            }

            if (usersModel.Password != user.Password)
            {
                usersModel.AddError("A senha informada é inválida.");
                return usersModel;
            }

            return user;
        }

        public void ValidateEmailAndPasswordNullOrWhiteSpace(Models.User userModel)
        {
            if (string.IsNullOrWhiteSpace(userModel.Email) || string.IsNullOrWhiteSpace(userModel.Password))
                userModel.AddError("E-mail e senha são obrigatórios.");            
        }

        public async Task ValidateEmailRepeatedAsync(Models.User usersModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(usersModel.Email);
            if (user is not null)        
                usersModel.AddError("Este e-mail já está cadastrado.");            
        }
        
        public Models.User HandleUser(Models.User userDatabase, Models.User userModel)
        {
            userDatabase.Name = userModel.Name;
            userDatabase.Email = userModel.Email;
            userDatabase.Password = userModel.Password;

            return userDatabase;
        }
    }
}
