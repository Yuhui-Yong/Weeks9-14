using UnityEngine;
using UnityEngine.InputSystem;

public class KnightScript : MonoBehaviour
{

    public AudioSource audioSource;
    public float speed;

    public float xMovement;
    public Animator KnightAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
    }

    public void footsteps()
    {
        Debug.Log("Footstep");

        audioSource.Play();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);

        Vector2 moveDIrection = context.ReadValue<Vector2>();
        xMovement = moveDIrection.x;

        bool IsRunning = xMovement != 0f;

        KnightAnimator.SetBool("IsRunning", IsRunning);

        // transform.position += new Vector3(xMovement, 0f, 0f) * speed * Time.deltaTime;
    }
}
