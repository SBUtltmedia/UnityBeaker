using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    private Text droppedParticles;

	void Start () {
        droppedParticles = GameObject.Find("DroppedParticleCount").GetComponent<Text>();
	}
	
	public void UpdateDroppedParticleDisplay(int numOfParticles)
    {
        if (numOfParticles < 10)
        {
            droppedParticles.text = "00" + numOfParticles;
        }
        else if (numOfParticles < 100)
        {
            droppedParticles.text = "0" + numOfParticles;
        }
        else
        {
            droppedParticles.text = numOfParticles.ToString();
        }
    }
}
