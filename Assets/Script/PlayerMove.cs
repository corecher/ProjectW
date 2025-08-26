using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumppower;
    public Rigidbody2D rb;
    public bool jumpcount;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        move();
        jump();
    }
    void move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 pp = new Vector2(x,0);
        transform.position+=(Vector3)(pp*moveSpeed*Time.deltaTime);
    }
    void jump()
    {
        if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))&&jumpcount)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector3.up * jumppower);
            jumpcount=false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            jumpcount=true;
        }
    }
}
