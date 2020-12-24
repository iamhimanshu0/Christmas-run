using UnityEngine;

public class platformDestroyer : MonoBehaviour {

    public GameObject destroyerPoint;

    void Start()
    {
        destroyerPoint = GameObject.Find("platfromDestroyerPoint");
    }
    void Update()
    {
        if(transform.position.x < destroyerPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
