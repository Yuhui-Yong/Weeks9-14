using System;
using UnityEngine;
using UnityEngine.UIElements;

public class NIgi : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] TheHero;
    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("index");

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
