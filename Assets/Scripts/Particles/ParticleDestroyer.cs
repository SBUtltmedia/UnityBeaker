using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {

    public static int counter = 0;

    private UIManager ui;
    private static bool counterChanged;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (counterChanged)
        {
            UpdateUIOnLoad();
            counterChanged = false;
        }
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DynamicParticle"))
        {
            FlaskController.RemoveParticleFromList(other.gameObject.GetComponent<DynamicParticle>());
            Destroy(other.gameObject);
            ui.UpdateDroppedParticleDisplay(++counter);
        }
    }

    public static void LoadCounter(int counter)
    {
        ParticleDestroyer.counter = counter;
        counterChanged = true;
    }

    //helper for LoadCounter
    private void UpdateUIOnLoad()
    {
        ui.UpdateDroppedParticleDisplay(counter);
    }
}
