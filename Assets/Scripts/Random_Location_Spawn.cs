using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Location_Spawn : MonoBehaviour
{
    //Create an instance of the sheep prefab
    private int sheepColor;
    [SerializeField] private int numberOfSheep;
    [SerializeField] private GameObject White_Sheep;
    [SerializeField] private GameObject Black_White_Sheep;
    [SerializeField] private GameObject Black_Sheep;
    private Vector3 spawnPosition;
    //Pick a random sheep with a value of 1-3
    // Start is called before the first frame update
    void Start()
    {
        //Spawn sheep based on the number given in the editor.
        for (int i = 0; i < numberOfSheep; i++)
        {
            sheepColor = Random.Range(1, 4);
            //Get a random spawn point in the cameras view 
            spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
            //Spawn the sheep at the vectors location with no rotation
            if (sheepColor == 1)
            {
                Instantiate(White_Sheep, spawnPosition, Quaternion.identity);
            }
            else if(sheepColor == 2)
            {
                Instantiate(Black_White_Sheep, spawnPosition, Quaternion.identity);
            }
            else if (sheepColor == 3)
            {
                Instantiate(Black_Sheep, spawnPosition, Quaternion.identity);
            }
        }
    }

}
