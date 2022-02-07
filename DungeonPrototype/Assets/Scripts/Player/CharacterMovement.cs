using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    protected float xSpeed = 1.0f, ySpeed = 0.75f;

    Vector3 moveDelta;

    RaycastHit2D movementHit;

    BoxCollider2D myCollider;

    public bool hasPlayerTarget { get; set; }

    protected virtual void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void HandleMovement(float x,float y)
    {
        moveDelta = new Vector3(x * xSpeed, y * ySpeed,0.0f);

        movementHit = Physics2D.BoxCast(transform.position,myCollider.size,0.0f,new Vector2(0.0f,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask(TagManager.BLOCKING_LAYER_MASK));


        //if we are not collider with a specific layer mask
        if(movementHit.collider == null)
        {
            transform.Translate(0.0f, moveDelta.y * Time.deltaTime,0.0f);
        }

        movementHit = Physics2D.BoxCast(transform.position, myCollider.size, 0.0f, new Vector2(moveDelta.x, 0.0f), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask(TagManager.BLOCKING_LAYER_MASK));


        //if we are not collider with a specific layer mask
        if (movementHit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0.0f, 0.0f);
        }

    }

    public Vector3 GetMoveDelta()
    {
        return moveDelta;
    }


}
