namespace Catalog.Host.Models.Response
{
    public class AddContainerResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
