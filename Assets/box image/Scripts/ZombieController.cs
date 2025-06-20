using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    float speed=0.05f;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Vector2 pos;        
    int[] ZomDieCountar = {3,6,2,4,5,4};
    int zombiediecnt,zomcnt=0;
    int levelno;
    int score=0;
    //PolygonCollider2D pop;

    // Start is called before the first frame update
    void Start()
    {
        levelno = PlayerPrefs.GetInt("levelno",1);
        zombiediecnt = ZomDieCountar[levelno-1];
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //pop = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] zomdiecnt = GameObject.FindGameObjectsWithTag("ZombieDied");
        if(zomdiecnt.Length==zombiediecnt && zomcnt==0)
        {
            StartCoroutine(zombiesdietime());
           
        }
        //if (spriteRenderer.flipX == true)
        //{
        //    transform.position = new Vector2(transform.position.x - speed, transform.position.y);

        //}
        //else if (spriteRenderer.flipX == false)
        //{
        //    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        //}
        if (gameObject.tag == "ZombieDied")
        {
            transform.position = pos;
        }
    }
    IEnumerator zombiesdietime()
    {
        yield return new WaitForSeconds(1);
        zomcnt = 1;
        print("win");
        int star = PlayerPrefs.GetInt("Starimage");
        print("star="+star);
        PlayerPrefs.SetInt("Star_" + levelno, star);
        print(PlayerPrefs.GetInt("Star_" + levelno));

        PlayerPrefs.SetInt("levelno", levelno + 1);
        if (PlayerPrefs.GetInt("levelno", 1) >= PlayerPrefs.GetInt("MaxLevelno", 1))
        {
            PlayerPrefs.SetInt("MaxLevelno", PlayerPrefs.GetInt("levelno", 1));
        }
        score=zombiediecnt * 2000;
        PlayerPrefs.SetInt("Score", score);

        SceneManager.LoadScene("win");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "right")
        //{
        //    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        //    spriteRenderer.flipX = true;
        //}
        //if (collision.gameObject.tag == "left")
        //{
        //    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        //    spriteRenderer.flipX = false;
        //}
        if (collision.gameObject.tag=="bullet")
        {
            
            //score += 2000;

            //PlayerPrefs.SetInt("Score_"+levelno, score);
            //PlayerPrefs.SetInt("Score", score);
            //print("s="+ PlayerPrefs.GetInt("Score", score));
            PlayerPrefs.SetInt("ZomDieCount", zombiediecnt);
            print("zomBieDie"+zombiediecnt);
            pos = transform.position;
            animator.SetTrigger("IsDie");
            gameObject.tag = "ZombieDied";
            //Destroy(pop);
            // Destroy(this.gameObject,3f);
        }
    }
    
   
}
