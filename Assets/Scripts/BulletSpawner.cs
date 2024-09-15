using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private float ct;
    public float interval;

    [SerializeField] GameObject bullet1prefab;
    [SerializeField] GameObject bullet2prefab;

    private BulletController bc;

    [SerializeField] PlayerController pc;
    
    // Start is called before the first frame update
    void Start()
    {
        ct = 0;
        bc = GetComponent<BulletController>();

    }

    // Update is called once per frame
    void Update()
    {
        ct += Time.deltaTime;

        if (ct >= interval)
        {
            ct = 0;
            SpawnBullet();
        }
    }

    public void SpawnBullet()
    {
        Vector2 position = Random.onUnitSphere.normalized * 15;

        GameObject b;
        int a = Random.Range(0, 2);

        if(a == 0)
        {
            b = Instantiate(bullet1prefab);
            bc.bulletSet1.Add(b);
            if (pc.inv)
            {
                b.GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
        else
        {
            b = Instantiate(bullet2prefab);
            bc.bulletSet2.Add(b);
            if (pc.inv)
            {
                b.GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
        
        b.transform.position = position;
        b.GetComponent<Rigidbody2D>().AddForce((new Vector2(0,0) - position) * 60);
    }
}
