using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;

    public AudioClip move;
    public AudioClip jump;
    public AudioClip land;

    private PlayerController controller;

    private bool playerGrounded;

    private float timer = 0f;

    void Start()
    {
        controller = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        PlayerSounds();
    }

    private void PlayerSounds()
    {
        if((controller.horizontal !=0 || controller.vertical !=0) && controller.characterController.isGrounded && timer<=0)
        {
            source.PlayOneShot(move);
            timer = 0.5f;
        }

        if (timer > 0)
        {
            if (controller.movementSpeed > 10)
            {
                timer -= Time.deltaTime * 1.8f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump") && playerGrounded)
        {
            source.PlayOneShot(jump);
        }

        if (!playerGrounded && controller.characterController.isGrounded)
        {
            source.PlayOneShot(land);
        }

        playerGrounded = controller.characterController.isGrounded;
    }
}
