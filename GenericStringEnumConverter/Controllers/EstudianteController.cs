using GenericStringEnumConverter.Enumeraciones;
using GenericStringEnumConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GenericStringEnumConverter.Controllers {
    [RoutePrefix("api/Estudiante")]
    public class EstudianteController : ApiController {
        private static List<Estudiante> _listadoEstudiantes;

        // Inicializando nuestros datos de prueba
        static EstudianteController() {
            _listadoEstudiantes = new List<Estudiante>() {
                new Estudiante() { Id = Guid.NewGuid(), NombreCompleto = "Luis Gustavo Fernández Batres", Idioma = Idioma.Español, Ciclo = Ciclo.Ciclo_4 },
                new Estudiante() { Id = Guid.NewGuid(), NombreCompleto = "Roberto Antonio Ganuza Rivas", Idioma = Idioma.Ingles, Ciclo = Ciclo.Ciclo_2 },
                new Estudiante() { Id = Guid.NewGuid(), NombreCompleto = "Ana María Chávez Ramírez", Idioma = Idioma.Japones, Ciclo = Ciclo.Ciclo_3 },
                new Estudiante() { Id = Guid.NewGuid(), NombreCompleto = "Silvia Alfaro de Martínez", Idioma = Idioma.Aleman, Ciclo = Ciclo.Ciclo_1 }
            };
        }

        // Devuelve la informacion de todos los estudiantes
        public IHttpActionResult Get() {
            return Ok(_listadoEstudiantes);
        }

        [Route("{id}", Name = "GetPorId")]
        public IHttpActionResult GetPorId(Guid id) {
            Estudiante resultadoBusqueda = _listadoEstudiantes.SingleOrDefault(x => x.Id == id);
            if (resultadoBusqueda != null) {
                return Ok(resultadoBusqueda);
            } else {
                return NotFound();
            }
        }

        // Permite insertar un nuevo estudiante
        public IHttpActionResult Post(Estudiante datos) {
            if (datos != null && !string.IsNullOrWhiteSpace(datos.NombreCompleto)) {
                datos.Id = Guid.NewGuid();
                _listadoEstudiantes.Add(datos);
                return CreatedAtRoute("GetPorId", new { id = datos.Id }, datos);
            } else {
                return BadRequest();
            }
        }

        // Permite actualizar un estudiante
        [Route("{id}")]
        public IHttpActionResult Put(Guid id, Estudiante datos) {
            if (datos != null && !string.IsNullOrWhiteSpace(datos.NombreCompleto)) {
                Estudiante busqueda = _listadoEstudiantes.SingleOrDefault(x => x.Id == id);
                if (busqueda != null) {
                    busqueda.NombreCompleto = datos.NombreCompleto;
                    busqueda.Idioma = datos.Idioma;
                    busqueda.Ciclo = datos.Ciclo;
                    return Ok();
                } else {
                    return NotFound();
                }
            } else {
                return BadRequest();
            }
        }

        // Borra los datos de un estudiante
        [Route("{id}")]
        public IHttpActionResult Delete(Guid id) {
            Estudiante busqueda = _listadoEstudiantes.SingleOrDefault(x => x.Id == id);
            if (busqueda != null) {
                _listadoEstudiantes.Remove(busqueda);
                return Ok(busqueda);
            } else {
                return NotFound();
            }
        }
    }
}
