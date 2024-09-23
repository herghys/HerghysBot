using Herghys.Telegram.WebGL;

using UnityEngine;
using UnityEngine.UI;

using Telegram = Herghys.Telegram.WebGL.TelegramWebGLHelper;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text urlText;
    [SerializeField] private Text idText;

    public void GetURLAndID()
    {
        urlText.text = Telegram.URL;
        idText.text = $"user:{Telegram.UserData.Username} - ID:{Telegram.UserData.ID} - First:{Telegram.UserData.FirstName}";
    }
}