using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyBridge : MonoBehaviour
{
    public int totalicangive;
    public int count;
    public List<GameObject> colorgivento;
    public void thisBridggingRacechar(GameObject a)
    {
        count++;
        colorgivento.Add(a);
        Debug.Log("count...." + count);
        if (totalicangive == count)
        {
            // cameramovr_Bridge.Instance.BrgR_eliminater(colorgivento);
            NewCameraDeemBridge.Instance.BrgR_eliminater(colorgivento);
        }
    }
}
