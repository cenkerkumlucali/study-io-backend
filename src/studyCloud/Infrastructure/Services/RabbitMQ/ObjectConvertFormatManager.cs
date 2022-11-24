using System.Net.Http.Json;
using Application.Abstractions.Services.RabbitMQ;
using Newtonsoft.Json;

namespace Infrastructure.Services.RabbitMQ;

public class ObjectConvertFormatManager : IObjectConvertFormat
{
    public T JsonToObject<T>(string jsonString) where T : class, new()
    {
        var objectData = JsonConvert.DeserializeObject<T>(jsonString);
        return objectData;
    }

    public string ObjectToJson<T>(T entityObject) where T : class, new()
    {
        var objectData = JsonConvert.SerializeObject(entityObject);
        return objectData;
    }

    public T ParseObjectDataArray<T>(byte[] rawBytes) where T : class, new()
    {
        throw new NotImplementedException();
    }
}