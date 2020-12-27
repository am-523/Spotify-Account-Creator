using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Console = Colorful.Console;

namespace Spotify_Account_Creator
{

    // Project AM
    // Subscribe On Youtube : https://www.youtube.com/channel/UCwI8AQlBewsdxbyk2r4n9CQ
    // Github : https://github.com/am-523/
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Utils.centerText(" ███████╗██████╗  ██████╗ ████████╗██╗███████╗██╗   ██╗", Color.LightGreen);
            Utils.centerText(" ██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝██║██╔════╝╚██╗ ██╔╝", Color.LightGreen);
            Utils.centerText(" ███████╗██████╔╝██║   ██║   ██║   ██║█████╗   ╚████╔╝ ", Color.LightGreen);
            Utils.centerText(" ╚════██║██╔═══╝ ██║   ██║   ██║   ██║██╔══╝    ╚██╔╝  ", Color.LightGreen);
            Utils.centerText(" ███████║██║     ╚██████╔╝   ██║   ██║██║        ██║   ", Color.LightGreen);
            Utils.centerText(" ╚══════╝╚═╝      ╚═════╝    ╚═╝   ╚═╝╚═╝        ╚═╝   ", Color.LightGreen);
            Utils.centerText("Created by cracked.to/FanTaZyX\n\n", Color.Green);

            Console.Write(DateTime.Now.ToString("[hh:mm:ss]"), Color.Pink);
            Console.Write(" » How many ", Color.White);
            Console.Write("ACCOUNTS", Color.White);
            Console.Write(" do you want", Color.White);
            Console.Write(": ", Color.Green);
            try
            {
                limit = int.Parse(Console.ReadLine());
            }
            catch
            {
                limit = 0;
            }

            Console.Write(DateTime.Now.ToString("[hh:mm:ss]"), Color.Pink);
            Console.Write(" » How many ", Color.White);
            Console.Write("THREADS", Color.White);
            Console.Write(" do you want to use", Color.White);
            Console.Write(": ", Color.Green);
            try
            {
                threads = int.Parse(Console.ReadLine());
            }
            catch
            {
                threads = 100;
            }

            loadProxies();

