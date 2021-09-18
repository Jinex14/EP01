using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private List<Vector2> pos;
    private int i = 0;
    private Rigidbody2D rb;
    public static PlayerMove instance;
    private int vida = 3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            changePosition(true);
        }
        if (Input.GetKeyDown("s"))
        {
            changePosition(false);
        }

    }

    void changePosition(bool add)
    {
        i = (add) ? i + 1 :  i - 1;
        i = (i > pos.Count - 1) ? 0 : i;
        i = (i < 0) ? pos.Count - 1 : i;
        transform.position = pos[i];
    }
    
    public void loseLife()
    {
        vida = vida - 1;
        if(vida <= 0) 
            Application.LoadLevel(Application.loadedLevel);
    }
}
