using UnityEngine;
using System.Collections;

public class PolyGrow : MonoBehaviour {

    public GameObject topParticles;

    public float targetMaxY = 2.15f;
    private int count = 0;
	
    void Start()
    {
        topParticles.SetActive(false);
    }

	public void ConsumeParticle()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (targetMaxY / 250.0f), transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + (targetMaxY / 500.0f), transform.position.z);
        
        if(++count == 10)
        {
            topParticles.SetActive(true);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - (10.0f*targetMaxY / 250.0f), transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - (10.0f*targetMaxY / 500.0f), transform.position.z);
        }
    }

    public float GetTargetMaxY()
    {
        return targetMaxY;
    }
}
