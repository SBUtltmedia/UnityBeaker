using UnityEngine;
using System.Collections.Generic;

public class FlaskController : MonoBehaviour {

    public float translateSpeed, rotateSpeed;
    public float compressDelay;
    public float minX = -5.0f;
    public float maxX = 0.45f;
    public float minY = 0.95f;
    public float maxY = 2.0f;

    private static List<DynamicParticle> particles;
    private Compressor compressor;
    private Vector3 totalTranslate;
    private float compressTimer;
    private bool up, down, left, right, rotateLeft, rotateRight, wasInput;

    void Start()
    {
        particles = new List<DynamicParticle>();
        compressor = FindObjectOfType<Compressor>();
        compressTimer = compressDelay;
        totalTranslate = Vector3.zero;
    }

	void Update () {
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        rotateLeft = Input.GetKey(KeyCode.A);
        rotateRight = Input.GetKey(KeyCode.D);
        wasInput = up || down || left || right || rotateLeft || rotateRight;

        if (Input.GetKey(KeyCode.S))
        {
            compressTimer = compressDelay;
        }
    }

    void FixedUpdate()
    {
        totalTranslate = Vector3.zero;

        if (up)
        {
            totalTranslate += Vector3.up * translateSpeed * Time.fixedDeltaTime;
        }

        if (down)
        {
            totalTranslate += Vector3.down * translateSpeed * Time.fixedDeltaTime;
        }

        if (left)
        {
            totalTranslate += Vector3.left * translateSpeed * Time.fixedDeltaTime;
        }

        if (right)
        {
            totalTranslate += Vector3.right * translateSpeed * Time.fixedDeltaTime;
        }

        if (rotateLeft)
        {
            transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.fixedDeltaTime);
        }

        if (rotateRight)
        {
            transform.Rotate(0.0f, 0.0f, rotateSpeed * -Time.fixedDeltaTime);
        }

        //Catching out of bounds translations and stopping them
        if(!IsBetween(minX, maxX, transform.position.x + totalTranslate.x))
        {
            if(totalTranslate.x > 0.0f)
            {
                totalTranslate.x = maxX - transform.position.x;
            }
            else
            {
                totalTranslate.x = minX - transform.position.x;
            }
        }

        if (!IsBetween(minY, maxY, transform.position.y + totalTranslate.y))
        {
            if (totalTranslate.y > 0.0f)
            {
                totalTranslate.y = maxY - transform.position.y;
            }
            else
            {
                totalTranslate.y = minY - transform.position.y;
            }
        }

        if (wasInput)
        {
            compressor.Disable();
            compressTimer = compressDelay;
            //move all the particles inside the beaker still
            foreach (DynamicParticle p in particles)
            {
                try
                {
                    p.transform.Translate(totalTranslate, Space.World);
                    if (totalTranslate != Vector3.zero || (rotateRight || rotateLeft))
                    {
                        p.ResetJostleTimer();
                    }
                }
                catch
                {
                    particles.Remove(p);
                }
            }

            transform.Translate(totalTranslate, Space.World);
        }
        else
        {
            if (!compressor.IsEnabled() && compressTimer < 0.0f && !Input.GetKey(KeyCode.S))
            {
                //spawn compressor at water level
                Vector3 position = transform.position;
                position.y -= 500.0f;
                foreach (DynamicParticle p in particles)
                {
                    if(position.y < p.transform.position.y)
                    {
                        position.y = p.transform.position.y;
                    }
                }
                position.y += 0.65f;
                compressor.Enable(position);
            }
            else
            {
                compressTimer -= Time.deltaTime;
            }   
        }
    }

    public void AddParticleToList(DynamicParticle particle)
    {
        particles.Add(particle);
    }

    public static void RemoveParticleFromList(DynamicParticle particle)
    {
        particles.Remove(particle);
    }

    bool IsBetween(float lo, float hi, float x)
    {
        return (x >= lo && x <= hi);
    }
}
