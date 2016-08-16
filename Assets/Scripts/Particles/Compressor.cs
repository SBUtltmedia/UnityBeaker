using UnityEngine;
using System.Collections;

public class Compressor : MonoBehaviour {

    private Collider2D col;

	void Start () {
        col = GetComponent<Collider2D>();
        col.enabled = false;
	}

    public bool IsEnabled()
    {
        return col.enabled;
    }

    public void Enable(Vector3 position)
    {
        transform.position = position;
        col.enabled = true;
    }

    public void Disable()
    {
        col.enabled = false;
    }
}
