using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] BulletController bc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject g = collision.gameObject;
        if(g.CompareTag("Bullet"))
        {
            if (bc.bulletSet1.Contains(g)){
                bc.bulletSet1.Remove(g);
            }
            else
            {
                bc.bulletSet2.Remove(g);
            }
            Destroy(g);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject g = collision.gameObject;
        if (g.CompareTag("Bullet"))
        {
            if (bc.bulletSet1.Contains(g))
            {
                bc.bulletSet1.Remove(g);
            }
            else
            {
                bc.bulletSet2.Remove(g);
            }
            Destroy(g);
        }
    }
}
