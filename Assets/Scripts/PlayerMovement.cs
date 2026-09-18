using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;

    //soundwave cooldown
    public float soundTimer = 0;

    private int scoreVal = 0;

    public TextMeshProUGUI scoreBOX;

    public GameObject PlayerSound;

    void Update()
    {
        soundTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (soundTimer >= 5)    
        { 
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(PlayerSound, transform.position, Quaternion.identity);
                soundTimer = 0;
            }
        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.GetComponent<ProjectileMove>() != null)
            {
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBOX.text = "Score: " + scoreVal;
            }
            Destroy(collision.gameObject);
        }
    }
}
