using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootRate;
    public int numOfBullets;
    public List<GameObject> bulletList;
    private float shootTimer = 0;
    private int bulletNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletList = new List<GameObject>();

        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            bullet.transform.parent = transform;
            bullet.SetActive(false);
            bulletList.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootRate && Input.GetMouseButton(0))
        {
            bulletList[bulletNumber].SetActive(true);

            bulletNumber++;
            if (bulletNumber >= bulletList.Count)
            {
                bulletNumber = 0;
            }
            shootTimer = 0;
        }
    }
}
