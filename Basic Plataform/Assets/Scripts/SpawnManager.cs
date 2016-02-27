using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform; // for the platform prefact
    // Max distance to the new platform, horit and vert
    public float horizontalMin = 7.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6;
    
    private Vector2 _originPosition;

    // Use this for initialization
    void Start () {

        _originPosition = transform.position;
        Spawn();

    }

    //Function to generate new platforms
    void Spawn(){
        for (int i = 0; i < maxPlatforms; i++){
            Vector2 randomPosition = _originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            //Instantiate -- Clones the original object and returns the clone
            // Quaternion are used to represent rotation. Quaternion.identify = no rotation
            Instantiate(platform, randomPosition, Quaternion.identity);
            _originPosition = randomPosition;
        }
    }
}
