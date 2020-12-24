using UnityEngine;

public class ObjectSpawnner : MonoBehaviour {
    public GameObject[] create;
    public Transform[] points;

    private int currentPoint;
    private int currentCreate;

    public float timeBetweenWaves = 2f;
    public float timetospawn = 3f;

    santaDead dead;

    void Start()
    {
        dead = FindObjectOfType<santaDead>();
    }
    void Update()
    {
      

        if(dead.isDead == false)
        {
            if (Time.time >= timetospawn)
            {
                Spawnner();
                timetospawn = Time.time + timeBetweenWaves;

            }
        }
       
    }

    void Spawnner()
    {
      

        currentCreate = Random.Range(0, create.Length);
        int randomIndex = Random.Range(0, points.Length);
        for (int i = 0; i < points.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(create[currentCreate], points[i].position, Quaternion.identity);
            }
        }
    }

}
