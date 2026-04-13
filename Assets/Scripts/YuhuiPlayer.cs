using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class YuhuiPlayer : MonoBehaviour
{

    public Vector2 moveDirection;
    public float moveSpeed;
    public float baseSpeed;
    public YuhuiManager manager;

    public Vector3 playerScale;
    public AnimationCurve scaleCurve;

    bool currentlyBoosting = false;

    Coroutine boosting;
    Coroutine attacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        //Debug.Log(playerScale);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }


    public void OnAttack(InputAction.CallbackContext context)
    {


        if (context.performed)
        {

            if (attacking != null)
            {
                StopCoroutine(attacking);
            }

            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);

            attacking = StartCoroutine(Attacking());


        }

        Debug.Log("Attack: " + context.phase);

    }

    public void SpeedBoost(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (!currentlyBoosting)
            {
                Debug.Log("start");

                currentlyBoosting = true;

                baseSpeed = moveSpeed;

                boosting = StartCoroutine(Boost());

            }

        }

    }


    private IEnumerator Attacking()
    {
        float progress;
        float duration = 1;
        float time = 0;


        while (time < duration)
        {
            time += Time.deltaTime;

            progress = scaleCurve.Evaluate(time);

            playerScale = new Vector3(1, progress, 1);

            transform.localScale = playerScale;

            if (time > duration)
            {

                StopCoroutine(attacking);

                time = 0;

            }

            yield return null;

        }
    }

    private IEnumerator Boost()
    {
        float duration = 1;
        float time = 0;
        float speedBoost = 2;

        moveSpeed = moveSpeed * speedBoost;

        while (time < duration)
        {
            time += Time.deltaTime;

            if (time > duration)
            {
                moveSpeed = baseSpeed;

                Debug.Log("stop [" + moveSpeed + "]");

                time = 0;

                currentlyBoosting = false;

                //StopCoroutine(boosting);
                break;

            }

            yield return null;
        }


    }
}