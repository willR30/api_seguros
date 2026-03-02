# API Seguros 🛡️

Una API REST moderna desarrollada con **.NET 10** para la gestión integral de sistemas de seguros. El proyecto utiliza **Entity Framework Core** para la persistencia de datos y **Swagger** para una documentación interactiva y pruebas de endpoints.

## 🚀 Tecnologías y Herramientas

* **Framework:** .NET 10 (C#)
* **ORM:** Entity Framework Core
* **Base de Datos:** SQL Server
* **Documentación:** Swagger UI (Swashbuckle)
* **Arquitectura:** Web API con patrón de repositorio/controladores.

## 📦 Paquetes NuGet Principales

El proyecto depende de los siguientes paquetes esenciales:
* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.SqlServer`
* `Microsoft.EntityFrameworkCore.Tools`
* `Microsoft.EntityFrameworkCore.Design`
* `Swashbuckle.AspNetCore` (Swagger)
## 🛣️ Funcionalidades del API

El sistema permite la gestión completa del ciclo de vida de una póliza, desde la consulta de catálogos hasta la emisión final.

### 1. Catálogos
* **GET** para obtener la lista de **clientes** registrados.
* **GET** para consultar los **tipos de coberturas** disponibles en el sistema.

### 2. Emisión (Operación Principal)
**Endpoint:** `POST /api/polizas/emitir`

Esta funcionalidad se encarga de formalizar el seguro bajo las siguientes condiciones:
* **Entrada:** Debe recibir el ID del cliente, los datos técnicos del auto y un listado de IDs de las coberturas seleccionadas.
* **Lógica de Negocio:** El campo `PrimaTotal` se calcula automáticamente en el servidor (ej. Sumatoria de los montos de todas las coberturas vinculadas).

### 3. Consultas e Historial

| Método | Endpoint | Descripción |
| :--- | :--- | :--- |
| **GET** | `/api/polizas/{id}` | Ver el detalle completo de una póliza específica ya emitida. |
| **GET** | `/api/polizas` | Listar el historial de todas las emisiones realizadas en el sistema. |

---
> 📂 **Nota:** En la carpeta **SQL** se encuentra el script de la base de datos y un script con registros iniciales.

