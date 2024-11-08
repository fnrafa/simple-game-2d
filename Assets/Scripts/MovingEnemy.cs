using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {
            moveRight = !moveRight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.TakeDamage(1);
            player.Knockback(800f, player.transform.position);
        }
    }
}