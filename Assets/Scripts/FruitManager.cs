using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    public GameObject transition;
    [HideInInspector] public int remainingFruits;

    private void Start()
    {
        remainingFruits = transform.childCount;
    }

    public void CheckAllFruitsCollected()
    {
        remainingFruits--;
        if (remainingFruits == 0)
        {
            transition.SetActive(true);
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}