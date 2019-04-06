using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBC : MonoBehaviour
{
    Rigidbody2D rigid;
    bool run = false;
    GameObject player;
    float speed = Global.speed;
    float range = Global.range;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        speed = Global.speed;
        this.gameObject.GetComponent<CircleCollider2D>().radius = Global.range;
        if (run)
        {
            Run();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.tag == "Player")
        {
            run = true;
            player = other.gameObject;
        }
    }
    void Run()
    {
        if(this.transform.position.x < player.transform.position.x)
        {
            float i = player.transform.position.x - this.transform.position.x;
            this.transform.position += Vector3.left * Time.deltaTime * speed ;
        }
        if (this.transform.position.x > player.transform.position.x)
        {
            float i = this.transform.position.x - player.transform.position.x;
            this.transform.position += Vector3.right * Time.deltaTime * speed ;
        }
        if (this.transform.position.y > player.transform.position.y)
        {
            float i = this.transform.position.y - player.transform.position.y;
            this.transform.position += Vector3.up * Time.deltaTime * speed ;
        }
        if (this.transform.position.y < player.transform.position.y)
        {
            float i = player.transform.position.y - this.transform.position.y;
            this.transform.position += Vector3.down * Time.deltaTime * speed ;
        }
    }
}
