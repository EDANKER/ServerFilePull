using System;
using System.Net;
using System.Text;
using System.Text.Unicode;

namespace Microsoft
{
    class Programm
    {
        private static async Task Main(string[] args)
        {
            HttpListener server = new HttpListener();
            
            server.Prefixes.Add("http://10.3.8.227:8888/connection/");
            server.Start();

            var context = await server.GetContextAsync();
            
            var request = context.Request;
            var response = context.Response;
            var user = context.User;
            
            string responseText = 
                @"<!DOCTYPE html>
                <html>
                    <head>
                       <meta charset='utf8'>
                        <title>Эдгар</title>
                </head>
                <body>
                    <h2>Hello моя любимая геля</h2>
                    </body>
                </html>";

            byte[] bufer = Encoding.UTF8.GetBytes(responseText);

            response.ContentLength64 = bufer.Length;

            using Stream output = response.OutputStream;

            await output.WriteAsync(bufer);
            await output.FlushAsync();

            Console.WriteLine("запрос обработан");
            
            
        }
    }
    
}

