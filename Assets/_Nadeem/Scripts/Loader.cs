using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI coinsTxt;
    void Start()
    {
        coinsTxt.text = PlayerPrefs.GetInt("coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinsTxt.text = PlayerPrefs.GetInt("coins").ToString();
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {

    }
}
