using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public int lives;
    public float health;

    public PlayerInfo()
    {
        name = "Coconut Gun";
        lives = 3;
        health = 10;
    }

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f
}
