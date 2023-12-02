using CAE.Domain.Entities;
using CAE.Infrastructure.Database;
using CAE.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;
// using CAE.Domain.DTOs;

namespace CAE.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly AppDbContext _dbContext;

	public UserRepository(AppDbContext sqlContext)
	{
		_dbContext = sqlContext;
	}

	public async Task<User> Create(User newUser)
	{
		User newUserDb = _dbContext.Users
			.Add(newUser).Entity;

		await _dbContext.SaveChangesAsync();

		if (newUserDb.Id == null)
		{
			throw new Exception(
				"Falha ao resgatar registro recém criado"
			)
			{ HResult = 500 };
		}

		return newUserDb;
	}

	public async Task<User> SelectById(int id)
	{
		try
		{
			return await _dbContext.Users
				.SingleAsync(et => et.Id == id);
		}
		catch (Exception error)
		{
			switch (error)
			{
				case System.InvalidOperationException:
					{
						throw new Exception(
							$"'Usuário' com 'Id':'{id}' não foi encontrado"
						)
						{ HResult = 422 };
					}
				default:
					{
						error.HResult = 500;
						throw;
					}
			}
		}
	}

	public async Task<List<User>> SelectAll()
	{
		try
		{
			return await _dbContext.Users
			.ToListAsync();
		}
		catch (Exception error)
		{
			switch (error)
			{
				default:
					{
						error.HResult = 500;
						throw;
					}
			}
		}
	}

	public async Task Update(/* int userId,  */User newUserData)
	{
		try
		{
			User UpdatedUser = _dbContext.Users
				.First(et => et.Id.Equals(newUserData.Id));
				
			UpdatedUser = newUserData;
			_dbContext.Users.Update(UpdatedUser);

			await _dbContext.SaveChangesAsync();
		}
		catch (Exception error)
		{
			switch (error)
			{
				case System.InvalidOperationException:
					{
						throw new Exception(
							$"'Usuário' não foi encontrado"
						)
						{ HResult = 422 };
					}
				default:
					{
						throw new Exception("Falha relacionada ao banco de dados")
						{ HResult = 500 };
					}
			}
		}
	}

	public async Task DeleteById(int id)
	{
		try
		{
			User targetUser = await _dbContext.Users
				.SingleAsync(et => et.Id == id);

			User DeletedUser = _dbContext.Users
				.Attach(targetUser).Entity;

			_dbContext.Users.Remove(DeletedUser);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception error)
		{
			switch (error)
			{
				case System.InvalidOperationException:
					{
						throw new Exception($"'Usuário' com 'Id':'{id}' não foi encontrado")
						{ HResult = 422 };
					}
				default:
					{
						error.HResult = 500;
						throw;
					}
			}
		}
	}

}
