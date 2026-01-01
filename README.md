# Prueba técnica .NET
Arquitectura:
Tradicional. La feature Clients expone dos servicios y sus dependencias.
¿Por qué no clean architecture? No fue necesario para dos servicios pequeños.

Entidades:
Client
Country

Para automatizar la creación del store procedure se utilizaron migraciones. Es por eso que es necesario una base de datos SqlServer para levantar la aplicación.

## Requerimientos
- .NET 8
- Database SqlServer corriendo

## Variables de entorno
- ConnectionString 
