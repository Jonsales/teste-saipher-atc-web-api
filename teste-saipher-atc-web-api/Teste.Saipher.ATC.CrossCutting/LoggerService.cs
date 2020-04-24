using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Teste.Saipher.ATC.Domain.Interfaces.Services.Helper;
using System;
using System.IO;

namespace Teste.Saipher.ATC.CrossCutting
{
    public class LoggerService : ILoggerService
    {
        private readonly IHelperService _helperService;
        private readonly IConfiguration _config;
        public LoggerService(IHelperService helperService, IConfiguration configuration)
        {
            _helperService = helperService;
            _config = configuration;
        }
        public void GerarLogException(Exception ex, string identificacao, object request = null, int usuarioId = 0, object body = null)
        {
            try
            {
                HttpRequest newRequest = (HttpRequest)request;
                if (Convert.ToBoolean(_config.GetValue<bool>("Settings:TraceLog")))
                {
                    string path = "";
                    path = Path.Combine(VerificaPastaLogErro(identificacao), $"{DateTime.Now.ToString("dd_MM_yyyy HH")}.txt");

                    // This text is added only once to the file.
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("*****************************************************");
                            sw.WriteLine("****** LOG ERRO API SPC CONSUMIDOR  Portal **********");
                            sw.WriteLine("*****************************************************");
                            sw.Write(Environment.NewLine);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write(Environment.NewLine);
                            sw.Write(Environment.NewLine);
                            sw.WriteLine("*****************************************************************");
                            sw.Write(Environment.NewLine);
                            sw.Write(Environment.NewLine);
                        }
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("Identificação  : " + identificacao);
                        sw.WriteLine("Data / Hora    : " + $"{DateTime.Now.ToString("dd/MM/yyyy")} - {DateTime.Now.ToString("HH:mm:ss:ms")}");

                        if (usuarioId > 0)
                            sw.WriteLine($"Id do usuário  : {usuarioId}");
                        
                        sw.Write(Environment.NewLine);
                        sw.WriteLine("----------------- DESCRIÇÃO DO ERRO ----------------------");
                        sw.Write(Environment.NewLine);
                        if (newRequest != null)
                        {
                            var bodyRequest = body == null ? "" : JsonConvert.SerializeObject(body);
                            var erroRequest = $"{ Environment.NewLine }" +
                                 $"************ INFORMAÇÕES REQUEST *************{ Environment.NewLine} { Environment.NewLine}" +
                                 $"DATA DA REQUISIÇÃO : {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ms")} {Environment.NewLine}" +
                                 $"CONTOLLER : {newRequest.Path.ToString()} {Environment.NewLine}" +
                                 $"HEADERS : {newRequest.Headers.ToString().Trim().Replace(Environment.NewLine, Environment.NewLine + "\t")} {Environment.NewLine}" +
                                 $"MÉTODO : {newRequest.Method.ToString()} {Environment.NewLine}" +
                                 $"HOST : {newRequest.Host.ToString()} {Environment.NewLine}" +
                                 $"ESQUEMA : {newRequest.Scheme.ToString()} {Environment.NewLine}" +
                                 $"BODY REQUEST: {bodyRequest} {Environment.NewLine}";
                            sw.Write(erroRequest);
                        }
                        sw.WriteLine("--------------------------------------------------");
                        sw.Write(Environment.NewLine);
                        if (ex != null)
                        {

                            var erroException = $"{ Environment.NewLine }" +
                                 $"************ INFORMAÇÕES EXCEPTION *************{ Environment.NewLine} { Environment.NewLine}" +
                                 $"MENSGEM : {ex.Message } {Environment.NewLine}" +
                                 $"TYPE : {ex.GetType().ToString()} {Environment.NewLine}" +
                                 $"TRACE : {ex.StackTrace} {Environment.NewLine}" +
                                 $"INNER EXCPETION : {ex.InnerException} {Environment.NewLine}";
                            sw.Write(erroException);
                        }
                        sw.WriteLine("--------------------------------------------------");

                    }
                }
            }
            catch (Exception exception)
            { }
        }
        private string VerificaPastaLogErro(string pasta)
        {
            try
            {
                var pathLog = "";
                var path =  _config.GetValue<string>("Settings:PathLog");
                if(!string.IsNullOrWhiteSpace(path))
                    pathLog = Path.Combine(path, "LOG_ERRO", pasta);
                else 
                    pathLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG_ERRO", pasta);

                if (!Directory.Exists(pathLog))
                    Directory.CreateDirectory(pathLog);

                return pathLog;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
