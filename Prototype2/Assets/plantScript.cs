using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float resetDelay = 4f; // Time in seconds before resetting the color.
    private Color originalColor;
    public float minDelay = 2f;
    public float maxDelay = 5f;

    public float waitTime = 3.0f;

    public int lives = 3;
  
    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = _spriteRenderer.color;
        //start pop up sequence
        InvokeRepeating("PopUp", Random.Range(minDelay, maxDelay), Random.Range(minDelay, maxDelay));


    }
    //when character collides with dryplant 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _spriteRenderer.color == originalColor)
        {
            _spriteRenderer.color = Color.green;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Invoke("DryPlant", resetDelay);
    }

    private void DryPlant()
    {
        _spriteRenderer.color = originalColor;


    }

    private void Update()
    {
        if(_spriteRenderer.color == originalColor)
        {
            Invoke("deadPlant", waitTime);
        }

    }

    private void deadPlant()
    {
        lives -= 1;

        if(lives == 0)
        {
            Debug.Log("No more lives");
        }
    }

    private void PopUp()
    {
        float randomX = Random.Range(0f, Screen.width);
        float randomY = Random.Range(0f, Screen.height);
        Vector3 randomScreenPosition = new Vector3(randomX, randomY, 10f); // Z position is 10 to appear in front of the camera

        Vector3 randomWorldPosition = mainCamera.ScreenToWorldPoint(randomScreenPosition);

        _spriteRenderer.transform.position = randomWorldPosition;

        Invoke("ResetPosition", 2f);

    }

    private void ResetPosition()
    {
        _spriteRenderer.transform.position = Vector3.zero;
    }

}
