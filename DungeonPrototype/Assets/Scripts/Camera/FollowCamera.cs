using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform playerTarget;

    [SerializeField]
    float boundX = 0.3f, boundY = 0.15f;

    float deltaX, deltaY;

    Vector3 deltaPosition;

    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void LateUpdate()
    {
        if(!playerTarget)
        {
            return;
        }

        deltaPosition = Vector3.zero;

        deltaX = playerTarget.position.x - transform.position.x;

        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < playerTarget.position.x)
            {
                deltaPosition.x = deltaX - boundX;
            }
            else
            {
                deltaPosition.x = deltaX + boundX;
            }
        }

        deltaY = playerTarget.position.y - transform.position.y;


        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < playerTarget.position.y)
            {
                deltaPosition.y = deltaY - boundY;
            }
            else
            {
                deltaPosition.y = deltaY + boundY;
            }
        }


        deltaPosition.z = 0.0f;

        transform.position += deltaPosition;

    }

}
