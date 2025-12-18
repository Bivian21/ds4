# MatriculaEscolarIPTC (ASP.NET Core MVC + SQL Server)

Sistema Web de Matrícula Escolar:
- CRUD de Estudiantes, Profesores, Materias
- Grupos/Secciones (Materia + Profesor + Periodo + Grado/Sección)
- Horarios (validación de choques: grupo / profesor / aula)
- Matrículas (agregar grupos y validar choque de horario del estudiante)
- Generación de PDF: Comprobante de matrícula e Historial simple

## Requisitos
- Visual Studio 2022
- .NET 8 SDK
- SQL Server (Express o Developer)

## 1) Configurar la BD
En `appsettings.json` edita:

`Server=localhost\SQLEXPRESS;Database=MatriculaEscolarIPTC;Trusted_Connection=True;TrustServerCertificate=True;`

Si tu instancia es diferente, usa:
- `Server=localhost` (si es instancia default)
- `Server=LAPTOP-XXXX\SQLEXPRESS` (si es SQL Express)

## 2) Crear BD y tablas
Al correr la app por primera vez, el sistema ejecuta `EnsureCreated()` y crea la base de datos y las tablas automáticamente.

## 3) Usuario administrador (seed)
Al correr la app por primera vez se crea:
- Usuario: `admin@iptc.local`
- Clave: `Admin123!`
- Rol: `Admin`

## 4) Flujo recomendado para probar
1. Materias > crear 3 materias
2. Profesores > crear 2 profesores
3. Grupos/Secciones > crear grupos (asignar materia+profesor)
4. Horarios > agregar horarios a cada grupo (validación de choques)
5. Estudiantes > crear estudiantes
6. Matrículas > crear matrícula y agregar grupos (validación choque para estudiante)
7. PDF > desde Matrícula, generar comprobante

## Notas
- El diseño UI usa Bootstrap 5 + CSS moderno (tema oscuro tipo glass).
- PDFs se generan con QuestPDF.
