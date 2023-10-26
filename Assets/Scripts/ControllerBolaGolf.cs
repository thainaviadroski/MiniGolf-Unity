using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBolaGolf : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private new Camera camera;

    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioBall;
    [SerializeField] private AudioSource audioBallDown;

    [SerializeField] private float forcaAdd;
    [SerializeField] private float limitMove;
    private Vector3 mousePosition;
    private bool isAddForce;

    [SerializeField] private float minSpeedMove;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector2.zero);
        lineRenderer.SetPosition(1, Vector2.zero);
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        getPositionMouse();

        if (Input.GetMouseButtonDown(0) && !isAddForce && rigidbody.velocity.magnitude <= minSpeedMove)
        {
            startAddForce();
        }

        if (isAddForce)
        {
            addingForce();
        }

        if (Input.GetMouseButtonUp(0) && isAddForce)
        {
            stopAddForce();
        }

    }


    private void getPositionMouse()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
    }

    private void startAddForce()
    {
        isAddForce = true;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, mousePosition);
        lineRenderer.SetPosition(1, Vector2.zero);
    }

    private void addingForce()
    {
        Vector3 postionStart = lineRenderer.GetPosition(0);
        Vector3 position = mousePosition;

        Vector3 distanceMoveMouse = position - postionStart;

        if (distanceMoveMouse.magnitude <= limitMove)
        {
            lineRenderer.SetPosition(1, position);
        }
        else
        {
            Vector3 limitDistanceMove = postionStart + (distanceMoveMouse.normalized * limitMove);
            lineRenderer.SetPosition(1, limitDistanceMove);
        }
    }


    private void stopAddForce()
    {
        isAddForce = false;
        lineRenderer.enabled = false;

        Vector3 positionStart = lineRenderer.GetPosition(0);
        Vector3 position = lineRenderer.GetPosition(1);

        Vector3 distanceMoveMouse = position - positionStart;

        Vector3 finalForce = distanceMoveMouse * forcaAdd;

        rigidbody.AddForce(-finalForce, ForceMode2D.Impulse);

        audioBall.Play();

    }

    public void ShowAnimation()
    {
        rigidbody.velocity = Vector2.zero;
        animator.Play("BallDown");
        
        Destroy(rigidbody.transform.gameObject, 1f);
        Destroy(this.gameObject, 1f);
    }
}
