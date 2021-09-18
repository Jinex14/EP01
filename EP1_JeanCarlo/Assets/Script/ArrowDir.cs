using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDir : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D rb2d;
    private Vector2 alt = new Vector2(0, 0);

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
        rb2d.velocity = new Vector2(speed,0);
        transform.position = new Vector2(transform.position.x, alt.y);
    }
    private void OnBecameInvisible()
    {
        ResetBullet();
    }

    void ResetBullet()
    {
        transform.localPosition = Vector2.zero;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        alt = PlayerMove.instance.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
            this.gameObject.SetActive(false);
    }
}
