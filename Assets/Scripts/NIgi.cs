using System;
using UnityEngine;
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
        Debug.Log("index");

        if (index == TheHero.Length - 1) // I cannot just set to TheHero.Length because it cannot detect the elements I have since it starts from the zero, which means
            // it goes from 0, 1, 2, 3 and 4 but there is no 5, so I had to subtract by 1.
        {
            index = 0; // So, if index is equal to zero, it will go to spriteRenderer.sprite = TheHero[index];, which is the original sprite, like the object that I have.
        }
        else
        {
            index++; // Otherwise, it will keep running like adding one, so it will like animate it.
        }

        spriteRenderer.sprite = TheHero[index];
    }

    public void ChangeSprite()
    {

        if (index == TheHero.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        spriteRenderer.sprite = TheHero[index];
    }
}
