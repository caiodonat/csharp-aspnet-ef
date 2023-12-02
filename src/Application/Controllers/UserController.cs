using CAE.Domain.DTOs;
using CAE.Domain.Entities;
using CAE.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http.Headers;
// using FluentValidation.Results;
// using CAE.Domain.DTOs;
// using Microsoft.AspNetCore.Http.HttpResults;
// using CAE.Domain.Validators;

namespace CAE.Application.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
	private readonly IUserService _service;
	// private readonly ExceptionValidator _errorHandle;

	public UserController(
		IUserService userService
	)
	{
		_service = userService;
		// _errorHandle = new ExceptionValidator();
	}

	[HttpGet("</")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public IActionResult RedirectToDocs()
	{
		return Redirect("/swagger");
	}

	[HttpPost("")]
	[ProducesResponseType(201, Type = typeof(User))]
	public async Task<IActionResult> PostUser(
		[FromBody] CreateUserDTO newUser
	)
	{
		try
		{
			return Ok(await _service.Create(newUser));

		}
		catch (Exception error)
		{
			Console.WriteLine(error);
			return StatusCode(
				// _errorHandle.HResultToStatusCodes(error.HResult),
				503,
				new[] { error.Message }
			);
		}
	}

	[HttpGet("all")]
	[ProducesResponseType(200, Type = typeof(User[]))]
	public async Task<IActionResult> GetAllUser(
	)
	{
		try
		{
			return Ok(await _service.FindAll());
		}
		catch (Exception error)
		{
			return StatusCode(
				503,
				new[] { error.Message }
			);
		}
	}

	[HttpGet("{id}")]
	[ProducesResponseType(200, Type = typeof(User))]
	public async Task<IActionResult> GetUserById(
		[FromRoute] int id
	)
	{
		try
		{
			return Ok(await _service.FindById(id));
		}
		catch (Exception error)
		{
			return StatusCode(
				503,
				new[] { error.Message }
			);
		}
	}

	[HttpPut("{id}")]
	[ProducesResponseType(201, Type = typeof(User))]
	public async Task<IActionResult> UpdateUser(
		[FromRoute] int id,
		[FromBody] CreateUserDTO newUserData
	)
	{
		try
		{
			User measureDTOUpdate = newUserData;
			measureDTOUpdate.Id = id;

			await _service.Change(newUserData);

			return CreatedAtAction(
				nameof(GetUserById), new { id = measureDTOUpdate.Id }, newUserData
			);
		}
		catch (Exception error)
		{
			return StatusCode(
				503,
				new[] { error.Message }
			);
		}
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(204)]
	public async Task<IActionResult> DeleteUser(
		[FromRoute] int id
	)
	{
		try
		{
			await _service.RemoveById(id);
			return NoContent();
		}
		catch (Exception error)
		{
			return StatusCode(
				503,
				new[] { error.Message }
			);
		}
	}

}
