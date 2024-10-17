using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    int RewardX;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "2X")
        {
            RewardX = 2;
            PlayerPrefs.SetInt("RewardX", RewardX);
        }

        if (col.gameObject.CompareTag("3X"))
        {
            RewardX = 3;
            PlayerPrefs.SetInt("RewardX", RewardX);
        }

        if (col.gameObject.CompareTag("5X"))
        {
            RewardX = 5;
            PlayerPrefs.SetInt("RewardX", RewardX);
        }
    }
}
