using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    float speedX, speedY;
    Rigidbody2D rb2d;
    public bool freezeMovement = false;
    private PostProcessVolume ppVolume;
    public bool isInPuzzle = false;

    public NotesManager nm;

    public Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ppVolume = transform.Find("Main Camera").gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;
        //transform.Find("Main Camera").gameObject.AddComponent<PostProcessVolume>();
    }

    private void PlayerMovement(Vector2 movementDirection)
    {
        //if (freezeMovement)
        //{
        //    animator.SetFloat("Speed", 0f);
        //    rb2d.velocity = Vector2.zero;
        //    return;
        //}

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        speedX = movementDirection.x * Speed;
        speedY = movementDirection.y * Speed;

        if (movementDirection.x == 0 && movementDirection.y == 0)
            AudioManager.instance.StopSFXLoop();
        else
            AudioManager.instance.PlaySFXLoop("Walk");

        if (speedX != 0 && speedY == 0)
            rb2d.velocity = new Vector2(speedX, 0);
        else if (speedY != 0 && speedX == 0)
            rb2d.velocity = new Vector2(0, speedY);
        else
            rb2d.velocity = Vector2.zero;
    }

    void Update()
    {
        Vector2 movementDirection;
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        if (freezeMovement || isInPuzzle)
        {
            movementDirection = Vector2.zero;
        }

        PlayerMovement(movementDirection);

        if (DialogueManager.Instance.isInDialogue == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                DialogueManager.Instance.DisplayNextSentence();
            }

            return;
        }

        if (GameObject.FindGameObjectWithTag("puzzle clock") != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                puzzleClock.MoveHand();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InteractableManager.Instance.TriggerInteractable())
            {
                freezeMovement = true;
            }
        }

        ppVolume.enabled = isInPuzzle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Notes"))
        {
            Destroy(collision.gameObject);
            nm.notesCount++;
        }
    }

    public void SetFreezeMovement(bool value)
    {
        freezeMovement = value;
    }

    public void SetIsInPuzzleMode(bool value)
    {
        isInPuzzle = value;
    }
}
