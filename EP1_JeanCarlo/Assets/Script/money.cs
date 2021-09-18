using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public Vector3 end;
    private bool inicio = false;
    private Text points;
    // Start is called before the first frame update
    private void Awake()
    {
        points = GameObject.Find("puntaje").GetComponent<Text>();
    }
    void Start()
    {
        StartCoroutine(go2Top());
    }

    // Update is called once per frame
    void Update()
    {
        if (inicio)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, end, Time.deltaTime * 10);
            if(transform.position == end)
            {
                int lastpoint = int.Parse(points.text);
                lastpoint += 10;
                points.text = $"{lastpoint}";
                Destroy(gameObject);
            }
        }
    }

    IEnumerator go2Top()
    {
        yield return new WaitForSeconds(1);
        inicio = true;
    }
}
