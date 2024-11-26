using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AppOpenAdDisplayHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Text;

    // [SerializeField] private bool m_CanShowAppOpenAd => AdmobImplementation.CanAppOpenShow;

    private void OnApplicationFocus(bool pauseStatus)
    {
        if (pauseStatus & CASAds.CanAppOpenShow)
        {
            Debug.LogError("Showing App Open");
            Invoke(nameof(ShowAppOpen), 0.5f);
        }
        //m_Text.text = pauseStatus ? "Came From Focus" : "None";

        Debug.LogError(pauseStatus ? "Came From Focus" + CASAds.CanAppOpenShow : "None" + CASAds.CanAppOpenShow);
    }

    void ShowAppOpen() 
    {
        if (CASAds.CanAppOpenShow)
        {
            CASAds.instance.ShowAppOpen();
        }
    }
}
