using UnityEngine;

public class destroyenemy : MonoBehaviour {

   void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Enemy")
        {
            Destroy(col.gameObject);
        }else if(col.gameObject.tag=="Score")
        {
            Destroy(col.gameObject);
        }
    }
       
	
}
