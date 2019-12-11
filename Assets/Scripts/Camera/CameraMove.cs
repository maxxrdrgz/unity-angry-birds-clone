﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float dragSpeed = 0.01f;
    private float timeDragStarted;
    private Vector3 prevPosition;
    public SlingShot slingShot;
    // Update is called once per frame
    void Update()
    {
        if(slingShot.slingshotState == SlingshotState.Idle && GameManager.gameState == GameState.Playing){
            if(Input.GetMouseButtonDown(0)){
                timeDragStarted = Time.time;
                dragSpeed = 0f;
                prevPosition = Input.mousePosition;
            }else if(Input.GetMouseButton(0) && Time.time - timeDragStarted > 0.005f){
                Vector3 input = Input.mousePosition;
                float deltaX = (prevPosition.x - input.x) * dragSpeed;
                float deltaY = (prevPosition.y - input.y) * dragSpeed;

                float newX = Mathf.Clamp(transform.position.x + deltaX, 0, 13);
                float newY = Mathf.Clamp(transform.position.y + deltaY, 0, 2.7f);

                transform.position = new Vector3(newX, newY, transform.position.z);
                prevPosition = input;

                if(dragSpeed < 0.1f){
                    dragSpeed += 0.002f;
                }
            }
        }
    }
}
