using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBall : MonoBehaviour
{
    [SerializeField] private AudioSource audioBallCollision;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioBallCollision.Play();
    }
}
