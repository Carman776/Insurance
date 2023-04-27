using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Insurance.Models
{
    [Serializable]    
    [BsonIgnoreExtraElements]
    
    public class InsuranceRegister
    {
        public Nullable<Int32> NumeroPoliza { get; set; }
        public String? NombreCliente { get; set; }
        public String? IdentificacionCliente { get; set; }
        public Nullable<DateTime> FechaNacimiento { get; set; }
        public Nullable<DateTime> FechaDeTomaPoliza { get; set; }        
        public Nullable<Int32> CoberturasPoliza { get; set; }
        public Nullable<Double> ValorMaximoPoliza { get; set; }
        public String? NombrePoliza { get; set; }
        public String? CiudadResidencia { get; set; }
        public String? DireccionResidencia { get; set; }
        public String? PlacaVehiculo { get; set; }
        public Nullable<Int32> ModeloVehiculo { get; set; }
        public Nullable<Boolean> Inspeccion { get; set; }

    }
}
