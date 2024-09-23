using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using UnityEngine;

namespace Herghys.Telegram.WebGL
{
    public static class TelegramWebGLHelper
    {
        public static string URL = string.Empty;
        public static Dictionary<string, string> Queries { get; private set; } = new();
        public static TelegramUserData UserData = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void ReceiveURLQueries()
        {
            string raw = string.Empty;

            //Parse URL
            try
            {
                raw = TelegramWebGLLib.location_href();
                while (raw.Contains('%'))
                {
                    raw = Uri.UnescapeDataString(raw);
                }
            }
            finally
            {
                URL = raw;
            }

            SetupQueries();
            SetupUserData();
        }

        public static void SetupQueries()
        {
            if (string.IsNullOrEmpty(URL))
                return;

            var queries = URL.Split('&');
            foreach (var query in queries)
            {
                var pair = query.Split('=');
                Queries.Add(pair[0], pair[1]);
            }
        }

        public static void SetupUserData()
        {
            if (Queries.Count == 0)
                return;

            string rawUserData = string.Empty;
            try
            {
                rawUserData = Queries["user"];
            }
            finally
            {
                if (!string.IsNullOrEmpty(rawUserData))
                {
                    UserData = JsonConvert.DeserializeObject<TelegramUserData>(rawUserData);
                }
            }
        }
    }

    [Serializable]
    public class TelegramUserData
    {
        [JsonProperty("id")]
        public long ID { get; set; } = -1;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("language_code")]
        public string LaunguageCode { get; set; } = string.Empty;
    }
}