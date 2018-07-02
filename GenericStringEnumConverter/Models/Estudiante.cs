using GenericStringEnumConverter.Enumeraciones;
using System;

namespace GenericStringEnumConverter.Models {
    public class Estudiante {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public Idioma Idioma { get; set; }
        public Ciclo Ciclo { get; set; }
    }
}