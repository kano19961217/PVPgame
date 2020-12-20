using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform[] playerTransforms;
    public float yOffset = 3f;
    public float minDistance = 22f;
    private float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        playerTransforms = new Transform[allPlayers.Length];
        for (int i = 0; i < allPlayers.Length; i++)
        {
            playerTransforms[i] = allPlayers[i].transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransforms.Length == 0)
        {
            Debug.Log("找不到角色");
            return;
        }

        xMin = xMax = playerTransforms[0].position.z;
        yMin = yMax = playerTransforms[0].position.y;
        for (int i = 1; i < playerTransforms.Length; i++)
        {
            if (playerTransforms[i].position.z < xMin)
            {
                xMin = playerTransforms[i].position.z;
            }

            if (playerTransforms[i].position.z > xMax)
            {
                xMax = playerTransforms[i].position.z;
            }

            if (playerTransforms[i].position.y < yMin)
            {
                yMin = playerTransforms[i].position.y;
            }

            if (playerTransforms[i].position.y > yMax)
            {
                yMax = playerTransforms[i].position.y;
            }
        }

        float xMiddle = (xMin + xMax) / 2;
        float yMiddle = (yMin + yMax) / 2;
        float distance = xMax - xMin + 14f;
        if (distance < minDistance)
        {
            distance = minDistance;
        }


        transform.position = new Vector3(-distance - 4f, yMiddle + yOffset, xMiddle);
    }
}
