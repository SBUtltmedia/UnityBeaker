using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {

    private UIManager ui;
    private int counter = 0;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DynamicParticle"))
        {
            Destroy(other.gameObject);
            ui.UpdateDroppedParticleDisplay(++counter);
        }
    }
}
