using UnityEngine;

public class FruitCollected : MonoBehaviour
{
    public AudioSource clip;
    private FruitManager _fruitManager;

    private void Start()
    {
        _fruitManager = FindObjectOfType<FruitManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            GameManager.AddFruit(1);
            _fruitManager.CheckAllFruitsCollected();
            if (clip != null)
            {
                clip.Play();
            }

            Destroy(gameObject, 0.5f);
        }
    }
}