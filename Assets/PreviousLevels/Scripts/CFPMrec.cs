using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFPMrec : MonoBehaviour
{
    private void OnEnable() {
        //Nadeem Ads
        //CASAds.instance.ShowMrecBanner(CAS.AdPosition.TopLeft);
        // AdsManager.instance.ShowMRec();
    }

    private void OnDisable() {
        //Nadeem Ads
        //CASAds.instance.HideMrecBanner();
        // AdsManager.instance.HideMRec();
    }
}
