using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesParticles : MonoBehaviour
{
    // Reference to the particle system prefab
    public GameObject particleSystemPrefab;
    void Start()
    {
        //StartCoroutine(AssignParticleSystemAfterDelay(0.5f));
        //Invoke("Assign_color", 1f);
        //Assign_color();
    }
    public void Assign_color()
    {
        // Find all objects with tag "cube"
        GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("cude");

        foreach (GameObject cube in cubeObjects)
        {
            // Get the color of the cube
            Color cubeColor = cube.GetComponent<MeshRenderer>().material.color;

            // Instantiate the particle system prefab
            GameObject particleSystemInstance = Instantiate(particleSystemPrefab, cube.transform);

            // Get the ParticleSystem component
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();

            // Change the particle system color over lifetime to match the cube color
            var colorOverLifetime = particleSystem.colorOverLifetime;
            colorOverLifetime.enabled = true;

            // Create a gradient with the cube color
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(cubeColor, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );

            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);

            // Optionally adjust the position of the particle system
            particleSystemInstance.transform.localPosition = Vector3.zero; // Adjust as needed
        }
    }
}
