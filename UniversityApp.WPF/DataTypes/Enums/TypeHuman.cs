using System.Text.Json.Serialization;

namespace UniversityApp.DataTypes.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeHuman
    {
        Student,
        Teacher
    }
}