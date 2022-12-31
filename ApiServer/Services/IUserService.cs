using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IUserService
    {
        public Task<ApiResponse> Login(User user);
        public Task<ApiResponse> CreateUser(User user);
        public Task<ApiResponse> DeleteUser(int id);
        public Task<ApiResponse> EditUser(int id,User user);
    }
}