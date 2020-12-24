using UnityEngine;

public class santaDead : MonoBehaviour {

    public bool isDead = false;
    public Animator anim;

    ShowAds ads;
    void Start()
    {
        ads = FindObjectOfType<ShowAds>();
    }

    public void OnDead()
    {
        isDead = true;
        anim.SetTrigger("dead");
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            ads.Show();
            OnDead();

        }else if(col.tag=="kill")
        {
            Destroy(col.gameObject);
        }else if(col.tag=="score")
        {
            Destroy(col.gameObject);
        }
    }

    
}
