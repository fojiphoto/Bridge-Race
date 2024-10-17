using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColiider : MonoBehaviour
{
    public Collider playerCollider; // Apna collider assign karein
    private float previousZPosition; // Pehle Z position ko store karne ke liye
    void Start()
    {
        // Initial Z position set karein
        previousZPosition = transform.position.z;
    }

    void Update()
    {
        // Current Z position
        float currentZPosition = transform.position.z;

        // Z position ko check karna
        if (currentZPosition > previousZPosition)
        {
            // Z position increase ho rahi hai, collider ko enable karein
            playerCollider.enabled = true;
        }
        else if (currentZPosition < previousZPosition)
        {
            // Z position decrease ho rahi hai, collider ko disable karein
            playerCollider.enabled = false;
        }

        // Current Z position ko update karein
        previousZPosition = currentZPosition;
    }

}
