using UnityEngine;
using System.Collections;

public class PlayerInfoManager : MonoBehaviour {

    private PlayerInfo playerInfo;
    private float saveDelay = 5.0f;
    private float saveTimer;

	void Start () {
        StartCoroutine(GetPlayerInfoFromServer());
        saveTimer = saveDelay;
    }

    void Update()
    {
        saveTimer -= Time.deltaTime;

        if (playerInfo != null && saveTimer <= 0.0f)
        {
            playerInfo.setNumOfDroppedParticles(ParticleDestroyer.counter);
            StartCoroutine(SavePlayerInfoToServer(playerInfo));
            saveTimer = saveDelay;
        }
    }

    IEnumerator GetPlayerInfoFromServer()
    {
        WWW www = new WWW("https://apps.tlt.stonybrook.edu/UnityBeaker/getJSON.php");
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
            StartCoroutine(GetNetID());
        }
        else
        {
            playerInfo = PlayerInfo.CreateFromJSON(www.text);
            ParticleDestroyer.LoadCounter(playerInfo.getNumOfDroppedParticles());
            print("Sucessfully loaded Player Info from JSON");
        }
    }

    IEnumerator GetNetID()
    {
        WWW www = new WWW("https://apps.tlt.stonybrook.edu/UnityBeaker/netID.php");
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            print(www.text);
            playerInfo = new PlayerInfo(www.text);
            StartCoroutine(SavePlayerInfoToServer(playerInfo));
        }
    }

    IEnumerator SavePlayerInfoToServer(PlayerInfo player)
    {
        string url = "https://apps.tlt.stonybrook.edu/UnityBeaker/ingest.php";
        WWWForm form = new WWWForm();
        form.AddField("json", player.SaveToJSON());
        WWW www = new WWW(url, form);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            print("Finished Saving Player Info");
        }
    }
}
