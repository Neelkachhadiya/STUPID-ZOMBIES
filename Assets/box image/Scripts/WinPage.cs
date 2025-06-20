using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPage : MonoBehaviour
{
    int star;
    int levelno;
    int cnt = 1;
    public GameObject Starprefab,starHollder,winobj,overobj;
    public Text cnttext;

    // Start is called before the first frame update
    void Start()
    {
        winobj.SetActive(true);
        overobj.SetActive(false);
        if (PlayerPrefs.GetInt("GameOver")==1)
        {
            overobj.SetActive(true);
            winobj.SetActive(false);
            PlayerPrefs.SetInt("GameOver",0);
        }

        levelno = PlayerPrefs.GetInt("levelno");
        
        cnttext.text = PlayerPrefs.GetInt("Score")+"";

        star = PlayerPrefs.GetInt("Starimage");
        //PlayerPrefs.SetInt("Star_"+levelno,star);

        for (int i=1;i<=star;i++)
        {
            Instantiate(Starprefab,starHollder.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextbtn()
    { 
        SceneManager.LoadScene("Play");
    }
    public void levelbtn()
    { 
        SceneManager.LoadScene("level");
    }
}
