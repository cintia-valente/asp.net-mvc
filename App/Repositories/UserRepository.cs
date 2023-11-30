﻿using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;

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
            return _databaseContext.Users.ToList();
        }
        public UserModel Create(UserModel user)
        {
            user.RegistrationDate = DateTime.UtcNow;
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();

            return user; 
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
            userModel.UpdateDate = DateTime.Now;
        
            _databaseContext.Users.Update(userModel);
            _databaseContext.SaveChanges();

            return userModel;
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
