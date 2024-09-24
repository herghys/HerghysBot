using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Herghys.Telegram.WebGL
{
    public class TelegramController : ThemeController
    {
        public Text rawDataText;

        public void RequestUserData()
        {
            var textData = TelegramWebGLLib.request_user_data();
            Debug.Log(textData);

            rawDataText.text=textData;
        }
    }
}


[Serializable]
public class WebAppUser
{
    public int id;
    public bool is_bot;
    public string first_name;
    public string last_name;
    public string username;
    public string language_code;
    public bool is_premium;
    public bool added_to_attachment_menu;
    public bool allows_write_to_pm;
    public string photo_url;
}