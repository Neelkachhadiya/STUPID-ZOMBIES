using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playbtn()
    {
        SceneManager.LoadScene("Play");
    }
    public void levelbtn()
    {
        SceneManager.LoadScene("level");
    }
}
