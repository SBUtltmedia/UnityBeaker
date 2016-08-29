using UnityEngine;
using System.Collections;

public class PolyGrow : MonoBehaviour {

    public GameObject topParticles;

    public float targetMaxY = 2.15f;
    public int firstTheshold = 20;
    public int maxParticles;
    public int count = 0;

    public void ConsumeParticle()
    {
        if (++count < maxParticles)
        {
            if (count > firstTheshold)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (targetMaxY / 250.0f), transform.localScale.z);
                transform.position = new Vector3(transform.position.x, transform.position.y + (targetMaxY / 500.0f), transform.position.z);
            }
            else
            {
                topParticles.transform.localScale = new Vector3(topParticles.transform.localScale.x + (0.25f / firstTheshold), topParticles.transform.localScale.y + (1.0f / firstTheshold), topParticles.transform.localScale.z);
            }
        }
        else
        {
            WaterPusher.Activate();
        }
    }

    public float GetTargetMaxY()
    {
        return targetMaxY;
    }

    public int GetNumberOfParticles()
    {
        return count;
    }

    public bool CanConsumeParticle()
    {
        return count < maxParticles;
    }
}
