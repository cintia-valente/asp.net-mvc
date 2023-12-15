using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public List<UserModel> GetAll()
        {
            return _databaseContext.Users
                .Include(x => x.Contacts)
                .ToList();
        }
        public UserModel Create(UserModel user)
        {
            user.RegistrationDate = DateTime.UtcNow;
            user.SetPasswordHash();
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

            return user; 
        }

        public UserModel GetForLogin(string login)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel GetForEmailAndLogin(string email, string login)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel GetForId(int id)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.IdUser == id);
        }

        public UserModel Update(UserModel user)
        {
            UserModel userModel = GetForId(user.IdUser);

            if (userModel == null) throw new System.Exception("Erro ao atualizar!");

            userModel.Name = user.Name;
            userModel.Email= user.Email;
            userModel.Login = user.Login;
            userModel.Profile = user.Profile;
            userModel.RegistrationDate = DateTime.UtcNow;
            userModel.UpdateDate = DateTime.UtcNow;
        
            _databaseContext.Users.Update(userModel);
            _databaseContext.SaveChanges();

            return userModel;
        }

        public UserModel UpdatePassword(UpdatePasswordModel updatePasswordModel)
        {
            UserModel userDb = GetForId(updatePasswordModel.Id);

            userDb.SetPasswordHash();

            if (userDb == null) throw new Exception("Erro ao atualizar a senha, usuário não encontrado!");

            if(userDb.PasswordValid(updatePasswordModel.CurrentPassword)) throw new Exception("Senha inválida!");

            if (userDb.PasswordValid(updatePasswordModel.NewPassword)) throw new Exception("Nova senha deve ser diferente da senha atual.");

            userDb.SetNewPasswordHash(updatePasswordModel.NewPassword);
            userDb.UpdateDate = DateTime.UtcNow;

            _databaseContext.Users.Update(userDb);
            _databaseContext.SaveChanges();

            return userDb;
        }

        public bool Delete(int id)
        {
            UserModel userModel = GetForId(id);

            if (userModel == null) throw new System.Exception("Erro ao apagar!");

            _databaseContext.Users.Remove(userModel);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
