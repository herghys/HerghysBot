using Asynkrone.UnityTelegramGame.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text urlText;
    [SerializeField] private Text idText;
    [SerializeField] private ConnexionManager telegramConnexionManager;

    [SerializeField] private int score;

    public void GetURLAndID()
    {
        telegramConnexionManager.RetriveURLAndID();

        urlText.text = telegramConnexionManager.Url;
        idText.text = telegramConnexionManager.playerId;
    }
}
