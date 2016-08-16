using UnityEngine;
using System.Collections;
/// <summary
/// Particle generator.
/// 
/// The particle generator simply spawns particles with custom values. 
/// See the Dynamic particle script to know how each particle works..
/// 
/// Visit: www.codeartist.mx for more stuff. Thanks for checking out this example.
/// Credit: Rodrigo Fernandez Diaz
/// Contact: q_layer@hotmail.com
/// </summary>

// Modified by Michael Witkovsky for TLT Media Lab

public class ParticleGenerator : MonoBehaviour
{
    public GameObject flask;
    public Vector3 particleForce; //Is there a initial force particles should have?
    public DynamicParticle.STATES particlesState = DynamicParticle.STATES.WATER; // The state of the particles spawned
    public Transform particlesParent; // Where will the spawned particles will be parented (To avoid covering the whole inspector with them)
    public int numberOfParticles; //Number of particles to spawn before dying
    public float SPAWN_INTERVAL = 0.025f; // How much time until the next particle spawns

    private Compressor compressor;

    void Start() {
        compressor = FindObjectOfType<Compressor>();
        //Tries to catch if the particlesParent transform is never set in the editor
        if (!particlesParent)
        {
            particlesParent = GameObject.Find("LiquidParticles").transform;
            if (!particlesParent)
                particlesParent = transform.parent;
            if (!particlesParent)
                particlesParent = transform;
        }

        if (!flask)
        {
            flask = FindObjectOfType<FlaskController>().gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            compressor.Disable();
            GameObject newLiquidParticle = (GameObject)Instantiate(Resources.Load(ResourceDirectories.DynamicParticle)); //Spawn a particle
            newLiquidParticle.GetComponent<Rigidbody2D>().AddForce(particleForce); //Add our custom force
            DynamicParticle particleScript = newLiquidParticle.GetComponent<DynamicParticle>(); // Get the particle script
            particleScript.SetState(particlesState); //Set the particle State
            newLiquidParticle.transform.position = transform.position;// Relocate to the spawner position
            newLiquidParticle.transform.parent = particlesParent;// Add the particle to the parent container		
        }

        //Old method by setting number of particles
        /*
        if (lastSpawnTime + SPAWN_INTERVAL < Time.time && numberOfParticles > 0)
        { // Is it time already for spawning a new particle?
            GameObject newLiquidParticle = (GameObject)Instantiate(Resources.Load(ResourceDirectories.DynamicParticle)); //Spawn a particle
            newLiquidParticle.GetComponent<Rigidbody2D>().AddForce(particleForce); //Add our custom force
            DynamicParticle particleScript = newLiquidParticle.GetComponent<DynamicParticle>(); // Get the particle script
            particleScript.SetState(particlesState); //Set the particle State
            newLiquidParticle.transform.position = transform.position;// Relocate to the spawner position
            newLiquidParticle.transform.parent = particlesParent;// Add the particle to the parent container			
            lastSpawnTime = Time.time; // Register the last spawnTime	
            --numberOfParticles;		
        }
        else if(numberOfParticles <= 0)
        {
            gameObject.SetActive(false);
        }
        */
    }
}
