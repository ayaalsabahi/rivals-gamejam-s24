using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    public void StopAnimation()
    {
        animator.speed = 0f;
    }

    public void ResetAnimation()
    {
        animator.Play("stopwatchgodown", -1, 0f);
    }

    public void ChangeSprite()
    {
        janiceRenderer.sprite = janiceRaised;
        chadRenderer.sprite = chadRaised;
    }

}