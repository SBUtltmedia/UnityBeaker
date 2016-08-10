using UnityEngine;
using System.Collections;
/// <summary>
/// Dynamic particle.
/// 
/// The dynamic particle is the backbone of the liquids effect. Its a circle with physics with 3 states, each state change its physic properties and its sprite color ( so the shader can separate wich particle is it to draw)
/// The particles scale down and die, and have a scale  effect towards their velocity.
/// 
/// Visit: www.codeartist.mx for more stuff. Thanks for checking out this example.
/// Credit: Rodrigo Fernandez Diaz
/// Contact: q_layer@hotmail.com
/// </summary>

// Modified by Michael Witkovsky for TLT Media Lab

public class DynamicParticle : MonoBehaviour
{
    public enum STATES { WATER, GAS, LAVA, NONE }; //The 3 states of the particle
    STATES currentState = STATES.NONE; //Defines the currentstate of the particle, default is water
    public GameObject currentImage; //The image is for the metaball shader for the effect, it is onle seen by the liquids camera.
    public GameObject[] particleImages; //We need multiple particle images to reduce drawcalls
    float GAS_FLOATABILITY = 7.0f; //How fast does the gas goes up?

    private Rigidbody2D rb;
    private float jostleTime = 0.0f;
    private float jostleTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        if (currentState == STATES.NONE)
            SetState(STATES.WATER);
    }

    //The definitios to each state
    public void SetState(STATES newState)
    {
        if (newState != currentState)
        { //Only change to a different state
            switch (newState)
            {
                case STATES.WATER:
                    GetComponent<Rigidbody2D>().gravityScale = 1.0f; // To simulate Water density
                    break;
                case STATES.GAS:
                    GetComponent<Rigidbody2D>().gravityScale = 0.0f;// To simulate Gas density
                    gameObject.layer = LayerMask.NameToLayer("Gas");// To have a different collision layer than the other particles (so gas doesnt rises up the lava but still collides with the wolrd)
                    break;
                case STATES.LAVA:
                    GetComponent<Rigidbody2D>().gravityScale = 1.0f; // To simulate the lava density
                    break;
                case STATES.NONE:
                    Destroy(gameObject);
                    break;
            }
            if (newState != STATES.NONE)
            {
                currentState = newState;
                GetComponent<Rigidbody2D>().velocity = new Vector2();   // Reset the particle velocity	
                currentImage.SetActive(false);
                currentImage = particleImages[(int)currentState];
                currentImage.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case STATES.WATER: //Water and lava got the same behaviour
                MovementAnimation();
                break;
            case STATES.LAVA:
                MovementAnimation();
                break;
            case STATES.GAS:
                if (rb.velocity.y < 50)
                { //Limits the speed in Y to avoid reaching mach 7 in speed
                    rb.AddForce(new Vector2(0, GAS_FLOATABILITY)); // Gas always goes upwards
                }
                break;

        }
    }

    // This scales the particle image acording to its velocity, so it looks like its deformable... but its not ;)
    void MovementAnimation()
    {
        Vector3 movementScale = new Vector3(1.0f, 1.0f, 1.0f);	
        movementScale.x += Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) / 30.0f;
        movementScale.z += Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) / 30.0f;
        movementScale.y = 1.0f;
        currentImage.gameObject.transform.localScale = movementScale;
        //Adds a random force left or right to flatten the water level
        if (jostleTimer > 0.0f)
        {
            rb.AddForce(new Vector2(Mathf.Lerp(-10.0f, 10.0f, Random.Range(0.0f, 1.0f)), 0));
            jostleTimer -= Time.fixedDeltaTime;
        }
        else
        {
            rb.AddForce(new Vector2(Mathf.Lerp(-2.0f, 2.0f, Random.Range(0.0f, 1.0f)), 0));
        }
    }

    // Here we handle the collision events with another particles, in this example water+lava= water-> gas
    void OnCollisionEnter2D(Collision2D other)
    {
        if (currentState == STATES.WATER && other.gameObject.tag == "DynamicParticle")
        {
            if (other.collider.GetComponent<DynamicParticle>().currentState == STATES.LAVA)
            {
                SetState(STATES.GAS);
            }
        }

    }

    public void ResetJostleTimer()
    {
        jostleTimer = jostleTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Flask"))
        {
            collider.gameObject.GetComponent<FlaskController>().AddParticleToList(this);
        }

        if (collider.gameObject.CompareTag("Beaker"))
        {
            ResetJostleTimer();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Flask"))
        {
            collider.gameObject.GetComponent<FlaskController>().RemoveParticleFromList(this);
        }
    }

    public void SetAsleep()
    {
        rb.Sleep();
    }

    public void WakeUp()
    {
        rb.WakeUp();
    }
}
