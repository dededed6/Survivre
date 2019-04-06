using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class M : MonoBehaviour
{
    public int life = 2;
    public int speed = 10;
    Rigidbody2D rigid;
    public bool gm = false;

    void Start()
    {
        rigid = gameObject.GetComponent <Rigidbody2D>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, yMove, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "RBC" && !gm)
        {
            Destroy(collision.gameObject);
            Global.speed += -0.04f;
            Global.range += 0.7f;

        }
        if ( collision.gameObject.tag == "NKC" || collision.gameObject.tag == "TC" || collision.gameObject.tag == "WBC")
            if (!gm)
            {
                {
                    if (--life == 0)
                    {
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        this.gameObject.GetComponent<CircleCollider2D>().radius = 3;
                        gm = true;
                        Invoke("pull", 0.1f);
                        Invoke("setGm", 2f);
                    }
                }
        }
    }
    void pull()
    {
        this.gameObject.GetComponent<CircleCollider2D>().radius = 0.5f;
    }
    void setGm()
    {
        gm = false;
    }
}
