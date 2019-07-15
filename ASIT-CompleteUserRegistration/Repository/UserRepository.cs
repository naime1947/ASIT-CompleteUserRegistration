using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASIT_CompleteUserRegistration.DataAccess;
using ASIT_CompleteUserRegistration.Models;
using ASIT_CompleteUserRegistration.ViewModels;
using AutoMapper;
using Models.ViewModels;

namespace ASIT_CompleteUserRegistration.Repository
{
    public class UserRepository
    {
        public UserEditViewModel Registration()
        {
            var divRepo = new DivisionRepository();
            var disRepo = new DistrictRepository();

            var user = new UserEditViewModel();
            user.Divisions = divRepo.GetDivisions();
            user.Districts = disRepo.GetDistricts();

            return user;
        }

        public bool SaveUser(UserEditViewModel editUser)
        {
            var user = new User();
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.UserName = editUser.UserName;
            user.Email = editUser.Email;
            user.Gender = editUser.Gender;
            user.DistrictId = editUser.DistrictId;
            user.DivisionId = editUser.DivisionId;
            user.Mobile = editUser.Mobile;
            user.LastEducation = editUser.LastEducation;
            user.Occupation = editUser.Occupation;
            user.PresentAddress = editUser.PresentAddress;
            user.DoB = editUser.DoB;

            string sql = @"Insert into Users (FirstName, LastName, UserName, Email,Gender,DistrictId,
                            DivisionId,Mobile,LastEducation,Occupation,PresentAddress,DoB)
                            values(@FirstName,@LastName,@UserName,@Email,@Gender,@DistrictId,@DivisionId,
                            @Mobile,@LastEducation,@Occupation,@PresentAddress,@DoB);";


            int rowAffected = SqlDataAccess.SaveData(sql, user);

            if (rowAffected > 0)
                return true;

            return false;
        }

        public bool UpdateUser(int id, UserEditViewModel editUser)
        {
            var user = new User();
            user.UserId = id;
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.UserName = editUser.UserName;
            user.Email = editUser.Email;
            user.Gender = editUser.Gender;
            user.DistrictId = editUser.DistrictId;
            user.DivisionId = editUser.DivisionId;
            user.Mobile = editUser.Mobile;
            user.LastEducation = editUser.LastEducation;
            user.Occupation = editUser.Occupation;
            user.PresentAddress = editUser.PresentAddress;
            user.DoB = editUser.DoB;

            string sql =
                @"Update Users set FirstName = @FirstName, LastName=@LastName, UserName=@UserName, Email=@Email,Gender=@Gender,DistrictId=@DistrictId,
                            DivisionId=@DivisionId,Mobile=@Mobile,LastEducation=@LastEducation,Occupation=@Occupation,PresentAddress=@PresentAddress,DoB=@DoB 
                            WHERE Userid = @UserId";


            int rowAffected = SqlDataAccess.SaveData(sql, user);

            if (rowAffected > 0)
                return true;

            return false;
        }


        public List<UserDisplayViewModel> GetUsers()
        {
            string sqlGetUser = "Select * from Users";
            List<User> users = SqlDataAccess.LoadData<User>(sqlGetUser);

            List<UserDisplayViewModel> displayUsers = new List<UserDisplayViewModel>();
            var divRepo = new DivisionRepository();
            var disRepo = new DistrictRepository();
            foreach (var user in users)
            {
                var displayUser = new UserDisplayViewModel();
                displayUser.UserId = user.UserId;
                displayUser.FirstName = user.FirstName;
                displayUser.LastName = user.LastName;
                displayUser.UserName = user.UserName;
                displayUser.Email = user.Email;
                displayUser.Mobile = user.Mobile;
                displayUser.Gender = user.Gender;
                displayUser.Division = divRepo.GetDivision(user.DivisionId);
                displayUser.District = disRepo.GetDistrictsById(user.DistrictId);
                displayUser.LastEducation = user.LastEducation;
                displayUser.Occupation = user.Occupation;
                displayUser.DoB = user.DoB;
                displayUser.PresentAddress = user.PresentAddress;

                displayUsers.Add(displayUser);
            }

            return displayUsers;
        }
        public UserEditViewModel GetUser(int id)
        {
            UserEditViewModel user = new UserEditViewModel();
            string sql = "Select * from users where userid = " + id;
            var users = SqlDataAccess.LoadData<UserEditViewModel>(sql);
            if (users.Count > 0)
                user = users[0];

            var divRepo = new DivisionRepository();
            var disRepo = new DistrictRepository();
            user.Divisions = divRepo.GetDivisions();
            user.Districts = disRepo.GetDistricts(user.DivisionId);

            return user;
        }

        public void DeleteUser(int id)
        {
            string sql = "Delete from users where userid = " + id;
            SqlDataAccess.DeleteData(sql);
        }


        public List<UserDisplayViewModel> SearchUsersByName(string name)
        {
            string sqlGetUser = "Select * from Users where Firstname like "+"\'%"+name+"%\'";
            List<User> users = SqlDataAccess.LoadData<User>(sqlGetUser);

            List<UserDisplayViewModel> displayUsers = new List<UserDisplayViewModel>();
            var divRepo = new DivisionRepository();
            var disRepo = new DistrictRepository();
            foreach (var user in users)
            {
                var displayUser = new UserDisplayViewModel();
                displayUser.UserId = user.UserId;
                displayUser.FirstName = user.FirstName;
                displayUser.LastName = user.LastName;
                displayUser.UserName = user.UserName;
                displayUser.Email = user.Email;
                displayUser.Mobile = user.Mobile;
                displayUser.Gender = user.Gender;
                displayUser.Division = divRepo.GetDivision(user.DivisionId);
                displayUser.District = disRepo.GetDistrictsById(user.DistrictId);
                displayUser.LastEducation = user.LastEducation;
                displayUser.Occupation = user.Occupation;
                displayUser.DoB = user.DoB;
                displayUser.PresentAddress = user.PresentAddress;

                displayUsers.Add(displayUser);
            }

            return displayUsers;
        }
    }
}