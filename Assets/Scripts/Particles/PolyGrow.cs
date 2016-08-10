using UnityEngine;
using System.Collections;

public class PolyGrow : MonoBehaviour {

    public float targetMaxY = 2.25f;
	
	public void ConsumeParticle()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (targetMaxY / 250.0f), transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + (targetMaxY / 500.0f), transform.position.z);
    }
}
