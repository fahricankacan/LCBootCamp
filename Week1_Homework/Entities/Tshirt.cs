using System.Text.Json.Serialization;
using Week1_Homework.Common;

namespace Week1_Homework.Entities
{
    public class Tshirt:Clothes
    {
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public SizeEnum Size { get; set; }
    }
}
