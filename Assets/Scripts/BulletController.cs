using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public List<GameObject> bulletSet1;
    public List<GameObject> bulletSet2;

    public Material mat1;
    public Material mat2;

    private bool inv;

    // Start is called before the first frame update
    void Start()
    {
        inv = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerChange()
    {
        inv = !inv;
        foreach (GameObject g in bulletSet1)
        {
            if (inv) // player is inverted
            {
                g.GetComponent<SpriteRenderer>().material = mat2; //
                g.GetComponent<CircleCollider2D>().isTrigger = false;
                Debug.Log("A1");
            }
            else
            {
                g.GetComponent<SpriteRenderer>().material = mat1;
                g.GetComponent<CircleCollider2D>().isTrigger = false;
                Debug.Log("A2");
            }
        }

        foreach (GameObject g in bulletSet2)
        {
            if ( inv)
            {
                g.GetComponent<SpriteRenderer>().material = mat1;
                g.GetComponent<CircleCollider2D>().isTrigger = true;
                //g.GetComponent<Rigidbody2D>().
                Debug.Log("B1");
            }
            else
            {
                g.GetComponent<SpriteRenderer>().material = mat2;
                g.GetComponent<CircleCollider2D>().isTrigger = true;
                Debug.Log("B2");
            }
        }
    }
}
