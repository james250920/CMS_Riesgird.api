using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers
{
    [Route("api/v1/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(new ApiResponse<IEnumerable<RoleResponseDto>>(roles, true, "Lista de roles."));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
                return NotFound(new ApiResponse<object>(false, "Rol no encontrado."));
            return Ok(new ApiResponse<RoleResponseDto>(role, true, "Rol encontrado."));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Name))
            {
                return BadRequest(new ApiResponse<object>(false, "El nombre del rol es requerido."));
            }
            try
            {
                var roleId = await _roleService.CreateRole(dto);
                return Ok(new ApiResponse<object>(new { RoleId = roleId }, true, "Rol creado correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRoleDto dto)
        {
            if (dto == null || id != dto.Id)
            {
                return BadRequest(new ApiResponse<object>(false, "Id del rol no coincide con el Id en el cuerpo de la solicitud."));
            }
            try
            {
                await _roleService.UpdateRole(id, dto);
                return Ok(new ApiResponse<object>(true, "Rol actualizado correctamente."));
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
                await _roleService.DeleteRole(id);
                return Ok(new ApiResponse<object>(true, "Rol eliminado correctamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(false, ex.Message));
            }
        }
    }
}
