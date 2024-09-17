using System;
using System.Collections.Generic;

using Asynkrone.UnityTelegramGame.Networking;

using Newtonsoft.Json;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text urlText;
    [SerializeField] private Text idText;

    Dictionary<string, string> Queries = new Dictionary<string, string>();

    public void GetURLAndID()
    {
        string raw = string.Empty;
        string rawURL = string.Empty;
        try
        {
            raw = URLParameters.location_href();

            while (raw.Contains("%"))
            {
                raw = Uri.UnescapeDataString(raw);
            }
            rawURL = Uri.UnescapeDataString(raw);
        }
        catch { }
        finally
        {
            urlText.text = rawURL;
        }

        //Split Queries
        try
        {
            var queries = rawURL.Split('&');
            foreach (var query in queries)
            {
                var pair = query.Split('=');
                Queries.Add(pair[0], pair[1]);
            }
        }
        catch { }

        //Set Username
        string userDataJSON = string.Empty;
        UserData userData = new();
        try
        {
            userDataJSON = Queries["user"];
            userData = JsonConvert.DeserializeObject<UserData>(userDataJSON);
        }
        catch { }
        finally
        {

            idText.text = $"user:{userData.Username} - ID:{userData.ID} - First:{userData.FirstName}";
        }
    }
}

[Serializable]
public class UserData
{
    [JsonProperty("id")]
    public int ID { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("language_code")]
    public string LaunguageCode { get; set; }
}