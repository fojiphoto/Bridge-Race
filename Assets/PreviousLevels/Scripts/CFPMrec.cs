using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFPMrec : MonoBehaviour
{
    private void OnEnable() {
        //Nadeem Ads
        AdsManager.instance.ShowMRec();
        Debug.Log("Mrec showing");
        //CASAds.instance.ShowMrecBanner(CAS.AdPosition.TopLeft);
        // AdsManager.instance.ShowMRec();
    }

    private void OnDisable() {
        //Nadeem Ads
        AdsManager.instance.HideMRec();
        Debug.Log("Mrec hide");
        //CASAds.instance.HideMrecBanner();
        // AdsManager.instance.HideMRec();
    }
}
