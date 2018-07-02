using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericStringEnumConverter.Converter {
    // Agregamos las interfaces de las definiciones de Enum
    public class GenericStringEnumConverter<TEnum> : StringEnumConverter where TEnum : struct, IComparable, IConvertible, IFormattable {
        // Reemplazando la funcionalidad estandar que indica si se puede transformar o no
        public override bool CanConvert(Type objectType) {
            // Validando que el tipo de datos especificado sea una enumeracion
            if (typeof(TEnum).IsEnum) {
                // Verificando si el tipo de datos del objeto corresponde con el especificado en la restriccion generica
                if (typeof(TEnum) == objectType) {
                    return base.CanConvert(objectType);
                }
            }
            return false;
        }
    }
}