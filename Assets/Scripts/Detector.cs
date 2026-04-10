using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Detector : MonoBehaviour
{

    public UnityEvent onHover;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {



        //IF WE ARE HOVERING
        //TRIGGER THE EVENT
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(worldMousePosition);
        bool isHovered = spriteRenderer.bounds.Contains(worldMousePosition);

        if (isHovered)
        {
            onHover.Invoke();
        }

    }
}