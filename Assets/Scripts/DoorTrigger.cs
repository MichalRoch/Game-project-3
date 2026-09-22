using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator animator;
    public bool isOpen = false;

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("wciœniêto dzia³a E");
            if (isOpen == true)
            {
                Debug.Log("close");
                animator.SetTrigger("Close");
                isOpen = false;
            }
            else
            {
                Debug.Log("open");
                animator.SetTrigger("Open");
                isOpen = true;
            }
        }
    }

}
