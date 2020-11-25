using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksPool : MonoBehaviour
{
    private GameObject[] bricks;
    public int numOfBricks = 8;
    public GameObject brickPrefab;
    public float lastY = -11;
    private int lowestBrick = 0;

    private float timeSinceLastRelocation = 0f;

    public float timeBetweenRelocations = 5f;
    // Start is called before the first frame update
    void Start()
    {
        bricks = new GameObject[numOfBricks];
        for (int i = 0; i < numOfBricks; i++)
        {
            float xPos = Random.Range(-7, 7);
            lastY += 3;
            bricks[i] = (GameObject) Instantiate(brickPrefab, new Vector2(xPos, lastY), Quaternion.identity);

        }
        
    }
    

    // Update is called once per frame
    void Update()
    {
        timeSinceLastRelocation += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastRelocation > timeBetweenRelocations)
        {
            relocateLowestBrick();
            timeSinceLastRelocation = 0f;
        }


    }

    private void relocateLowestBrick()
    {
        float xPos = Random.Range(-7, 7);
        lastY += 3;
        bricks[lowestBrick].transform.position = new Vector3(xPos, lastY, 0);
        Renderer renderer = bricks[lowestBrick].GetComponent<Renderer>();
        
        lowestBrick++;
        if (lowestBrick >= numOfBricks)
        {
            lowestBrick = 0;
        }
    }
    
    
}
