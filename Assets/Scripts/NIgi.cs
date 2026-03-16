using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class NIgi : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // I am calling the sprite in the inspector.
    public Sprite[] TheHero; // I am making it have an array of the name TheHero.
    int index = 0; // The current's sprite or the current value I am using.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        if (context.performed) // This is the one that only performe when it press the button. The reason why I put this is because when I presses the E button, the InputSystem
            // was taking 3 actions, which are pressing, holding and releasing, so it did not look, the character action goes one by one by pressing the E button. So, by writing this
            // code, it only perform the pressed action, so it goes only one by one, which I wanted it to be.
        {
            Debug.Log("PleaseWork");

            Debug.Log(index);

            if (index == TheHero.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }

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
}