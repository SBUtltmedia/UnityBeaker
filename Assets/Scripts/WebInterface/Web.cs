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
        StartCoroutine(UploadJSON1());
        StartCoroutine(UploadJSON2());
    }

    IEnumerator UploadJSON()
    {
        string url = "https://apps.tlt.stonybrook.edu/UnityBeaker/injest.php";
        WWWForm form = new WWWForm();
        json = player.SaveToString();
        form.AddField("json", json);
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

    IEnumerator UploadJSON1()
    {
        string url = "../injest.php";
        WWWForm form = new WWWForm();
        json = player.SaveToString();
        form.AddField("json", json);
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

    IEnumerator UploadJSON2()
    {
        string url = "../../injest.php";
        WWWForm form = new WWWForm();
        json = player.SaveToString();
        form.AddField("json", json);
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
