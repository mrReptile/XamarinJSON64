using JSON64.Helper;
using JSON64.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSON64.Services
{
    public class UsuarioService
    {

        HttpClient client;
        private readonly string API_USUARIOS = "Usuarios";

        public UsuarioService()
        {

#if DEBUG
            var handler = new BypassSslValidationClientHandler();
            client = new HttpClient(handler);
#else
            client = new HttpClient();
#endif

        }

        public async Task<string> RegisterAsync(Usuario usuario)
        {
            string result = string.Empty;
            if(usuario!=null && !string.IsNullOrEmpty(usuario.Name) && !string.IsNullOrEmpty(usuario.Password))
            {
                result = JsonSerializer.Serialize(usuario);
                //TODO: Call your ow web api
                StringContent content = new StringContent(result, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
               
                    response = await client.PostAsync(AppRes.ApiRes.ApiHost + API_USUARIOS, content);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content;
                    result = await contenido.ReadAsStringAsync();
                }
                
            }

            return result;
        }
    }
}
