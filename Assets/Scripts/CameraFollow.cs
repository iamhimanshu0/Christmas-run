using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private SantaMove santa;

    private Vector3 lastposition;
    private float distancetoMove;
    public santaDead dead;

    void Start()
    {
        santa = FindObjectOfType<SantaMove>();
        lastposition = santa.transform.position;
    }

    void Update()
    {
        if(dead.isDead == false)
        {
            distancetoMove = santa.transform.position.x - lastposition.x;
            transform.position = new Vector3(transform.position.x + distancetoMove, transform.position.y, transform.position.z);
            lastposition = santa.transform.position;
        }
       
    }

}
