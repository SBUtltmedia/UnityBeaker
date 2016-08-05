using UnityEngine;
using System.Collections.Generic;

public class FlaskController : MonoBehaviour {

    public float translateSpeed, rotateSpeed;

    private List<DynamicParticle> particles;
    private Vector3 totalTranslate;
    private bool up, down, left, right, rotateLeft, rotateRight, rotate, didRotate;

    void Start()
    {
        particles = new List<DynamicParticle>();
        totalTranslate = Vector3.zero;
    }

	void Update () {
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        rotateLeft = Input.GetKey(KeyCode.A);
        rotateRight = Input.GetKey(KeyCode.D);
        rotate = rotateLeft || rotateRight;
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

        if (false)
        {
            if (rotate)
            {
                if (!didRotate && IsBetween(70.0f, 90.0f, Mathf.Abs(transform.rotation.z)))
                {
                    foreach (DynamicParticle p in particles)
                    {
                        p.SetGravityScale(0.5f);
                    }
                }

                if (rotateLeft)
                {
                    transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.fixedDeltaTime);
                }

                if (rotateRight)
                {
                    transform.Rotate(0.0f, 0.0f, rotateSpeed * -Time.fixedDeltaTime);
                }

                didRotate = true;
            }
            else if (didRotate)
            {
                foreach (DynamicParticle p in particles)
                {
                    p.SetGravityScale(1.0f);
                }
                didRotate = false;
            }
        }
        else
        {
            if (rotateLeft)
            {
                transform.Rotate(0.0f, 0.0f, rotateSpeed * Time.fixedDeltaTime);
            }

            if (rotateRight)
            {
                transform.Rotate(0.0f, 0.0f, rotateSpeed * -Time.fixedDeltaTime);
            }

            foreach (DynamicParticle p in particles)
            {
                p.transform.Translate(totalTranslate, Space.World);
                p.ResetJostleTimer();
            }
        }

        transform.Translate(totalTranslate, Space.World);
    }

    public void AddParticleToList(DynamicParticle particle)
    {
        particles.Add(particle);
    }

    public void RemoveParticleFromList(DynamicParticle particle)
    {
        particles.Remove(particle);
    }

    bool IsBetween(float lo, float hi, float x)
    {
        return (x >= lo && x <= hi);
    }
}
