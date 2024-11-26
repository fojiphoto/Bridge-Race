using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloder : MonoBehaviour
{
    //int levelNumber;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LevelBrgs"))
        {
            PlayerPrefs.SetInt("LevelBrgs", 2);
        }
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        if (!PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", 100);
        }
        if (!PlayerPrefs.HasKey("sounds"))
        {
            PlayerPrefs.SetInt("sounds", 1);
            PlayerPrefs.SetInt("music", 1);
            PlayerPrefs.SetInt("vibrate", 1);
        }
        Invoke(nameof(Load), 12f);
        //AdsManager.Instance.ShowAdMobBanner();
    }

    public void Load()
    {
        SceneManager.LoadSceneAsync(2);
        //if (PlayerPrefs.GetInt("LevelBrgs")<=11)
        //{
        //    SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("LevelBrgs"));
        //}
        //else
        //{
        //    SceneManager.LoadSceneAsync(12);
        //}
       
       
    }


}
