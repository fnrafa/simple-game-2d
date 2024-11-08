using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static int _totalFruitsCollected;
    private static GameManager _instance;

    public Text totalFruitsCollectedText;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        UpdateFruitText();
    }

    public static void AddFruit(int count)
    {
        _totalFruitsCollected += count;
        UpdateFruitTextStatic();
    }

    public static void ResetFruits()
    {
        _totalFruitsCollected = 0;
        UpdateFruitTextStatic();
    }

    private void UpdateFruitText()
    {
        if (totalFruitsCollectedText) totalFruitsCollectedText.text = _totalFruitsCollected.ToString();
    }

    private static void UpdateFruitTextStatic()
    {
        if (_instance) _instance.UpdateFruitText();
    }
}