using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDrawRoad : MonoBehaviour
{
    [SerializeField] ParticleSystem playerParticleSystem;
    [SerializeField] Transform playerTransform;
    [SerializeField] float playerMoveSpeed;

    private float distance;
    private float minDistance = 0.1f;

    private Vector3 position;

    private void Start()
    {
        playerParticleSystem.Play(); // we start the particleSystem 
    }
    internal void MoveOnTheRoad(List<Vector3> vector3s, float time)
    {
        //We start the Coroutine and run it after the variable we have given
        StartCoroutine(OnTheDrawnRoute(vector3s, time));
    }
    IEnumerator OnTheDrawnRoute(List<Vector3> vector3s, float time)
    {
        yield return new WaitForSeconds(time);

        for (int i = 0; i < vector3s.Count; i++)
        {
            distance = Vector3.Distance(playerTransform.transform.position, vector3s[i]); //we calculate the distance between the drawn lines 

            while (distance > minDistance)
            {
                position = Vector3.MoveTowards(playerTransform.transform.position, vector3s[i], playerMoveSpeed * Time.fixedDeltaTime); //we move to the way we draw
                playerTransform.transform.LookAt(position);
                playerTransform.transform.position = position; //renewing your new position 
                distance = Vector3.Distance(playerTransform.transform.position, vector3s[i]);
                yield return null;
            }
        }
    }
}

