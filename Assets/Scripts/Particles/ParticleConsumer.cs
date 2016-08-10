using UnityEngine;
using System.Collections.Generic;

public class ParticleConsumer : MonoBehaviour {

    private List<GameObject> particles;
    private PolyGrow polygon;

    void Start()
    {
        polygon = FindObjectOfType<PolyGrow>();
        particles = new List<GameObject>();
    }

    void Update()
    {
        if(particles.Count > 10)
        {
            particles.RemoveAt(0);
            polygon.ConsumeParticle();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(gameObject);
        if (other.gameObject.CompareTag("DynamicParticle"))
        {
            print(gameObject);
            if (other.gameObject.name != "WaterLevel")
            {
                particles.Add(other.gameObject);
            }
        }
    }
}
