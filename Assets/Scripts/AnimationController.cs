using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public bool pauseAnimation = false; // Boolean value to control the animation pause
    private Animator animator; // Reference to the Animator component

    public SpriteRenderer janiceRenderer;
    public Sprite janice;
    public Sprite janiceRaised;
    public SpriteRenderer chadRenderer;
    public Sprite chad;
    public Sprite chadRaised;

    void Awake()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name == "sabotageeScene")
        {
            chadRenderer = GameObject.FindWithTag("Chad").GetComponent<SpriteRenderer>();
        janiceRenderer = GameObject.FindWithTag("Janice").GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "sabotageeScene")
        {
            if (!GameManager.S.isPlayerOne)
                chadRenderer = GameObject.FindWithTag("Chad").GetComponent<SpriteRenderer>();
            else
                janiceRenderer = GameObject.FindWithTag("Janice").GetComponent<SpriteRenderer>();
        }
    }

    public void StopAnimation()
    {
        if(animator == null) {
            Debug.Log("Animator is null :(");
        }

        animator.speed = 0.0f;
        Debug.Log("reached stop anim in anim controller");
        animator.SetBool("IsPaused", true);
    }

    public void StartAnimation()
    {
        animator.speed = 1.0f;
    }

    public void ResetTimerAnimation()
    {
        Debug.Log("Timer was just restarted");
        animator.Play("stopwatchgodown", -1, 0f);

    }

    public void ChangeSprite()
    {
        if (!GameManager.S.isPlayerOne)
            chadRenderer.sprite = chadRaised;
        else
            janiceRenderer.sprite = janiceRaised;
        
    }

}