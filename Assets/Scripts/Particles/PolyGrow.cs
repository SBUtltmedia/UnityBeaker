using UnityEngine;
using System.Collections;

public class PolyGrow : MonoBehaviour {

    public GameObject topParticles;

    public float targetMaxY = 2.15f;
    public int firstTheshold = 20;
    private int count = 0;

	public void ConsumeParticle()
    {        
        if(++count > firstTheshold)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (targetMaxY / 250.0f), transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + (targetMaxY / 500.0f), transform.position.z);
        }
        else
        {
            topParticles.transform.localScale = new Vector3(topParticles.transform.localScale.x + (0.25f / firstTheshold), topParticles.transform.localScale.y + (1.0f / firstTheshold), topParticles.transform.localScale.z);
        }
    }

    public float GetTargetMaxY()
    {
        return targetMaxY;
    }
}
