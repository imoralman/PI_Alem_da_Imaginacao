using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataforma : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();
    public List<Transform> currentPlatforms = new List<Transform>();

    public int offset;

    private Transform player;
    private Transform currentPlatformPoint;
    public int platformIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++)
        {
            Transform p = Instantiate(platforms[i], new Vector3(0, 0, i * 45), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 45;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platforms>().Point;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlatformPoint.position.z;

        if(distance >= 5)
        {
            Recicla(currentPlatforms[platformIndex].gameObject);
            platformIndex++;
        
            if(platformIndex > currentPlatforms.Count - 1)
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platforms>().Point;
        }

    }

    public void Recicla(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += 45;
    }
}
