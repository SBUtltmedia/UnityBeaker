using UnityEngine;
using System.Collections.Generic;

public class FlaskController : MonoBehaviour {

    public float translateSpeed;

    public List<DynamicParticle> particles;
    private bool up, down, left, right, rotateLeft, rotateRight;

    void Start()
    {
        particles = new List<DynamicParticle>();
    }

	void Update () {
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        rotateLeft = Input.GetKey(KeyCode.A);
        rotateRight = Input.GetKey(KeyCode.D);
	}

    void FixedUpdate()
    {
        if (up)
        {
            transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.World);
            foreach (DynamicParticle p in particles)
            {
                p.transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.World);
                p.ResetJostleTimer();
            }
        }

        if (down)
        {
            transform.Translate(Vector3.down * translateSpeed * Time.deltaTime, Space.World);
            foreach (DynamicParticle p in particles)
            {
                p.transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.World);
                p.ResetJostleTimer();
            }
        }

        if (left)
        {
            transform.Translate(Vector3.left * translateSpeed * Time.deltaTime, Space.World);
            foreach (DynamicParticle p in particles)
            {
                p.transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.World);
                p.ResetJostleTimer();
            }
        }

        if (right)
        {
            transform.Translate(Vector3.right * translateSpeed * Time.deltaTime, Space.World);
            foreach (DynamicParticle p in particles)
            {
                p.transform.Translate(Vector3.up * translateSpeed * Time.deltaTime, Space.World);
                p.ResetJostleTimer();
            }
        }

        if (rotateLeft)
        {
            transform.Rotate(0.0f, 0.0f, 1.0f);
        }

        if (rotateRight)
        {
            transform.Rotate(0.0f, 0.0f, -1.0f);
        }
    }

    public void AddParticleToList(DynamicParticle particle)
    {
        particles.Add(particle);
    }

    public void RemoveParticleFromList(DynamicParticle particle)
    {
        particles.Remove(particle);
    }
}
