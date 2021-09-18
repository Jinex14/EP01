using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = -5;
    private Rigidbody2D rb2d;
    private int life = 2;
    public GameObject prefab;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(speed, 0);
        if (transform.position.x <= -9.8)
        {
            PlayerMove.instance.loseLife();
            Destroy(gameObject);
        }
    }


    private void OnDisable()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("arrow"))
        {
            life = life - 1;
            if(life == 0)
            {

                int random = (int)Random.Range(1,4);
                for(int a = 0; a<random; a++)
                {
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }else
        {
            PlayerMove.instance.loseLife();
            Destroy(gameObject);
        }
    }
}
