using UnityEngine;

public abstract class PlayerInit : MonoBehaviour
{
    protected Rigidbody2D Rb2D;
    protected Animator Animator;
    protected SpriteRenderer SpriteRenderer;
    protected static int health = 5;
    protected bool CanDoubleJump;

    protected static readonly int JumpAnimation = Animator.StringToHash("Jump");
    protected static readonly int DoubleJumpAnimation = Animator.StringToHash("DoubleJump");
    protected static readonly int RunAnimation = Animator.StringToHash("Run");
    protected static readonly int FallingAnimation = Animator.StringToHash("Falling");

    protected virtual void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void SetAnimation(int animationHash, bool state)
    {
        Animator.SetBool(animationHash, state);
    }

    public void SetSkin(RuntimeAnimatorController animatorController, Sprite sprite)
    {
        Animator.runtimeAnimatorController = animatorController;
        SpriteRenderer.sprite = sprite;
    }
}