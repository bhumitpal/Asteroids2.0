using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
 

    public GameObject asteroidPrefab;
    public float width = 50.0f;
    public float depth = 50.0f;
    /// <summary>

    float threshold = 0f;
    public float noiseStrength = 10.0f;
    GameObject parent;
    
    void Start()
    {
        Debug.Log("Asteroid Manager Initialize");
        threshold = Random.Range(0.5f, 0.7f);
        parent = new GameObject("AsteroidsCollection");
        //asteroidPrefab = Resources.Load<GameObject>("Prefabs/");

        //for (float x = 0; x < width; x += Random.Range(Random.Range(0f, 1f), Random.Range(0f, 1f)))
        //{
        //    for (float z = 0; z < depth; z += Random.Range(Random.Range(0f, 1f) * 0.37f, Random.Range(0f, 1f) * 0.37f))
        //    {
        //        float pcheck = Mathf.PerlinNoise((x / (width ) * noiseStrength ) + 0.37f, z / depth * noiseStrength );
        //        if (pcheck >= threshold)
        //        {
        //            GameObject asteroidObj =
        //            GameObject.Instantiate(asteroidPrefab,
        //                new Vector3(x + (10 - width / 2),
        //                    0,
        //                    z + (10 - depth / 2)),
        //                Random.rotation) as GameObject;
        //            asteroidObj.transform.SetParent(parent.transform);

        //            asteroid = asteroidObj.GetComponent<Asteroid>();
        //            asteroid.Initialize();
        //        }

        //    }
        //}       
        //player.transform.position



        for (float x = 0; x < width; x += Random.Range(1f, 1f))
        {
            for (float z = 0; z < depth; z += Random.Range(1f, 1f))
            {
                float pcheck = Mathf.PerlinNoise(x / width * noiseStrength, z / depth * noiseStrength);
                if (pcheck*(Random.Range(0f,2f)) >= threshold*(Random.Range(1f,2f)))
                {
                    GameObject asteroidObj =
                    GameObject.Instantiate(asteroidPrefab,
                        new Vector3(x + (10 - width / 2),
                                            0,
                                            z + (10 - depth / 2)),
                        Random.rotation) as GameObject;
                    asteroidObj.transform.SetParent(parent.transform);
                }
            }
        }

        Debug.Log("Number of asteroid : "+parent.transform.childCount);

    }

}
