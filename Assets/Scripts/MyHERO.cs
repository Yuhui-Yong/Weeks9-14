using System.Collections;
using UnityEngine;

public class MyHERO : MonoBehaviour
{
    public AnimationCurve Anime;
    private Coroutine MoveMyhero;
    public float duration;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator MyheroMoveUpdate()
    {
        float progress = 0f;

        // The contents of the while loop run while the condition is true
        while (progress < duration)
        {
            progress += Time.deltaTime;
            transform.localPosition = Anime.Evaluate(progress / duration) * Vector3.one;
            yield return null;
        }
    }