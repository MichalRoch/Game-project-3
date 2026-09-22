using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public TextMeshProUGUI Congratulation;
    public TextMeshProUGUI time;

    private float timer = 0;
    private int minutes = 0;
    private int seconds = 0;
    private int hours = 0;

    public PointCounter[] objects;


    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)timer;

        if(seconds == 60)
        {
            minutes++;
            timer = 0;

            if(minutes == 60)
            {
                minutes = 0;
                hours++;
            }
        }

        time.text = "Czas: " + hours + "h " + minutes + "min " + seconds + "s";


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            if (Points() == 1)
            {
                Destroy(gameObject, 0.1f);

                time.enabled = false;
                counter.enabled = false;

                Congratulation.text = "Gratulacje " +
                    "wszystkie punkty zdobyte w czasie: " + hours + " godzin " +
                    minutes + " minut i " + seconds + " sekund.";
            }
            else
            {
                Destroy(gameObject, 0.1f);

                int currentValue = Convert.ToInt32(counter.text);
                currentValue++;

                counter.text = Convert.ToString(currentValue);
            }
        }
        else
        {
            return;
        }
    }


    public int Points()
    {
        objects = Component.FindObjectsOfType<PointCounter>();
        return objects.Length;
    }
}
