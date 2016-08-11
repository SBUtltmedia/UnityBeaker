using UnityEngine;
using System.Collections.Generic;

public class ParticleConsumer : MonoBehaviour {

    //public List<GameObject> particles;
    private PolyGrow polygon;

    void Start()
    {
        polygon = FindObjectOfType<PolyGrow>();
        //particles = new List<GameObject>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DynamicParticle"))
        {
            if (other.gameObject.name != "WaterLevel")
            {
                Destroy(other.gameObject);
                polygon.ConsumeParticle();
                transform.position = new Vector3(transform.position.x, transform.position.y + (polygon.GetTargetMaxY() / 250.0f), transform.position.z);
            }
        }
    }
}
