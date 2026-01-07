# Prueba Técnica Full-Stack

Sistema CRUD de gestión de personas desarrollado con **React** (Frontend) y **ASP.NET Core** (Backend).

## 📋 Descripción

Aplicación Full-Stack que implementa un CRUD completo para la gestión de personas, con dos formularios independientes (A y B) que comparten un componente base reutilizable, búsqueda de personas por nombre, y vista consolidada con estadísticas.

## 🛠️ Tecnologías Utilizadas

### Backend
- **ASP.NET Core 6.0+**
- **C#**
- **MediatR** - Patrón CQRS (Command Query Responsibility Segregation)
- **FluentValidation** - Validación de modelos
- **Swagger** - Documentación de API
- **Almacenamiento en memoria**

### Frontend
- **React 18** con **Vite**
- **Axios** - Cliente HTTP
- **Tailwind CSS** - Estilos
- **JavaScript (ES6+)**

## 📁 Estructura del Proyecto

```
prueba-tecnica/
├── backend/
│   └── PersonasAPI/
│       ├── Models/
│       ├── DTOs/
│       ├── Validators/
│       ├── Repositories/
│       ├── Commands/
│       ├── Queries/
│       ├── Handlers/
│       ├── Controllers/
│       └── Program.cs
├── frontend/
│   └── personas-app/
│       ├── src/
│       │   ├── components/
│       │   ├── services/
│       │   ├── App.jsx
│       │   └── main.jsx
│       └── package.json
├── pseudocodigo.jpg
└── README.md
```

## 🚀 Instalación y Ejecución

### Prerequisitos

- **.NET SDK 6.0 o superior** - [Descargar aquí](https://dotnet.microsoft.com/download)
- **Node.js 16+ y npm** - [Descargar aquí](https://nodejs.org/)
- **Visual Studio 2022** o **Visual Studio Code**
- **Git**

### 1️⃣ Clonar el Repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd prueba-tecnica
```

### 2️⃣ Ejecutar el Backend

**Opción A - Usando Visual Studio:**

1. Abrir `backend/PersonasAPI/PersonasAPI.sln`
2. Presionar **F5** o click en el botón ▶️ **Run**
3. El backend se ejecutará en: `https://localhost:5217` (o el puerto que te asigne)
4. Swagger estará disponible en: `https://localhost:5217/swagger`

**Opción B - Usando .NET CLI:**

```bash
cd backend/PersonasAPI
dotnet restore
dotnet run
```

La API estará disponible en: `http://localhost:5217`

### 3️⃣ Ejecutar el Frontend

**⚠️ IMPORTANTE**: Antes de ejecutar el frontend, verifica el puerto del backend.

1. Abre `frontend/personas-app/src/services/personaService.js`
2. Verifica que la URL coincida con tu puerto del backend:
   ```javascript
   const API_URL = 'http://localhost:5217/api/personas';
   ```
3. Si tu backend usa otro puerto, cámbialo aquí.

**Ejecutar el frontend:**

```bash
cd frontend/personas-app
npm install
npm run dev
```

La aplicación estará disponible en: `http://localhost:5173`

## 📖 Uso de la Aplicación

### Endpoints de la API

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/personas` | Obtener todas las personas |
| GET | `/api/personas/{id}` | Obtener persona por ID |
| GET | `/api/personas/buscar?nombre={nombre}` | Buscar personas por nombre |
| POST | `/api/personas` | Crear nueva persona |
| PUT | `/api/personas/{id}` | Actualizar persona existente |
| DELETE | `/api/personas/{id}` | Eliminar persona |

### Ejemplo de Petición POST

```json
{
  "nombre": "Juan",
  "apellido": "Pérez",
  "correo": "juan@ejemplo.com",
  "documento": "12345678",
  "telefono": "3001234567"
}
```

### Funcionalidades del Frontend

1. **Formulario A**: Captura datos básicos (nombre, apellido, correo, documento)
2. **Formulario B**: Captura datos extendidos (incluye teléfono)
3. **Vista Consolidada**: 
   - Búsqueda de personas por nombre/apellido
   - Listado completo de todas las personas
   - Estadísticas (total por formulario)
4. **Operaciones CRUD**: Crear, listar, buscar y eliminar personas

## 🧪 Probar la API con Swagger

1. Ejecuta el backend
2. Abre tu navegador en: `http://localhost:5217/swagger`
3. Prueba los endpoints directamente desde la interfaz de Swagger

## 🏗️ Arquitectura

### Backend - Patrón CQRS con MediatR

El backend implementa el patrón CQRS (Command Query Responsibility Segregation):

- **Commands**: Operaciones que modifican datos (Create, Update, Delete)
- **Queries**: Operaciones de consulta (GetAll, GetById, Search)
- **Handlers**: Procesan los Commands y Queries
- **FluentValidation**: Valida los datos de entrada
- **Repository Pattern**: Abstrae el acceso a datos (en memoria)

### Frontend - Componentes Reutilizables

- **FormularioBase**: Componente genérico reutilizado por Formulario A y B
- **ListadoPersonas**: Componente para mostrar tablas de personas
- **BuscadorPersonas**: Componente de búsqueda
- **State Management**: Estados separados para cada formulario

## ✅ Requisitos Implementados

- ✅ API REST con ASP.NET Core
- ✅ CRUD completo de Personas
- ✅ Validaciones con FluentValidation
- ✅ Patrón CQRS con MediatR
- ✅ Almacenamiento en memoria
- ✅ Frontend en React
- ✅ Dos formularios (A y B) con componente base reutilizable
- ✅ Estados separados (personasFormularioA y personasFormularioB)
- ✅ Búsqueda de personas por nombre
- ✅ Listado consolidado
- ✅ CORS configurado
- ✅ Diseño responsive con Tailwind CSS

## 📝 Notas Adicionales

- Los datos se almacenan en memoria, por lo que se pierden al reiniciar el backend
- El puerto del backend puede variar según tu configuración
- Asegúrate de que el backend esté corriendo antes de usar el frontend
- Las validaciones se realizan tanto en frontend como en backend

## 👨‍💻 Autor

Sebastian Velez - Prueba Técnica Full-Stack (Diciembre 2025)

## 📄 Licencia

Este proyecto fue desarrollado como parte de una prueba técnica.