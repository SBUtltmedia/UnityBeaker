using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string netID;
    public int numOfDroppedParticles;

    public PlayerInfo(string netID)
    {
        this.netID = netID;
        numOfDroppedParticles = 0;
    }

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }

    public string SaveToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
