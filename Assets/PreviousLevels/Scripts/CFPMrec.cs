using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFPMrec : MonoBehaviour
{
    private void OnEnable() {
        CASAds.instance.ShowMrecBanner(CAS.AdPosition.TopLeft);
       // AdsManager.instance.ShowMRec();
    }

    private void OnDisable() {
        CASAds.instance.HideMrecBanner();
        // AdsManager.instance.HideMRec();
    }
}
