
using CrudApi.Models;
using CrudApi.Configurations;
using Microsoft.Extensions.Options;

namespace CrudApi.Services;
public class UsersService
{
    public async Task<List<User>> GetUsersAsync()=> await Users.Find(_=>true)
}