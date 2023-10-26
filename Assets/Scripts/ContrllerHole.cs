using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrllerHole : MonoBehaviour
{
    [SerializeField] private float limitSpeedForDown;
    [SerializeField] private AudioSource audioBallDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < limitSpeedForDown)
            {
                   audioBallDown.Play();
                FindAnyObjectByType<ControllerBolaGolf>().ShowAnimation();
            }
        }
    }
}
