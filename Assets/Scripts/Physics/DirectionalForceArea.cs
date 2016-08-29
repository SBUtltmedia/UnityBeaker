using UnityEngine;
using System.Collections;

public class DirectionalForceArea : MonoBehaviour {

    [SerializeField]
    private float xForce, yForce;
    public Vector3 force;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        force = (Vector3.right * xForce) + (Vector3.up * yForce);
    }

	void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DynamicParticle"))
        {
            if (other.gameObject.name != "WaterLevel")
            {
                other.GetComponent<Rigidbody2D>().AddForce(force);
            }
        }
    }
}
