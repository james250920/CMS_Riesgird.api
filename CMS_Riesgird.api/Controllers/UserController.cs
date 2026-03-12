using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                return BadRequest(new ApiResponse<object>(false, "Debe ingresar email y contraseña."));
            }
            var result = await _userService.Login(dto);
            if (result == null)
            {
                return Unauthorized(new ApiResponse<object>(false, "Email o contraseña inválida."));
            }
            return Ok(new ApiResponse<UserLoginResponseDto>(result, true, "Inicio de sesión exitoso."));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.PasswordHash) || string.IsNullOrEmpty(dto.FullName))
            {
                return BadRequest(new ApiResponse<object>(false, "Email, contraseña y nombre completo son requeridos."));
            }
            try
            {
                var userId = await _userService.Register(dto);
                return Ok(new ApiResponse<object>(new { UserId = userId }, true, "Usuario registrado correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound(new ApiResponse<object>(false, "Usuario no encontrado."));
            return Ok(new ApiResponse<UserResponseDto>(user, true, "Usuario encontrado."));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsers();
            return Ok(new ApiResponse<IEnumerable<UserResponseDto>>(users, true, "Lista de usuarios."));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest(new ApiResponse<object>(false, "Id del usuario no coincide con el Id en el cuerpo de la solicitud."));
            }
            try
            {
                await _userService.UpdateUser(id, dto);
                return Ok(new ApiResponse<object>(true, "Usuario actualizado correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok(new ApiResponse<object>(true, "Usuario eliminado correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }
    }
}
