using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class KnightScript : MonoBehaviour
{

    public AudioSource audioSource;
    public float speed;

    public float xMovement;

    public Animator knightAnimator;

    public SpriteRenderer spriteRenderer; // I am calling the sprite in the inspector.
    public Sprite[] TheHero; // I am making it have an array of the name TheHero.
    int index = 0; // The current's sprite or the current value I am using.

    public Color damageColour;
    private Color playerColour;

    public Sprite Yuhui;
    public Sprite YuhuiDamage;

    public int damage;
    public Rock rock;

    public IEnumerator pauseCoroutine;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = TheHero[index];
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;

        // Debug.Log("index");

        // if (index == TheHero.Length - 1) // I cannot just set to TheHero.Length because it cannot detect the elements I have since it starts from the zero, which means
        // it goes from 0, 1, 2, 3 and 4 but there is no 5, so I had to subtract by 1.
        // {
        // index = 0; // So, if index is equal to zero, it will go to spriteRenderer.sprite = TheHero[index];, which is the original sprite, like the object that I have.
        // }
        // else
        // {
        // index++; // Otherwise, it will keep running like adding one, so it will like animate it.
        // }

        // spriteRenderer.sprite = TheHero[index];
    }

    public void OnFootstep()
    {
        Debug.Log("Footstep");

        audioSource.Play();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool IsRunning = xMovement != 0f;

        knightAnimator.SetBool("isRunning", IsRunning);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (pauseCoroutine != null)
            {
                StopCoroutine(pauseCoroutine);
                index = 0;
            }
            pauseCoroutine = PauseAnime();
            StartCoroutine(pauseCoroutine);
        }
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {

        Debug.Log(context.phase); // I checked if it works here, putting context.phase, it worked.

        if (context.started) // This is the one that only performe when it press the button. The reason why I put this is because when I presses the E button, the InputSystem
            // was taking 3 actions, which are pressing, holding and releasing, so it did not look, the character action goes one by one by pressing the E button. So, by writing this
            // code, it only perform the pressed action, so it goes only one by one, which I wanted it to be.

            // (context.performed) didn't work.
        {
            Debug.Log("PleaseWork");

            Debug.Log(index);
            if(pauseCoroutine != null)
            {
                StopCoroutine(pauseCoroutine);
                index = 0;
            }
            pauseCoroutine = PauseAnime();
            StartCoroutine(pauseCoroutine);

            //if (index == TheHero.Length - 1)
            //{
            //    index = 0;
            //}
            //else
            //{
            //    index++;
            //}

            spriteRenderer.sprite = TheHero[index];

            // Debug.Log(index);

            // if (index == TheHero.Length - 1)
            // {
            // index = 0;
            // }
            // else
            // {
            // index++;
            // }

            // spriteRenderer.sprite = TheHero[index];
        }
    }
    public void ApplyDamage()
    {
        rock.TakeDamage(damage);
    }

    public void ChangePlayerColor()
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerColour = playerRenderer.color;
        playerRenderer.color = damageColour;
    }

    public void OriginalPlayerColour()
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerRenderer.color = playerColour;
    }

    public void ChangeYuhuiSprite()
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        Yuhui = playerRenderer.sprite;
        playerRenderer.sprite = YuhuiDamage;
    }

    public void OriginalYuhuiSprite()
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerRenderer.sprite = Yuhui;

    }

    public IEnumerator PauseAnime()
    {
        knightAnimator.SetBool("isAttacking", true);
        
        yield return new WaitForSeconds(0.5f);

        knightAnimator.SetBool("isAttacking", false);
    }

}