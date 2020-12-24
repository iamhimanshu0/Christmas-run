using UnityEngine;

public class shoot : MonoBehaviour {
    Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(10, rb.velocity.y);
        Destroy(gameObject, 2f);
    }
	
}
