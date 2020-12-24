using UnityEngine;

public class platformCreater : MonoBehaviour {
    public GameObject platfrom;
    public Transform generatorpoint;
    public float distanceBetween;
    public float platfromwidth;
    public santaDead dead;
    public GameObject[] platfroms;
    public float maxDistance;
    public float minDistance;
    public Transform maxHeightPoint;
    public float maxHeightChange;

    private float hightChange;
    private float maxHeight;
    private float minHeight;
    private int curerntplatfrom;
    private float[] size;
    
    void Start()
    {
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.transform.position.y;

        size = new float[platfroms.Length];
        for (int i = 0; i <platfroms.Length; i++)
        {
            size[i] = platfroms[i].GetComponent<BoxCollider2D>().size.x;
        }
       // platfromwidth = platfrom.GetComponent<BoxCollider2D>().size.x;
    }
    void Update()
    {
        if(dead.isDead==false)
        {
            MakePlatfrom();
        }else
        {
            return;
        }
    }

    void MakePlatfrom()
    {
        if (transform.position.x < generatorpoint.position.x)
        {
           
            distanceBetween = Random.Range(minDistance, maxDistance);

            curerntplatfrom = Random.Range(0, platfroms.Length);

            hightChange = transform.position.y+Random.Range(maxHeightChange,-maxHeightChange);

            if(hightChange < maxHeight)
            {
                hightChange = maxHeight;
            }
            else if(hightChange > minHeight)
            {
                hightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + size[curerntplatfrom] + distanceBetween, hightChange, transform.position.z);
           
            for (int i=0;i<platfroms.Length;i++)
            {
                Instantiate(platfroms[curerntplatfrom], transform.position, transform.rotation);
            }
           
        }
    }
}
