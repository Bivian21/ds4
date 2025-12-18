using MatriculaEscolarIPTC.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MatriculaEscolarIPTC.Services;

public class PdfService
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public PdfService(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public async Task<byte[]> ComprobanteMatriculaAsync(int matriculaId)
    {
        var m = await _db.Matriculas
            .Include(x => x.Estudiante)
            .Include(x => x.Detalles).ThenInclude(d => d.Grupo)!.ThenInclude(g => g.Materia)
            .Include(x => x.Detalles).ThenInclude(d => d.Grupo)!.ThenInclude(g => g.Profesor)
            .FirstOrDefaultAsync(x => x.Id == matriculaId);

        if (m is null) throw new InvalidOperationException("Matrícula no encontrada.");

        var logoPath = Path.Combine(_env.WebRootPath, "img", "logo.png");
        byte[]? logo = File.Exists(logoPath) ? File.ReadAllBytes(logoPath) : null;

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Row(row =>
                {
                    row.ConstantItem(80).Height(60).AlignMiddle().AlignCenter().Element(el =>
                    {
                        if (logo is not null) el.Image(logo).FitArea();
                        else el.Text("IPTC").SemiBold();
                    });

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Sistema Web de Matrícula Escolar").FontSize(16).SemiBold();
                        col.Item().Text("Comprobante de Matrícula").FontSize(12);
                        col.Item().Text($"Periodo: {m.Periodo}  |  Fecha: {m.Fecha:dd/MM/yyyy HH:mm}");
                    });
                });

                page.Content().PaddingTop(15).Column(col =>
                {
                    col.Item().Text($"Estudiante: {m.Estudiante!.NombreCompleto}").SemiBold();
                    col.Item().Text($"Cédula: {m.Estudiante!.Cedula}  |  Grado: {m.Estudiante!.Grado}");

                    col.Item().PaddingTop(10).Table(t =>
                    {
                        t.ColumnsDefinition(c =>
                        {
                            c.RelativeColumn(2);
                            c.RelativeColumn(3);
                            c.RelativeColumn(3);
                            c.RelativeColumn(2);
                        });

                        t.Header(h =>
                        {
                            h.Cell().Element(CellHeader).Text("Código");
                            h.Cell().Element(CellHeader).Text("Materia");
                            h.Cell().Element(CellHeader).Text("Profesor");
                            h.Cell().Element(CellHeader).Text("Sección");
                        });

                        foreach (var d in m.Detalles)
                        {
                            t.Cell().Element(CellBody).Text(d.Grupo!.Materia!.Codigo);
                            t.Cell().Element(CellBody).Text(d.Grupo!.Materia!.Nombre);
                            t.Cell().Element(CellBody).Text(d.Grupo!.Profesor!.NombreCompleto);
                            t.Cell().Element(CellBody).Text($"{d.Grupo!.Grado}-{d.Grupo!.Seccion}");
                        }
                    });

                    col.Item().PaddingTop(12).Text("Nota: Este comprobante es válido para fines administrativos.").Italic();
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Generado por MatriculaEscolarIPTC • ");
                    x.Span(DateTime.Now.ToString("dd/MM/yyyy"));
                });
            });
        });

        return doc.GeneratePdf();

        static IContainer CellHeader(IContainer c) =>
            c.Background(Colors.Grey.Lighten3).Padding(6).Border(1).BorderColor(Colors.Grey.Lighten1).DefaultTextStyle(x => x.SemiBold());

        static IContainer CellBody(IContainer c) =>
            c.Padding(6).Border(1).BorderColor(Colors.Grey.Lighten1);
    }

    public async Task<byte[]> HistorialSimpleAsync(int estudianteId)
    {
        var est = await _db.Estudiantes.FirstOrDefaultAsync(x => x.Id == estudianteId);
        if (est is null) throw new InvalidOperationException("Estudiante no encontrado.");

        var matriculas = await _db.Matriculas
            .Where(x => x.EstudianteId == estudianteId)
            .Include(x => x.Detalles).ThenInclude(d => d.Grupo)!.ThenInclude(g => g.Materia)
            .OrderByDescending(x => x.Fecha)
            .ToListAsync();

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Text($"Historial académico (simple) - {est.NombreCompleto}").FontSize(14).SemiBold();

                page.Content().PaddingTop(10).Column(col =>
                {
                    foreach (var m in matriculas)
                    {
                        col.Item().PaddingTop(8).Text($"Periodo {m.Periodo} - {m.Fecha:dd/MM/yyyy}").SemiBold();

                        col.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c => { c.RelativeColumn(2); c.RelativeColumn(6); });
                            t.Header(h =>
                            {
                                h.Cell().Element(CellHeader).Text("Código");
                                h.Cell().Element(CellHeader).Text("Materia");
                            });

                            foreach (var d in m.Detalles)
                            {
                                t.Cell().Element(CellBody).Text(d.Grupo!.Materia!.Codigo);
                                t.Cell().Element(CellBody).Text(d.Grupo!.Materia!.Nombre);
                            }
                        });
                    }
                });
            });
        });

        return doc.GeneratePdf();

        static IContainer CellHeader(IContainer c) =>
            c.Background(Colors.Grey.Lighten3).Padding(6).Border(1).BorderColor(Colors.Grey.Lighten1).DefaultTextStyle(x => x.SemiBold());

        static IContainer CellBody(IContainer c) =>
            c.Padding(6).Border(1).BorderColor(Colors.Grey.Lighten1);
    }
}