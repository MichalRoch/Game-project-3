using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCollider : MonoBehaviour
{

    private Renderer object_renderer;

    void Start()
    {
        object_renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            object_renderer.material.color = 
                new Color(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f), 
                    Random.Range(0f, 1f));
        }
    }
}
