
namespace Rail.Domain.Abstractions;

public interface IBinarySerializer
{
    public byte[] Serialize<T>(T data);
    public T Deserialize<T>(byte[] data);
}