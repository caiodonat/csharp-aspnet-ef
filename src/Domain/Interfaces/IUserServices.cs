// using CAE.Domain.DTOs;
using CAE.Domain.DTOs;
using CAE.Domain.Entities;

namespace CAE.Domain.Interfaces;

public interface IUserService
{
	public Task<User> Create(CreateUserDTO user);
	public Task<User> FindById(int id);
	public Task<List<User>> FindAll();
	public Task Change(CreateUserDTO user);
	public Task RemoveById(int id);
}
