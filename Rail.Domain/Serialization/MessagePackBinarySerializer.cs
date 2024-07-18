using MessagePack;
using Rail.Domain.Abstractions;

namespace Rail.Domain.Serialization;

public class MessagePackBinarySerializer : IBinarySerializer
{ 
    public byte[] Serialize<T>(T data)
    {
        return MessagePackSerializer.Serialize(data);
    }
    public T Deserialize<T>(byte[] data)
    {
        if (data == null)
            throw new NullReferenceException();
        return MessagePackSerializer.Deserialize<T>(data);
    }

    // public ValueTask<byte[]> SerializeAsync<T>(T cache)
    // {
    //         return MessagePackSerializer.SerializeAsync(stream, cache);
    // }

    // public ValueTask<T> DeserializeAsync<T>(string path)
    // {
    //     using (var stream = new StreamReader(path).BaseStream)
    //     {
    //         return MessagePackSerializer.DeserializeAsync<T>(stream);
    //     }
    // }
}