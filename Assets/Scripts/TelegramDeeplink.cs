using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TelegramDeeplink : MonoBehaviour
{
    public Text longText;
    public Text shortText;


    private string botToken = "7542654083:AAEeKfNSGsBxt7vI1rDG2PEf3X7g_eVlmyI";
    private string apiUrl = "https://api.telegram.org/bot";

    private void Start()
    {
        GetUpdates();
    }

    IEnumerator GetUpdates()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl+botToken+"/getUpdates");
        yield return request.SendWebRequest();

        if (request.result==UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;

            longText.text=jsonResponse;

            Debug.Log("Received Telegram Response: "+jsonResponse);

            HandleTelegramMessage(jsonResponse);
        }
        else
        {
            Debug.Log("Error: "+request.error);
        }
    }

    void HandleTelegramMessage(string jsonResponse)
    {
        // Parse the response to get the message
        var telegramUpdate = JsonUtility.FromJson<TelegramUpdate>(jsonResponse);

        // Check if it’s a start command with parameters
        if (telegramUpdate.message.text.StartsWith("/start"))
        {
            // Extract the parameter (custom data)
            string[] parts = telegramUpdate.message.text.Split(' ');
            if (parts.Length>1)
            {
                string startAppParameter = parts[1];  // This will be 'startApp=1234'
                Debug.Log("StartApp Parameter: "+startAppParameter);
                shortText.text=startAppParameter;
            }
        }
    }
}

[System.Serializable]
public class TelegramUpdate
{
    public Message message;
}

[System.Serializable]
public class Message
{
    public string text;
}
