using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawaRoad : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float minDistance;
    [SerializeField] List<Vector3> roadPositions = new List<Vector3>(); //we write the list to hold our coordinates 

    public LineRenderer lr=null;

    //We write our variables on the axis
    Vector3 mousePosition;
    Vector3 position;
    Vector3 prePosition;

    float distance = 0;
    float time = 0f;
    void Update()
    {
        DrawTheLine();
    }

    private void DrawTheLine()
    {
        //we calculate the positions and create the new position 
        if (Input.GetMouseButtonDown(0))
        {
            MousePositioning();
            prePosition = position;
            roadPositions.Add(position);
        }
        else
        {
            //we calculate the lengths 
            if (Input.GetMouseButton(0))
            {
                MousePositioning();
                distance = Vector3.Distance(position, prePosition);

                if (distance >= minDistance) //If it is greater than the minimum value we give, let's draw our line 
                {
                    prePosition = position;
                    roadPositions.Add(position);
                    lr.positionCount = roadPositions.Count;
                    lr.SetPositions(roadPositions.ToArray());
                }
            }
            else
            {
                //When the mouse left click is released, we provide its movement with the method we wrote. 
                if (Input.GetMouseButtonUp(0))
                {
                    GameManager.instance.followDrawRoad.MoveOnTheRoad(roadPositions, time);
                }
            }
        }
    }

    private void MousePositioning()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z= 19; //z coordinate of our player, we gave a manual coordinate so that our mouse can detect the z coordinate 
        position = mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
