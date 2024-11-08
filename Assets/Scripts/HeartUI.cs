using UnityEngine;
using UnityEngine.UI;

public class HeartUI : PlayerInit
{
    public Sprite[] heartsprite;
    public Image heart;

    private void FixedUpdate()
    {
        if (health > 5) health = 5;

        if (health < 0)
        {
            Animator.Play("Hit");
            health = 0;
        }

        heart.sprite = heartsprite[health];
    }
}