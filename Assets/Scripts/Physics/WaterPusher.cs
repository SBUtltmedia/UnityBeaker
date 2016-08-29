using UnityEngine;
using System.Collections;

public class WaterPusher : MonoBehaviour {

    private static DirectionalForceArea left, right;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Left")
            {
                left = child.gameObject.GetComponent<DirectionalForceArea>();
            }
            else if (child.name == "Right")
            {
                right = child.gameObject.GetComponent<DirectionalForceArea>();
            }
        }
    }

    public static void Activate()
    {
        if (left)
        {
            left.gameObject.SetActive(true);
        }
        
        if (right)
        {
            right.gameObject.SetActive(true);
        }
    }
}
