using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class KnightScript : MonoBehaviour
{

    public AudioSource audioSource; // This is for Audio.
    public float speed; // For speed.

    public float xMovement; // For movement but only x cause it doesn't make sense to have y movement with the character I am using with the animation because it only appears going
    // right direction.

    public Animator knightAnimator; // The Animator obviosuly.

    public SpriteRenderer spriteRenderer; // I am calling the sprite in the inspector.
    public Sprite[] TheHero; // I am making it have an array of the name TheHero.
    int index = 0; // The current's sprite or the current value I am using.

    public Color damageColour;
    private Color playerColour;

    public Sprite Yuhui; // I am calling the Sprite. This is the original sprite.
    public Sprite YuhuiDamage; // I am calling the Sprite. This is when it takes damage it is gon appear this sprite.

    public int damage; // This is for the damage.
    public Rock rock; // I am calling the script as well so that it can scan.

    public IEnumerator pauseCoroutine; // This is the Coroutine,


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = TheHero[index]; 
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
    }

    public void OnFootstep() // This is just for the audio.
    {
        Debug.Log("Footstep");

        audioSource.Play();
    }

    public void OnMove(InputAction.CallbackContext context) // This is for moving left and right.
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool IsRunning = xMovement != 0f;

        knightAnimator.SetBool("isRunning", IsRunning);
    }

    public void OnAttack(InputAction.CallbackContext context) // This is for attaking 
    {
        if (context.started) // I first wrote a code with if (context.performed), but it didn' work. So, eventually I just wrote "started" instead of perfoermed. But, it is not how
            // I figured out. Like I don't know why performed didn't work and why started worked. But, somehow I just figured out putting "started".
        {
            if (pauseCoroutine != null) // what this thing does is if I click the mouse, which is context.started, it is going to check if pauseCoroutine is not equal to nothing. And,
                // it it is not equal to nothing, it is going to StopCoroutine(pauseCoroutine) and the pause Coroutine is PauseAnime. and the PauseAnime is
                // this:
                
                // public IEnumerator PauseAnime()
                // {
                    // knightAnimator.SetBool("isAttacking", true);

                    // yield return new WaitForSeconds(0.5f);

                    // knightAnimator.SetBool("isAttacking", false);

                    {
                StopCoroutine(pauseCoroutine);
                index = 0; // This thing makes it zero so that it can start from zero again.
            }
            pauseCoroutine = PauseAnime(); // Pause Coroutine is for Pasuing Animation that the HeroKnight have.
            StartCoroutine(pauseCoroutine); // Now, it is going to startCoroutine.
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

            if(pauseCoroutine != null) // So, now here I am calling pauseCoroutine, which is PauseAnime, so it is just PauseAnime, named as pauseCoroutine. what this does is that
                // if 
            {
                StopCoroutine(pauseCoroutine);
                index = 0;
            }
            pauseCoroutine = PauseAnime(); // This is just for naming PauseAnime as something, like making a variable.
            StartCoroutine(pauseCoroutine); // This is going to start PauseAnime, which is pauseCoroutine.

            spriteRenderer.sprite = TheHero[index];
        }
    }
    public void ApplyDamage() // This is for the Applying Damage.
    {
        rock.TakeDamage(damage);
    }

    public void ChangePlayerColor() // This is for changing the colour when it gets hit.
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerColour = playerRenderer.color;
        playerRenderer.color = damageColour;
    }

    public void OriginalPlayerColour() // This is for setting Original PlayerColour when it is not getting any damage.
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerRenderer.color = playerColour;
    }

    public void ChangeYuhuiSprite() // This is for the changing the sprite when it gets hit.
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        Yuhui = playerRenderer.sprite;
        playerRenderer.sprite = YuhuiDamage;
    }

    public void OriginalYuhuiSprite() // This is for setting Original Sprite when it is not getting any damage.
    {
        SpriteRenderer playerRenderer = rock.GetComponent<SpriteRenderer>();
        playerRenderer.sprite = Yuhui;

    }

    public IEnumerator PauseAnime() // Here, this is called PauseAnime. And what this does is that if I call this it sets the bool for isAttacking true, and wait for 0.5seconds,
                                    // then it sets isAttacking false and it never goes back.
    {
        knightAnimator.SetBool("isAttacking", true);

        yield return new WaitForSeconds(0.5f);

        knightAnimator.SetBool("isAttacking", false);
    }
}