using UnityEngine;
using System.Collections;
using System.Text;

public class Web : MonoBehaviour {

    private PlayerInfo player;
    private string json;

    void Start()
    {
        player = new PlayerInfo();
        StartCoroutine(UploadJSON());
    }

    IEnumerator UploadJSON()
    {
        string url = "https://apps.tlt.stonybrook.edu/SIMPLE_dev/resources/injest.php";
        WWWForm form = new WWWForm();
        json = player.SaveToString();
        form.AddBinaryData("json", Encoding.ASCII.GetBytes(json), "unityJson.txt");
        Debug.Log(form.data[0]);
        WWW www = new WWW(url, form);

        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
        }
        else
        {
            print("Finished Uploading JSON");
        }

        Debug.Log(www);
    }
}
