namespace KWFBlazorWasm.JsAccessor
{
    using System.Threading.Tasks;
    public interface IBrowserStorageAccessor
    {
        Task<string> GetFromLocalStorage(string key);
        Task<T> GetParsedFromLocalStorage<T>(string key) where T : notnull;
        Task RemoveFromLocalStorage(string key);
        Task SetLocalStorage(string key, string value);
        Task SetLocalStorage<T>(string key, T value);
        Task SetBrowserStorageListener<T>(T parentClass, string jsInvokableMethodName)
            where T : class;
        T ParseValue<T>(string storedString);
        string StringifyValue<T>(T value);
    }
}
