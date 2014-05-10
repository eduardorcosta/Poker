using System;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Concurrent;

namespace Poker
{
    public class PokerPlayer
    {
        readonly Thread dispatcherThread;
        //readonly BlockingCollection<object> queue;
        readonly HttpListener listener;

        bool IsRunning { get; set; }

        public PokerPlayer()
        {
            IsRunning = true;

            //queue = new BlockingCollection<object>();

            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:9090/");

            dispatcherThread = new Thread(DispatchRequest);
        }

        public void Start()
        {
            listener.Start();

            dispatcherThread.Start();
        }

        public void Stop()
        {
            listener.Stop();

            IsRunning = false;
            dispatcherThread.Join();
        }

        void DispatchRequest()
        {
            while (IsRunning)
            {
                HttpListenerContext context;
                try
                {
                    context = listener.GetContext();
                }
                catch (ObjectDisposedException)
                {

                    Console.WriteLine("Object disposed...");
                    return;
                }

                HandleRequest(context);
            }
        }

        static void HandleRequest(HttpListenerContext context)
        {
            if (!context.Request.HttpMethod.Equals("POST"))
            {
                HandleBadRequest(context);
            }
            else
            {
                var queryParams =  HttpUtility.ParseQueryString(new StreamReader(context.Request.InputStream).ReadToEnd());
                // TODO: dispatch these to worker thread        
                switch (queryParams.Get("action"))
                {
                    case "check":
                        HandleCheckRequest(context);
                        break;
                    case "version":
                        HandleVersionRequest(context, GetGameState(queryParams.Get("game_state")));
                        break;
                    case "bet_request":
                        HandleBetRequest(context, GetGameState(queryParams.Get("game_state")));
                        break;
                    case "showdown":
                        HandleShowdownRequest(context, GetGameState(queryParams.Get("game_state")));
                        break;
                    default:
                        HandleBadRequest(context);
                        break;
                }
            }
        }

        static GameState GetGameState(string gameState)
        {
            var serializer = new DataContractJsonSerializer(typeof(GameState));

            try
            {
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(gameState);
                writer.Flush();
                stream.Position = 0;
                return serializer.ReadObject(stream) as GameState;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        static void HandleBadRequest(HttpListenerContext context)
        {
            Console.WriteLine("Bad request: " + context.Request.HttpMethod + " " + context.Request.Url.AbsolutePath);
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.Close();
        }

        static void HandleCheckRequest(HttpListenerContext context)
        {
            Console.WriteLine("CHECK REQUEST");
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.Close();
        }

        static void HandleVersionRequest(HttpListenerContext context, GameState gameState)
        {
            Console.WriteLine("VERSION REQUEST");
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            var output = new StreamWriter(context.Response.OutputStream);
            // TODO
            output.WriteLine("VERSION GOES HERE");
            output.Flush();
            context.Response.Close();
        }

        static void HandleBetRequest(HttpListenerContext context, GameState gameState)
        {
            Console.WriteLine("BET REQUEST");

            Console.WriteLine(gameState);

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.Close();
        }

        static void HandleShowdownRequest(HttpListenerContext context, GameState gameState)
        {
            Console.WriteLine("SHOWDOWN REQUEST");

            Console.WriteLine(gameState);

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.Close();
        }
    }
}

