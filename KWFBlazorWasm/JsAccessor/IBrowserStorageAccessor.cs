namespace KWFBlazorWasm.JsAccessor
{
    using System.Threading.Tasks;
    public interface IBrowserStorageAccessor
    {
        Task<T> GetFromLocalStorage<T>(string key) where T: notnull;
        Task RemoveFromLocalStorage(string key);
        Task SetLocalStorage<T>(string key, T value);
    }
}
