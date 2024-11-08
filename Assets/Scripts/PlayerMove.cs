using UnityEngine;

public class PlayerMove : PlayerInit
{
    private readonly float _runSpeed = 1;
    private readonly float _jumpSpeed = 3;
    private readonly float _doubleJumpSpeed = 2.5f;
    private readonly bool _betterJump = true;
    private readonly float _fallMultiplier = 0.5f;
    private readonly float _lowJumpMultiplier = 1f;
    private readonly float _maxRunSpeed = 3;
    private readonly float _speedIncreaseDuration = 3f;
    private float _currentRunSpeed;
    private float _speedIncreaseTime;

    private void Update()
    {
        if (Input.GetKey("space") || Input.GetKey("w"))
        {
            if (CheckGround.isGrounded)
            {
                CanDoubleJump = true;
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, _jumpSpeed);
                SetAnimation(JumpAnimation, true);
            }
            else if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && CanDoubleJump)
            {
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, _doubleJumpSpeed);
                CanDoubleJump = false;
                SetAnimation(DoubleJumpAnimation, true);
            }
        }

        if (!CheckGround.isGrounded)
        {
            SetAnimation(JumpAnimation, true);
            SetAnimation(RunAnimation, false);
        }
        else
        {
            SetAnimation(JumpAnimation, false);
            SetAnimation(DoubleJumpAnimation, false);
            SetAnimation(FallingAnimation, false);
        }

        if (Rb2D.velocity.y < 0)
        {
            SetAnimation(FallingAnimation, true);
        }
        else if (Rb2D.velocity.y > 0)
        {
            SetAnimation(FallingAnimation, false);
        }
    }

    private void Start()
    {
        _currentRunSpeed = _runSpeed;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            if (_speedIncreaseTime < _speedIncreaseDuration)
            {
                _speedIncreaseTime += Time.deltaTime;
                _currentRunSpeed = Mathf.Lerp(_runSpeed, _maxRunSpeed, _speedIncreaseTime / _speedIncreaseDuration);
            }
            else
            {
                _currentRunSpeed = _maxRunSpeed;
            }
        }
        else
        {
            _speedIncreaseTime = 0;
            _currentRunSpeed = _runSpeed;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            Move(_currentRunSpeed, false);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            Move(-_currentRunSpeed, true);
        }
        else
        {
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            SetAnimation(RunAnimation, false);
        }

        if (_betterJump)
        {
            if (Rb2D.velocity.y < 0)
            {
                Rb2D.velocity += (Physics2D.gravity.y * _fallMultiplier * Time.deltaTime) * Vector2.up;
            }
            else if (Rb2D.velocity.y > 0 && !(Input.GetKey("space") || Input.GetKey("w")))
            {
                Rb2D.velocity += (Physics2D.gravity.y * _lowJumpMultiplier * Time.deltaTime) * Vector2.up;
            }
        }
    }

    private void Move(float speed, bool flipX)
    {
        Rb2D.velocity = new Vector2(speed, Rb2D.velocity.y);
        SpriteRenderer.flipX = flipX;
        SetAnimation(RunAnimation, speed != 0);
    }

    public void Knockback(float knockpow, Vector2 knockdir)
    {
        Animator.Play("Hit");
        Rb2D.velocity = Vector2.zero;
        Rb2D.AddForce(new Vector2(knockdir.x * -500f, knockdir.y * knockpow));
    }
}