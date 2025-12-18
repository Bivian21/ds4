using MatriculaEscolarIPTC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaEscolarIPTC.Controllers;

[Authorize]
public class PdfController : Controller
{
    private readonly PdfService _pdf;
    public PdfController(PdfService pdf) => _pdf = pdf;

    [Authorize(Roles = "Admin,Secretaria")]
    public async Task<IActionResult> Comprobante(int id)
    {
        var bytes = await _pdf.ComprobanteMatriculaAsync(id);
        return File(bytes, "application/pdf", $"ComprobanteMatricula_{id}.pdf");
    }

    [Authorize(Roles = "Admin,Secretaria")]
    public async Task<IActionResult> HistorialSimple(int estudianteId)
    {
        var bytes = await _pdf.HistorialSimpleAsync(estudianteId);
        return File(bytes, "application/pdf", $"Historial_{estudianteId}.pdf");
    }
}
