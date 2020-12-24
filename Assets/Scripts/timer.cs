using UnityEngine;


public class timer : MonoBehaviour {

    GameManager game;
    public santaDead dead;
    public SantaMove move;
    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }
    
  

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            Debug.Log("we've add some time");
            game.TimerIncrease();
         
        }
        Destroy(gameObject);
    }
}
