// using CAE.Domain.DTOs;
using CAE.Domain.Entities;

namespace CAE.Infrastructure.Interfaces;

public interface IUserRepository
{
	public Task<User> Create(User user);
	public Task<User> SelectById(int id);
	public Task<List<User>> SelectAll();
	public Task Update(User user);
	public Task DeleteById(int id);
}
