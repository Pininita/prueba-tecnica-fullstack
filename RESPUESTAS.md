# Respuestas a Preguntas de Conocimiento
 Este documento contiene las respuestas a la sección teórica de la prueba técnica para el cargo de Desarrollador Full-Stack.

## 1. Fundamentos de Programación
* **Tipos de datos:** Manejo tipos primitivos como:
 `Strings`, `Numbers`/`Integers`, `Booleans`, y estructuras complejas como `Arrays` (Vectores) y `Objetos`/`Diccionarios`
* **Estructuras de control:** Conocimiento en condicionales (`if`, `else`, `switch`) y bucles (`for`, `while`, `map`, `forEach`)
* **Funciones:** Experiencia definiendo bloques de código reutilizables, incluyendo funciones de flecha (Arrow Functions) y funciones asíncronas

```javascript
    // Funcion Normal
    function funcionNormal (a, b) {
        return a + b
    }

    funcionNormal(3,5) // = 8

    // Funcion flecha
    let funcionFlecha = (a, b) => a + b

    console.log(funcionFlecha("hola ", "mundo!" )) // "hola mundo!"
```

## 2. Control de Versionamiento (Git) 

* **¿Por qué es importante Git?**: Es como una "máquina del tiempo" para el código. Permite que varias personas trabajen en el mismo proyecto sin borrarse el trabajo entre sí, guardando un historial de cada cambio por si necesitamos regresar a una versión anterior.
* **Operaciones que realizo**:
    * `git commit`: Es como darle a "Guardar" para registrar mis avances con un mensaje que explica qué hice.
    * `git merge`: Se usa para unir el trabajo de una rama (por ejemplo, una nueva función) con la rama principal.
    * **Resolución de conflictos**: Cuando dos personas manipulan la misma línea de código, Git nos avisara. Mi labor es revisar ambos cambios, elegir cuál es el correcto (o mezclarlos) y confirmar la decisión con un nuevo commit.
* **Comando para crear una rama**: 
    ```bash
    git checkout -b nombre-de-la-rama
    ```
    *(Este comando crea la rama y te mueve a ella de inmediato).* 
## 3. React

* **Hooks**: Son herramientas que nos facilita la reutilizacion de logica entre componentes. El más usado es `useState`, que sirve para que la aplicación recuerde datos (como el nombre de un usuario), y `useEffect`, que se usa para traer datos de una API cuando la página carga.
* **Redux**: Es como una "bodega central" de datos. En lugar de pasar información de un componente a otro como si fuera un teléfono roto, la guardamos en Redux para que cualquier parte de la app pueda usarla fácilmente o como usar un cestado global.
* **React Router**: Es lo que nos permite crear diferentes "páginas" dentro de nuestra aplicación. Esto facilita la navegacion del usuario sin que la página se tenga que refrescar por completo.

## 4. CQRS (Separar Lectura de Escritura)

* **¿Qué es?**: Es una forma de organizar el código donde separamos las tareas de **pedir información** (consultas) de las tareas de **guardar o cambiar información** (comandos).
* **¿Para qué sirve?**: Hace que la aplicación sea mucho más rápida y ordenada, ya que podemos optimizar cada parte por separado según lo que necesite el usuario.


## 5. MediatR

* **¿Qué es?**: Es una herramienta que actúa como un "mensajero" o intermediario dentro del código.
* **¿Cómo ayuda?**: Evita que los componentes de la aplicación estén todos amarrados entre sí. En lugar de que una clase llame directamente a otra, le entrega un mensaje a MediatR y este se encarga de que llegue a quien debe procesarlo. Esto hace que el código sea más fácil de mantener.

## 6. FluentValidation

* **¿Qué es?**: Es una librería para validar que los datos que entran a nuestra aplicación sean correctos (por ejemplo, que un correo sea un correo real).
* **¿Cómo se usa?**: Nos permite escribir reglas de validación de forma muy clara, casi como si estuviéramos escribiendo una frase en inglés. Lo mejor es que mantiene estas reglas separadas de nuestros modelos, dejando el código mucho más limpio.