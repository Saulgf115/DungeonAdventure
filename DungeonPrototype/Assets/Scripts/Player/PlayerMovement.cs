using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    float moveX, moveY;

    Camera mainCamera;

    Vector2 mousePosition;
    Vector2 direction;
    Vector3 tempScale;

    Animator animator;


   

    protected override void Awake()
    {
        base.Awake();

        mainCamera = Camera.main;

        animator = GetComponent<Animator>();

    }


    private void FixedUpdate()
    {
        moveX = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
        moveY = Input.GetAxisRaw(TagManager.VERTICAK_AXIS);

        HandlePlayerTurning();

        HandleMovement(moveX,moveY);
    }

    void HandlePlayerTurning()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x,mousePosition.y - transform.position.y).normalized;

        HandlePlayerAnimation(direction.x, direction.y);

    }

    void HandlePlayerAnimation(float x,float y)
    {
        x = Mathf.RoundToInt(x);

        y = Mathf.RoundToInt(y);


        tempScale = transform.localScale;

        if(x > 0)
        {
            tempScale.x = Mathf.Abs(tempScale.x);

        }else if(x < 0)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }


        transform.localScale = tempScale;


        x = Mathf.Abs(x);


        animator.SetFloat(TagManager.FACE_X_ANIMATION_PARAMETER,x);

        animator.SetFloat(TagManager.FACE_Y_ANIMATION_PARAMETER,y);
    }

}
