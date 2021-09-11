namespace KWFBlazorWasm.Context.Language
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;

    using KWFBlazorWasm.Configuration;

    public class LanguageContext: ILanguageContext, ILanguageContextInitializer
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private IDictionary<string, Translation> Translations;
        private Translation CurrentTranslation => this.Translations.TryGetValue(this.LanguageCode, out Translation translation) ? translation : null;

        private LanguageContext(string languageCode, IServiceProvider provider)
        {
            this.IsInitialized = false;
            this.IsLoading = true;
            this.Translations = new Dictionary<string, Translation>();
            this.LanguageCode = languageCode;
            this.httpClient = provider.GetService<HttpClient>();
            this.jsonSerializerOptions = provider.GetService<KwfJsonSerializerOptions>().JsonSerializerOptions;
        }

        public bool IsLoading { get; private set; }
        public bool IsInitialized { get; private set; }
        public string LanguageCode { get; private set; }
        public IDictionary<string, string> Languages { get; private set; }

        public string GetMenuTranslation(string token)
        {
            this.ValidateTranslationGet(token);
            if (this.CurrentTranslation.Menu == null)
            {
                throw new NullReferenceException("Menu translation dictionary was not defined");
            }

            return this.CurrentTranslation.Menu.TryGetValue(token, out string translation) 
                   ? translation
                   : token;
        }

        public string GetErrorTranslation(string token)
        {
            this.ValidateTranslationGet(token);
            if (this.CurrentTranslation.Errors == null)
            {
                throw new NullReferenceException("Errors translation dictionary was not defined");
            }

            return this.CurrentTranslation.Errors.TryGetValue(token, out string translation)
                   ? translation
                   : token;
        }

        public string GetGenericTranslation(string token)
        {
            this.ValidateTranslationGet(token);
            if (this.CurrentTranslation.Generic == null)
            {
                throw new NullReferenceException("Generic translation dictionary was not defined");
            }

            return this.CurrentTranslation.Generic.TryGetValue(token, out string translation)
                   ? translation
                   : token;
        }

        public string GetCustomTranslation(string process, string token)
        {
            this.ValidateTranslationGet(token);
            if (string.IsNullOrEmpty(process))
            {
                throw new ArgumentNullException("Process", "Process cannot be null");
            }

            if (this.CurrentTranslation.Custom == null)
            {
                throw new NullReferenceException("Custom translation dictionary was not defined");
            }

            return this.CurrentTranslation.Custom.TryGetValue(process, out var dictionary)
                   ? dictionary != null && dictionary.TryGetValue(token, out var translation)
                     ? translation
                     : token
                   : $"{process}_{token}";
        }

        public async Task<ILanguageContext> InitializeLanguageContext()
        {
            var translationResponse = await this.GetTranslation(this.LanguageCode, true);
            if (translationResponse != null)
            {
                this.Translations.Add(translationResponse.SelectedLanguageCode, translationResponse.Translation);
                this.LanguageCode = translationResponse.SelectedLanguageCode;
                this.Languages = translationResponse.Languages;
                this.IsLoading = false;
                this.IsInitialized = true;
            }

            return this;
        }

        public async Task ChangeLanguage(string code)
        {
            if (!this.IsInitialized || this.IsLoading || string.IsNullOrEmpty(code))
            {
                return;
            }

            if (this.Translations.ContainsKey(code))
            {
                this.LanguageCode = code;
                return;
            }

            this.IsLoading = true;
            var translationResponse = await this.GetTranslation(code);

            if (translationResponse == null)
            {
                this.IsLoading = false;
                return;
            }

            if (!this.Translations.ContainsKey(translationResponse.SelectedLanguageCode))
            {
                this.Translations.Add(code, translationResponse.Translation);
            }

            this.LanguageCode = translationResponse.SelectedLanguageCode;
            this.IsLoading = false;
        }

        private void ValidateTranslationGet(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("Token", "Token cannot be null");
            }

            if (this.CurrentTranslation == null)
            {
                throw new ArgumentNullException("CurrentTranslation", "CurrentTranslation cannot be null");
            }
        }

        private async Task<TranslationServiceResponse> GetTranslation(string code = null, bool isInitialize = false)
        {
            try
            {
                var requestUrl = string.IsNullOrEmpty(code) || isInitialize ? "default" : code.ToUpperInvariant();

                return await this.httpClient.GetFromJsonAsync<TranslationServiceResponse>($"homepage/translations/{requestUrl}.json", this.jsonSerializerOptions);
            }
            catch
            {
                return null;
            }
        }

        public static ILanguageContextInitializer CreateInstance(IServiceProvider provider)
        {
            return new LanguageContext(null, provider);
        }
        public static ILanguageContextInitializer CreateInstance(string defaultLanguageCode, IServiceProvider provider)
        {
            return new LanguageContext(defaultLanguageCode, provider);
        }
    }
}
