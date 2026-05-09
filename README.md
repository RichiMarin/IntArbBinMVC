# Integrador Árboles Binarios MVC (C#)

## Descripción del proyecto

Este proyecto es una aplicación de consola desarrollada en C# que implementa la estructura de datos de **Árbol Binario**, aplicando el patrón de arquitectura **MVC (Modelo - Vista - Controlador)**.

El sistema permite la creación, inserción, recorrido y visualización de nodos dentro de un árbol binario, manteniendo una separación clara de responsabilidades entre capas.

---

## Autor

- Nombre: Ricardo Marín Herrera
- Universidad: Universidad de Manizales
- Programa: Ingeniería de Sistemas Virtual
- Asignatura: Programación III
- Proyecto: Integrador Árboles Binarios MVC


### Responsabilidades:
- Diseño e implementación del árbol binario
- Desarrollo del modelo (lógica de nodos y estructura)
- Implementación del controlador (flujo del sistema)
- Desarrollo de la vista en consola
- Integración general del patrón MVC
- Pruebas y validación del funcionamiento del sistema

---

## Arquitectura del sistema (MVC)

### Model
Encargado de la lógica del negocio:
- Definición de nodos del árbol
- Inserción de elementos
- Recorridos del árbol (inorden, preorden, postorden)
- Estructura del árbol binario

### View
Encargada de la interacción con el usuario:
- Menús por consola
- Entrada y salida de datos
- Visualización de resultados

### Controller
Encargado de la coordinación:
- Comunicación entre Model y View
- Control del flujo del programa
- Ejecución de operaciones solicitadas por el usuario

---

## Requisitos para ejecutar el proyecto

- .NET SDK 6 o superior
- Visual Studio 2022 o Visual Studio Code
- Git (opcional)

---

## Ejecución del proyecto

Clonar el repositorio:

```bash
git clone https://github.com/RichiMarin/IntArbBinMVC.git

cd IntArbBinMVC

dotnet build

dotnet run
