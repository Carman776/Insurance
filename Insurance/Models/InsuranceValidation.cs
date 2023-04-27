using MongoDB.Bson.Serialization.Attributes;

namespace Insurance.Models
{
    [Serializable]
    [BsonIgnoreExtraElements]
    public class InsuranceValidation
    {
        public InsuranceValidation() { }

        public Nullable<Int32> NumeroPoliza { get; set; }
        public Nullable<DateTime> FechaInicioVigencia { get; set; }
        public Nullable<DateTime> FechaFinVigencia { get; set; }

    }
}
