using CMS_Riesgird.Core.Core.DTOs;
using CMS_Riesgird.Core.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Riesgird.api.Controllers;

[Route("api/v1/event-photos")]
[ApiController]
public class EventPhotoController : ControllerBase
{
    private readonly IEventPhotoService _service;

    public EventPhotoController(IEventPhotoService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<EventPhotoResponseDto>>(await _service.GetAllPhotos(), true, "Lista de fotos."));
    [HttpGet("public")] public async Task<IActionResult> GetPublic() => Ok(new ApiResponse<IEnumerable<EventPhotoResponseDto>>(await _service.GetPublicPhotos(), true, "Fotos públicas."));
    [HttpGet("featured")] public async Task<IActionResult> GetFeatured() => Ok(new ApiResponse<IEnumerable<EventPhotoResponseDto>>(await _service.GetFeaturedPhotos(), true, "Fotos destacadas."));
    [HttpGet("event/{eventId}")] public async Task<IActionResult> GetByEventId(Guid eventId) => Ok(new ApiResponse<IEnumerable<EventPhotoResponseDto>>(await _service.GetPhotosByEventId(eventId), true, "Fotos del evento."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id)
    {
        var photo = await _service.GetPhotoById(id);
        return photo == null ? NotFound(new ApiResponse<object>(false, "Foto no encontrada.")) : Ok(new ApiResponse<EventPhotoResponseDto>(photo, true, "Foto encontrada."));
    }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateEventPhotoDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Url)) return BadRequest(new ApiResponse<object>(false, "La URL es requerida."));
        try
        {
            var id = await _service.CreatePhoto(dto);
            return Ok(new ApiResponse<object>(new { PhotoId = id }, true, "Foto creada."));
        }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventPhotoDto dto)
    {
        if (dto == null || id != dto.Id || string.IsNullOrEmpty(dto.Url)) return BadRequest(new ApiResponse<object>(false, "Datos inválidos."));
        try { await _service.UpdatePhoto(id, dto); return Ok(new ApiResponse<object>(true, "Foto actualizada.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id)
    {
        try { await _service.DeletePhoto(id); return Ok(new ApiResponse<object>(true, "Foto eliminada.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
}

[Route("api/v1/institutional-contents")]
[ApiController]
public class InstitutionalContentController : ControllerBase
{
    private readonly IInstitutionalContentService _service;

    public InstitutionalContentController(IInstitutionalContentService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<InstitutionalContentResponseDto>>(await _service.GetAllContents(), true, "Lista de contenidos."));
    [HttpGet("public")] public async Task<IActionResult> GetPublic() => Ok(new ApiResponse<IEnumerable<InstitutionalContentResponseDto>>(await _service.GetPublicContents(), true, "Contenidos públicos."));
    [HttpGet("title/{title}")] public async Task<IActionResult> GetByTitle(string title)
    {
        var content = await _service.GetContentByTitle(title);
        return content == null ? NotFound(new ApiResponse<object>(false, "Contenido no encontrado.")) : Ok(new ApiResponse<InstitutionalContentResponseDto>(content, true, "Contenido encontrado."));
    }
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id)
    {
        var content = await _service.GetContentById(id);
        return content == null ? NotFound(new ApiResponse<object>(false, "Contenido no encontrado.")) : Ok(new ApiResponse<InstitutionalContentResponseDto>(content, true, "Contenido encontrado."));
    }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateInstitutionalContentDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Title) || string.IsNullOrEmpty(dto.Content)) return BadRequest(new ApiResponse<object>(false, "Título y contenido requeridos."));
        try
        {
            var id = await _service.CreateContent(dto);
            return Ok(new ApiResponse<object>(new { ContentId = id }, true, "Contenido creado."));
        }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInstitutionalContentDto dto)
    {
        if (dto == null || id != dto.Id) return BadRequest(new ApiResponse<object>(false, "Datos inválidos."));
        try { await _service.UpdateContent(id, dto); return Ok(new ApiResponse<object>(true, "Contenido actualizado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id)
    {
        try { await _service.DeleteContent(id); return Ok(new ApiResponse<object>(true, "Contenido eliminado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
}

[Route("api/v1/normative-documents")]
[ApiController]
public class NormativeDocumentController : ControllerBase
{
    private readonly INormativeDocumentService _service;

    public NormativeDocumentController(INormativeDocumentService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<NormativeDocumentResponseDto>>(await _service.GetAllDocuments(), true, "Lista de documentos."));
    [HttpGet("active")] public async Task<IActionResult> GetActive() => Ok(new ApiResponse<IEnumerable<NormativeDocumentResponseDto>>(await _service.GetActiveDocuments(), true, "Documentos activos."));
    [HttpGet("public")] public async Task<IActionResult> GetPublic() => Ok(new ApiResponse<IEnumerable<NormativeDocumentResponseDto>>(await _service.GetPublicDocuments(), true, "Documentos públicos."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id)
    {
        var doc = await _service.GetDocumentById(id);
        return doc == null ? NotFound(new ApiResponse<object>(false, "Documento no encontrado.")) : Ok(new ApiResponse<NormativeDocumentResponseDto>(doc, true, "Documento encontrado."));
    }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateNormativeDocumentDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name)) return BadRequest(new ApiResponse<object>(false, "Nombre requerido."));
        try
        {
            var id = await _service.CreateDocument(dto);
            return Ok(new ApiResponse<object>(new { DocumentId = id }, true, "Documento creado."));
        }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNormativeDocumentDto dto)
    {
        if (dto == null || id != dto.Id) return BadRequest(new ApiResponse<object>(false, "Datos inválidos."));
        try { await _service.UpdateDocument(id, dto); return Ok(new ApiResponse<object>(true, "Documento actualizado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id)
    {
        try { await _service.DeleteDocument(id); return Ok(new ApiResponse<object>(true, "Documento eliminado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
}

[Route("api/v1/application-documents")]
[ApiController]
public class ApplicationDocumentController : ControllerBase
{
    private readonly IApplicationDocumentService _service;

    public ApplicationDocumentController(IApplicationDocumentService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<ApplicationDocumentResponseDto>>(await _service.GetAllDocuments(), true, "Lista de documentos."));
    [HttpGet("valid")] public async Task<IActionResult> GetValid() => Ok(new ApiResponse<IEnumerable<ApplicationDocumentResponseDto>>(await _service.GetValidDocuments(), true, "Documentos válidos."));
    [HttpGet("application/{applicationId}")] public async Task<IActionResult> GetByApplicationId(Guid applicationId) => Ok(new ApiResponse<IEnumerable<ApplicationDocumentResponseDto>>(await _service.GetDocumentsByApplicationId(applicationId), true, "Documentos de solicitud."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id)
    {
        var doc = await _service.GetDocumentById(id);
        return doc == null ? NotFound(new ApiResponse<object>(false, "Documento no encontrado.")) : Ok(new ApiResponse<ApplicationDocumentResponseDto>(doc, true, "Documento encontrado."));
    }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateApplicationDocumentDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.Name)) return BadRequest(new ApiResponse<object>(false, "Nombre requerido."));
        try
        {
            var id = await _service.CreateDocument(dto);
            return Ok(new ApiResponse<object>(new { DocumentId = id }, true, "Documento creado."));
        }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateApplicationDocumentDto dto)
    {
        if (dto == null || id != dto.Id) return BadRequest(new ApiResponse<object>(false, "Datos inválidos."));
        try { await _service.UpdateDocument(id, dto); return Ok(new ApiResponse<object>(true, "Documento actualizado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id)
    {
        try { await _service.DeleteDocument(id); return Ok(new ApiResponse<object>(true, "Documento eliminado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
}

[Route("api/v1/membership-certificates")]
[ApiController]
public class MembershipCertificateController : ControllerBase
{
    private readonly IMembershipCertificateService _service;

    public MembershipCertificateController(IMembershipCertificateService service) => _service = service;

    [HttpGet] public async Task<IActionResult> GetAll() => Ok(new ApiResponse<IEnumerable<MembershipCertificateResponseDto>>(await _service.GetAllCertificates(), true, "Lista de certificados."));
    [HttpGet("valid")] public async Task<IActionResult> GetValid() => Ok(new ApiResponse<IEnumerable<MembershipCertificateResponseDto>>(await _service.GetValidCertificates(), true, "Certificados válidos."));
    [HttpGet("expired")] public async Task<IActionResult> GetExpired() => Ok(new ApiResponse<IEnumerable<MembershipCertificateResponseDto>>(await _service.GetExpiredCertificates(), true, "Certificados vencidos."));
    [HttpGet("university/{universityId}")] public async Task<IActionResult> GetByUniversityId(Guid universityId) => Ok(new ApiResponse<IEnumerable<MembershipCertificateResponseDto>>(await _service.GetCertificatesByUniversityId(universityId), true, "Certificados de la universidad."));
    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id)
    {
        var cert = await _service.GetCertificateById(id);
        return cert == null ? NotFound(new ApiResponse<object>(false, "Certificado no encontrado.")) : Ok(new ApiResponse<MembershipCertificateResponseDto>(cert, true, "Certificado encontrado."));
    }
    [HttpPost] public async Task<IActionResult> Create([FromBody] CreateMembershipCertificateDto dto)
    {
        if (dto == null || string.IsNullOrEmpty(dto.UniversityName)) return BadRequest(new ApiResponse<object>(false, "Nombre requerido."));
        try
        {
            var id = await _service.CreateCertificate(dto);
            return Ok(new ApiResponse<object>(new { CertificateId = id }, true, "Certificado creado."));
        }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpPatch("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMembershipCertificateDto dto)
    {
        if (dto == null || id != dto.Id) return BadRequest(new ApiResponse<object>(false, "Datos inválidos."));
        try { await _service.UpdateCertificate(id, dto); return Ok(new ApiResponse<object>(true, "Certificado actualizado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id)
    {
        try { await _service.DeleteCertificate(id); return Ok(new ApiResponse<object>(true, "Certificado eliminado.")); }
        catch (Exception ex) { return BadRequest(new ApiResponse<object>(false, ex.Message)); }
    }
}
