using UnityEngine;
using System.Collections.Generic;

public class BalloonSpawner : MonoBehaviour
{
    [System.Serializable]
    public class BalloonInfo
    {
        public GameObject balloonPrefab;
        public int pointValue;
    }

    public List<BalloonInfo> balloonTypes = new List<BalloonInfo>();

    public float spawnInterval = 1.5f;           
    public float minX = -7f, maxX = 7f;          
    public float groundY = -5f;                 
    public float minSpeed = 2f, maxSpeed = 5f;   
    public float destroyY = 6f;                 

    void Start()
    {
        if (balloonTypes.Count == 0)
        {
            return;
        }
        InvokeRepeating("SpawnBalloon", 1f, spawnInterval);
    }

    void SpawnBalloon()
    {
        if (balloonTypes.Count == 0) return;

        int randomIndex = Random.Range(0, balloonTypes.Count);
        GameObject selectedPrefab = balloonTypes[randomIndex].balloonPrefab;
        int pointValue = balloonTypes[randomIndex].pointValue;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, groundY, 0f);

        GameObject balloon = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Rigidbody2D rb = balloon.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, randomSpeed);
        }

        BalloonDestroyer destroyer = balloon.GetComponent<BalloonDestroyer>();
        if (destroyer == null)
        {
            destroyer = balloon.AddComponent<BalloonDestroyer>();
        }
        destroyer.destroyY = destroyY;
        destroyer.pointValue = pointValue;
    }
}
