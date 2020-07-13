using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkObject : MonoBehaviour
{
    [Help("At scene must have player/object with tag 'Player'", UnityEditor.MessageType.Warning)] //->HelpAttribure.cs (Manual Scripts). Put that in comment if you don't 
                                                                                                                                                       //have this script.
    [Tooltip("Object will randomly change position at selected area.")]
    public Transform randomTargetPosition;
    public float speed = 3.0f;
    [Tooltip("Change target position once it collide with an object with specific tag name.")]
    public string tagName = "wall";
    float dist, xpos, zpos, distanceFromPlayer;
    [Header("Position at x axis")]
    public float xMin = -40.0f;
    public float xMax = 40.0f;
    [Header("Position at z axis")]
    public float zMin = -40.0f;
    public float zMax = 40.0f;
    [Space(5)]
    [Tooltip("Set hieght at which object will respawn from current position at y axis.")]
    public float respawnHieght=10.0f;
    Vector3 direction, playerPosition;

    void Update()
    {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        dist = Vector3.Distance(randomTargetPosition.position, transform.position);
        if(playerPosition != null)
        {
            distanceFromPlayer = Vector3.Distance(playerPosition, transform.position);
            print((int)distanceFromPlayer);
        }
        else
        {
            print("Can't find player");
        }
        direction = new Vector3(xpos, randomTargetPosition.position.y+ respawnHieght, zpos);
        transform.position = Vector3.MoveTowards(transform.position, randomTargetPosition.position, speed * Time.deltaTime);
        transform.LookAt(new Vector3(randomTargetPosition.position.x, transform.position.y, randomTargetPosition.position.z));

        if (dist <= 5)
        {
            xpos = Random.Range(xMin, xMax);
            zpos = Random.Range(zMin, zMax);
            randomTargetPosition.position = direction;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == tagName)
        {
            xpos = Random.Range(xMin, xMax);
            zpos = Random.Range(zMin, zMax);
            randomTargetPosition.position = direction;
        }
    }
}
