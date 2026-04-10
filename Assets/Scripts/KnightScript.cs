using UnityEngine;
using UnityEngine.InputSystem;

public class KnightScript : MonoBehaviour
{

    public AudioSource audioSource;
    public float speed;

    public float xMovement;

    public Animator knightAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
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

}