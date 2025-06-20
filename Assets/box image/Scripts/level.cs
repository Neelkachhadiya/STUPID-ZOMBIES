
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    int levelno,maxlevel;
    public Button[] btn;
    public GameObject[] starholder;
    public GameObject starprefsb;
    int cnt=1;
    // Start is called before the first frame update
    void Start()
    {
        levelno=PlayerPrefs.GetInt("levelno");
        maxlevel=PlayerPrefs.GetInt("MaxLevelno", 1);
        //PlayerPrefs.GetInt("Star_" + levelno);
        
        for (int i=0;i<maxlevel;i++)
        {
            
            btn[i].interactable = true;

        }
        for (int i = 0; i < maxlevel-1; i++)
        {
            for (int j = 0; j < PlayerPrefs.GetInt("Star_" + cnt); j++)
            {
                Instantiate(starprefsb, starholder[i].transform);
            }
            cnt++;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lvlbtnClick(int n)
    {
        PlayerPrefs.SetInt("levelno",n);
        SceneManager.LoadScene("Play");
    }
}
