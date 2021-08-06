using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canMove : MonoBehaviour
{

    protected BoxCollider2D boxCollider;

    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 1.0f;
    protected float xSpeed = 1.0f;
    public float myXOffset = 0f;
    public float myYOffset = 0f;
    private Vector2 myPosition;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        
        // Reset moveDelta
        moveDelta = new Vector3 (input.x * xSpeed, input.y * ySpeed, 0);
        myPosition = new Vector2 (transform.position.x + myXOffset, transform.position.y + myYOffset);
        

        // Swap sprite direction when right or left
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //make sure we can move in the direction by casting a box tehre, if it's free we can move
        hit = Physics2D.BoxCast(myPosition, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            //Move!
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(myPosition, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            //Move!
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
