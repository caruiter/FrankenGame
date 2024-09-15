//
//this borrows some code from Kennedy's Player script and Cameron's Movement script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed; //speed of player
    public float health; //health of player

    public bool inv; //are the controls inverted?

    private float timeToInvert; // Time until the next control inversion

    public float minInvertTime = 5f; // Minimum time before the next inversion
    public float maxInvertTime = 15f; // Maximum time before the next inversion

    public UnityEvent Invert;

    public Material mat1;
    public Material mat2;

    public GameObject endscreen;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomInvertTime(); // Set a random timer for control inversion at the start
        inv = false;
        endscreen.SetActive(false);
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRandomInversion();
        float speedX = Input.GetAxisRaw("Horizontal") * speed;
        float speedY = Input.GetAxisRaw("Vertical") * speed;

        if (inv)
        {
            speedX = -speedX;
            speedY = -speedY;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, speedY);


    }

    void HandleRandomInversion()
    {
        // Countdown the timer
        timeToInvert -= Time.deltaTime;

        // If the timer reaches zero, invert the controls and set a new random timer
        if (timeToInvert <= 0f)
        {
            inv = !inv; // Toggle controls inversion

            Debug.Log("invert: " + inv);
            SetRandomInvertTime(); // Set a new random timer for the next inversion
        }
    }

    void SetRandomInvertTime()
    {
        // Set the timeToInvert to a random value between the min and max inversion time
        timeToInvert = Random.Range(minInvertTime, maxInvertTime);
        Invert.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            health -= 1;
            UpdateHealth();
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }

    public void ColorSwap()
    {
        Debug.Log("swapped2");
        if (inv)
        {
            Debug.Log("here1");
            this.GetComponent<SpriteRenderer>().material = mat2;
            Debug.Log("here1b");
        }
        else
        {
            Debug.Log("here2");
            this.GetComponent<SpriteRenderer>().material = mat1;
            Debug.Log("here2b");
        }
    }

    public void UpdateHealth()
    {
        healthText.text = "Lives: " + health;
        if (health <= 0)
        {
            endscreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
