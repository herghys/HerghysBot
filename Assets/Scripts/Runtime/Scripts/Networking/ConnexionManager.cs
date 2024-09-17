using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Asynkrone.UnityTelegramGame.Security;

namespace Asynkrone.UnityTelegramGame.Networking
{
    public class ConnexionManager : MonoBehaviour
    {
        private IObfuscation obfuscation;

        public string Url = "";
        public string playerId = "";
        private bool dontSend = false;

        public void RetriveURLAndID()
        {
            try
            {
                Url = URLParameters.location_hostname();

            }
            catch
            {
                Debug.LogError("URL");
            }

            try
            {
                playerId = URLParameters.GetSearchParameters()["id"];

            }
            catch
            {
                Debug.LogError("ID");
            }
        }

        /*void Start()
        {
            obfuscation = new BasicObfuscation(SCORE_TOKEN);

#if UNITY_EDITOR
            dontSend = true;
#elif UNITY_WEBGL
        // The telegram game is launched with the player id as parameter 
        playerId = URLParameters.GetSearchParameters()["id"];
        // Debug.Log("Got playerId: " + playerId);
#endif
        }*/


        /*public void SendScore(int score)
        {
            StartCoroutine(SendScoreCor(score));
        }
        IEnumerator SendScoreCor(int score)
        {
            // Debug.Log("Asked score: " + score.ToString());

            if (dontSend || playerId == "") yield break;

            long obfuscatedScore = obfuscation.Obfuscate(long.Parse(playerId), score);

            string uri = serverURI + obfuscatedScore.ToString() + "?id=" + playerId;
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                        Debug.LogError("Error sending score: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError("Error sending score: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError("Error sending score: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log("Success sending score");
                        break;
                }
            }
        }*/
    }
}