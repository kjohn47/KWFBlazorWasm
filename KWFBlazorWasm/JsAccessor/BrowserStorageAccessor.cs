namespace KWFBlazorWasm.JsAccessor
{
    using Microsoft.JSInterop;

    using System;
    using System.Text.Json;
    using System.Threading.Tasks;

    using KWFBlazorWasm.Context.Application;

    public class BrowserStorageAccessor : IBrowserStorageAccessor
    {
        private readonly IJSRuntime jSRuntime;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public BrowserStorageAccessor(IJSRuntime jSRuntime, IApplicationContext applicationContext)
        {
            this.jSRuntime = jSRuntime;
            this.jsonSerializerOptions = applicationContext.StandartAppJsonSettings.JsonSerializerOptions;
        }

        public async Task RemoveFromLocalStorage(string key)
        {
            await this.jSRuntime.InvokeAsync<string>("localStorage.removeItem", key);
        }

        public async Task<T> GetFromLocalStorage<T>(string key) where T : notnull
        {
            var storedString = await this.jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return this.ParseValue<T>(storedString, async () => { await this.RemoveFromLocalStorage(key); });
        }

        public async Task SetLocalStorage<T>(string key, T value)
        {
            await this.jSRuntime.InvokeAsync<string>("localStorage.setItem", key, this.StringifyValue(value));
        }

        private T ParseValue<T>(string storedString, Action cleanupAction = null)
        {
            if (string.IsNullOrEmpty(storedString))
            {
                return default;
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
                            return JsonSerializer.Deserialize<T>(storedString, this.jsonSerializerOptions);
                        }
                        catch
                        {
                            break;
                        }
                    }
            }

            if (cleanupAction != null)
            {
                cleanupAction.Invoke();
            }

            return default;
        }

        private string StringifyValue<T>(T value)
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
                            return null;
                        }
                    }
            }
        }
    }
}
