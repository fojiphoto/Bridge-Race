using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//using TurnTheGameOn.Timer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
    public GameObject WinPanel;
    public GameObject LossPanel;
    public Button Next;
    public Button Retry1;
    public Button Retry2;
    public Button Retry3;
    public Button Home1;
    public Button Home2;
    public Button Home3;
    public Button Resume;
    public Action NextBtnClick;
    private int Rewardx;
    public Text multiplierText;
    public TextMeshProUGUI LevelNo;
    public TextMeshProUGUI levelCoins;

    void Start()
    {
        Next.onClick.AddListener(()=>NextBtnClick.Invoke());
        Home1.onClick.AddListener(Home);
        Home2.onClick.AddListener(Home);
        Home3.onClick.AddListener(Home);
        Retry1.onClick.AddListener(Retry);
        Retry2.onClick.AddListener(Retry);
        Retry3.onClick.AddListener(Retry);
        Retry3.onClick.AddListener(Retry);
        Resume.onClick.AddListener(Resumebtn);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Nothanks()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 20);
    }
    public void Doublecoins()
    {
        //Nadeem Ads
        //CASAds.instance.ShowRewarded(() => {
        //    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + Rewardx*20);
        //    levelCoins.text = (Rewardx * 20).ToString();
        //});
    }

    public void Multiplier(int num)
    {
        Rewardx = num;
        multiplierText.text = num + "X";
    }
    public void Home()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartLevel");
        //if (SaveDogAudioManager.instance)
        //{
        //    SaveDogAudioManager.instance.destroy();
        //}
        //if (destroyer.instance)
        //{
        //    destroyer.instance.destroy();
        //}
        //if (DestoryObjectss.instance)
        //{
        //    DestoryObjectss.instance.destroy();
        //}
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resumebtn()
    {
        Time.timeScale = 1; 
        PausePanel.SetActive(false);
    }


}
