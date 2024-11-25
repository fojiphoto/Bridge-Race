using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Loadings : MonoBehaviour
{
    public Image fillBar;
	public Text LoadingTxt;

    private void Awake()
    {
		DontDestroyOnLoad(gameObject);
    }
    public void Start()
	{
      LoadingTxt.text="0"+"%";
	 
	  StartCoroutine(Txt());
	  Invoke(nameof(ShowBannerAd),3.5f);
	  
	}

	public void ShowBannerAd(){
		//AdsManager.instance.ShowBanner();
	}
	public IEnumerator Txt()
	{
		 
			for (int i = 0; i < 101; i++)
			{
			 yield return new WaitForSeconds(0.07f);
			LoadingTxt.text=i.ToString()+"%";
		}
	}
	public void Update()
	{
		if(fillBar.fillAmount<9)
		{
	      fillBar.fillAmount += 0.06f * Time.deltaTime;
		}
	}
	
}
