using CAE.Domain.DTOs;
using CAE.Domain.Entities;
using CAE.Domain.Interfaces;
using CAE.Infrastructure.Interfaces;

namespace CAE.Domain.Service;

class UserService : IUserService
{
	private readonly IUserRepository _repository;

	public UserService(
		IUserRepository userRepository
	)
	{
		_repository = userRepository;
	}

	public async Task<User> Create(CreateUserDTO newUser)
	{
		return await _repository.Create(newUser);
	}
	
	public async Task<User> FindById(int id)
	{
		return await _repository.SelectById(id);
	}

	public async Task<List<User>> FindAll()
	{
		return await _repository.SelectAll();
	}

	public async Task Change(CreateUserDTO newUserData)
	{
	// 	ValidationResult result = _validator.Validate(newUserData);

	// 	if (!result.IsValid)
	// 	{
	// 		throw new Exception(
	// 			result.ToString("\n")
	// 		)
	// 		{ HResult = 400 };
	// 	}

		await _repository.Update(newUserData);
	}

	public async Task RemoveById(int id)
	{
		try
		{
			await _repository.DeleteById(id);
		}
		catch (Exception)
		{
			throw;
		}
	}

}
