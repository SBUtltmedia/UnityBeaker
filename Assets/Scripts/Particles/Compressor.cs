using UnityEngine;
using System.Collections;

public class Compressor : MonoBehaviour {

    private Collider2D col;
    private float descentDistance = 0.2f;
    private float descentCounter;
    private float descentSpeed = 1.0f;

	void Start () {
        col = GetComponent<Collider2D>();
        col.enabled = false;
	}

    void FixedUpdate()
    {
        if(descentCounter > 0.0f)
        {
            transform.Translate(Vector3.down * descentSpeed * Time.fixedDeltaTime);
            descentCounter -= descentSpeed * Time.fixedDeltaTime;
        }
    }

    public bool IsEnabled()
    {
        return col.enabled;
    }

    public void Enable(Vector3 position)
    {
        descentCounter = descentDistance;
        transform.position = position;
        col.enabled = true;
    }

    public void Disable()
    {
        col.enabled = false;
    }
}