            for (int i = 1; i <= threads; i++)
            {
                new Thread(new ThreadStart(createAccount)).Start();
            }
        }

        public static void loadProxies()
        {
            string fileName = "proxies.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("You need to add proxies.txt");
                Environment.Exit(0);
            }

            proxies = new List<string>(File.ReadAllLines(fileName));
            countProxies(fileName);

            Console.Write(DateTime.Now.ToString("[hh:mm:ss]"), Color.Pink);
            Console.Write(" » ");
            Console.Write(proxyTotal, Color.Pink);
            Console.WriteLine(" Proxies added\n");
        }

        private static void countProxies(string fileName)
        {
            using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = new StreamReader(bufferedStream))
                    {
                        while (streamReader.ReadLine() != null)
                        {
                            proxyTotal++;
                        }
                    }
                }
            }
        }

        private static void createAccount()
        {
            if (limit == 0)
            {
                for (; ; )
                {
                    var rdmString = Generate(12);

                    Interlocked.Increment(ref proxyIndex);
                    if (proxyIndex > proxyTotal - 2) proxyIndex = 0;

                    var client = new RestClient("https://spclient.wg.spotify.com/signup/public/v1/account/");
                    client.Proxy = new WebProxy($"http://{proxies[proxyIndex]}");
                    client.Timeout = 100000;
                    var request = new RestRequest(Method.POST);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("creation_flow", "desktop");
                    request.AddParameter("iagree", "1");
                    request.AddParameter("password_repeat", $"{rdmString}");
                    request.AddParameter("password", $"{rdmString}");
                    request.AddParameter("birth_day", "6");
                    request.AddParameter("key", "4c7a36d5260abca4af282779720cf631");
                    request.AddParameter("birth_year", "1996");
                    request.AddParameter("displayname", $"{rdmString}");
                    request.AddParameter("creation_point", "https://login.app.spotify.com?utm_source=spotify&utm_medium=desktop-win32&utm_campaign=organic");
                    request.AddParameter("platform", "desktop");
                    request.AddParameter("birth_month", "10");
                    request.AddParameter("email", $"{rdmString}@yopmail.net");
                    request.AddParameter("referrer", "");
                    request.AddParameter("gender", "female");
                    IRestResponse response = client.Execute(request);

                    if (response.Content.Contains("status\":1"))
                    {
                        string country = string.Join("", JSON(response.Content, "country"));
                        Interlocked.Increment(ref account);
                        Console.WriteLine($"[#{account}/Unlimited] Email: {rdmString}@yopmail.net Password: {rdmString} in {country}", Color.Green);
                        SaveData(rdmString, country);
                    }
                }
            }
            else
            {
                while (true)
                {
                    var rdmString = Generate(12);

                    Interlocked.Increment(ref proxyIndex);
                    if (proxyIndex > proxyTotal - 2) proxyIndex = 0;

                    var client = new RestClient("https://spclient.wg.spotify.com/signup/public/v1/account/");
                    client.Proxy = new WebProxy($"http://{proxies[proxyIndex]}");
                    client.Timeout = 100000;
                    var request = new RestRequest(Method.POST);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("creation_flow", "desktop");
                    request.AddParameter("iagree", "1");
                    request.AddParameter("password_repeat", $"ProJectAm@{rdmString}");
                    request.AddParameter("password", $"ProjectAm@{rdmString}");
                    request.AddParameter("birth_day", "6");
                    request.AddParameter("key", "4c7a36d5260abca4af282779720cf631");
                    request.AddParameter("birth_year", "1996");
                    request.AddParameter("displayname", "{rdmString}");
                    request.AddParameter("creation_point", "https://login.app.spotify.com?utm_source=spotify&utm_medium=desktop-win32&utm_campaign=organic");
                    request.AddParameter("platform", "desktop");
                    request.AddParameter("birth_month", "10");
                    request.AddParameter("email", $"{rdmString}@yopmail.net");
                    request.AddParameter("referrer", "");
                    request.AddParameter("gender", "female");
                    IRestResponse response = client.Execute(request);

                    if (response.Content.Contains("status\":1") && account <= limit)
                    {
                        string country = string.Join("", JSON(response.Content, "country"));
                        Interlocked.Increment(ref account);
                        Console.WriteLine($"[#{account}/{limit}] Email: {rdmString}@yopmail.net Password: {rdmString} in {country}", Color.Green);
                        SaveData(rdmString, country);
                    }

                    if (account > limit)
                    {
                        Console.WriteLine($"Limit of {limit} reached", Color.Yellow);
                        Environment.Exit(0);
                    }
                }
            }
        }

        public static IEnumerable<string> JSON(string input, string field, bool recursive = false, bool useJToken = false)
        {
            var list = new List<string>();

            if (useJToken)
            {
                if (recursive)
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                }
                else
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                }
            }
            else
            {
                var jsonlist = new List<KeyValuePair<string, string>>();
                parseJSON("", input, jsonlist);
                foreach (var j in jsonlist)
                    if (j.Key == field)
                        list.Add(j.Value);

                if (!recursive && list.Count > 1) list = new List<string>() { list.First() };
            }

            return list;
        }

        private static void parseJSON(string A, string B, List<KeyValuePair<string, string>> jsonlist)
        {
            jsonlist.Add(new KeyValuePair<string, string>(A, B));

            if (B.StartsWith("["))
            {
                JArray arr = null;
                try { arr = JArray.Parse(B); } catch { return; }

                foreach (var i in arr.Children())
                    parseJSON("", i.ToString(), jsonlist);
            }

            if (B.Contains("{"))
            {
                JObject obj = null;
                try { obj = JObject.Parse(B); } catch { return; }

                foreach (var o in obj)
                    parseJSON(o.Key, o.Value.ToString(), jsonlist);
            }
        }

        public static void SaveData(string rdmString, string country)
        {
            using (StreamWriter sw = File.AppendText($"accounts/{country}.txt"))
            {
                sw.WriteLine($"{rdmString}@yopmail.net:{rdmString}");
            }
        }

        public static string Generate(int size)
        {
            const string chars = "abcdefghijklmnopqrstuvwxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<string> proxies = new List<string>();
        public static string proxyType = "";
        public static int proxyIndex = 0;
        public static int proxyTotal = 0;

        public static int account = 0;
        public static int limit;
        public static int threads;

    }
}
