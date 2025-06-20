using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletpng;
    int cnt = 0, CntForBul;
    public Transform gunPoint;
    LineRenderer lr;
    int[] bulletLimit = { 3, 5, 3, 5, 4, 3 };
    int Bulletgen, levelno;
    public GameObject bulletparent;
    List<GameObject> Bulletimages = new List<GameObject>();
    public GameObject[] level;
    // Start is called before the first frame update
    void Start()
    {
        levelno = PlayerPrefs.GetInt("levelno", 1);
        level[levelno - 1].SetActive(true);
        CntForBul = bulletLimit[levelno - 1];
        Bulletgen = bulletLimit[levelno - 1];
        lr = GetComponent<LineRenderer>();
        for (int i = 1; i <= Bulletgen; i++)
        {
            GameObject bullets = Instantiate(bulletpng, bulletparent.transform);
            Bulletimages.Add(bullets);
        }

        // Update is called once per frame
    }
    void Update()
    {
        Vector2 gunpos = transform.position;
        lr.SetPosition(0, gunPoint.transform.position);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 offset = new Vector2(mousePos.x - gunpos.x, mousePos.y - gunpos.y);

        lr.SetPosition(1, mousePos);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetMouseButtonDown(0))
        {
            if (CntForBul != 0)
            {
                cnt = cnt + 1;
                if (cnt == 1)
                {
                    PlayerPrefs.SetInt("Starimage", 3);
                }
                else if (cnt == 2)
                {
                    PlayerPrefs.SetInt("Starimage", 2);
                }
                else
                {
                    PlayerPrefs.SetInt("Starimage", 1);
                }
                FireBullet();
                CntForBul--;

            }
                else
                {
                    PlayerPrefs.SetInt("GameOver",1);
                    SceneManager.LoadScene("win");
                }
        }
    }
    void FireBullet()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * 2000);
        Destroy(bullet, 3f);
        Destroy(Bulletimages[cnt - 1]);
    }
    public void backbtn()
    {
        SceneManager.LoadScene("level");
    }

}
