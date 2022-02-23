namespace KWFBlazorWasm.JsAccessor
{
    using Microsoft.JSInterop;

    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    using KWFBlazorWasm.Context.Application;

    public class BrowserStorageAccessor : IBrowserStorageAccessor, IDisposable
    {
        private readonly IJSRuntime jSRuntime;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private IJSObjectReference storageModule;
        private bool isDisposed;

        public BrowserStorageAccessor(IJSRuntime jSRuntime, IApplicationContext applicationContext)
        {
            this.jSRuntime = jSRuntime;
            this.jsonSerializerOptions = applicationContext.StandartAppJsonSettings.JsonSerializerOptions;
        }

        public async Task RemoveFromLocalStorage(string key)
        {
            await this.jSRuntime.InvokeAsync<string>("localStorage.removeItem", key);
        }

        public async Task<string> GetFromLocalStorage(string key)
        {
            return await this.jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task<T> GetParsedFromLocalStorage<T>(string key) where T : notnull
        {
            var value = await this.jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return this.ParseValue<T>(value);
        }

        public async Task SetLocalStorage(string key, string value)
        {
            await this.jSRuntime.InvokeAsync<string>("localStorage.setItem", key, value);
        }

        public async Task SetLocalStorage<T>(string key, T value)
        {
            await this.jSRuntime.InvokeAsync<string>("localStorage.setItem", key, this.StringifyValue(value));
        }

        public async Task SetBrowserStorageListener<T>(T parentClass, string jsInvokableMethodName)
            where T : class
        {
            var objRef = DotNetObjectReference.Create(parentClass);
            await (await GetStorageModule()).InvokeVoidAsync("addStorageEventListener", objRef, jsInvokableMethodName);
        }

        public T ParseValue<T>(string storedString)
        {
            if (string.IsNullOrEmpty(storedString))
            {
                return default!;
            }

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                case TypeCode.Char:
                    return (T)(object)storedString;
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    {
                        if (int.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                case TypeCode.Double:
                    {
                        if (double.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                case TypeCode.Decimal:
                    {
                        if (decimal.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                case TypeCode.Boolean:
                    {
                        if (bool.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                case TypeCode.Byte:
                    {
                        if (byte.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                case TypeCode.DateTime:
                    {
                        if (DateTime.TryParse(storedString, out var value))
                        {
                            return (T)(object)value;
                        }
                        break;
                    }
                default:
                    {
                        try
                        {
                            return JsonSerializer.Deserialize<T>(storedString, this.jsonSerializerOptions)!;
                        }
                        catch
                        {
                            break;
                        }
                    }
            }

            return default;
        }

        public string StringifyValue<T>(T value)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                case TypeCode.Char:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Double:
                case TypeCode.Decimal:
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.DateTime:
                    return value.ToString();
                default:
                    {
                        try
                        {
                            return JsonSerializer.Serialize(value, this.jsonSerializerOptions);
                        }
                        catch
                        {
                            return null!;
                        }
                    }
            }
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                if (storageModule is not null)
                {
                    storageModule.DisposeAsync().AsTask().GetAwaiter().GetResult();
                }
                isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }

        private async Task<IJSObjectReference> GetStorageModule()
        {
            if (storageModule is null)
            {
                storageModule = await this.jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/KWFBlazorWasm/JS/BrowserStorageAccessor.js");
            }

            return storageModule;
        }
    }
}
