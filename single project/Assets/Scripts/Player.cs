
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = Camera.main.WorldToViewportPoint(transform.position);
        if (Pos.x < 0f) Pos.x = 0f;
        if (Pos.x > 1f) Pos.x = 1f;
        if (Pos.y < 0f) Pos.y = 0f;
        if (Pos.y > 1f) Pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(Pos);
    }

    void FixedUpdate()
    {
        float moveX =  speed * Input.GetAxis("Horizontal");
        float moveY = speed * Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(moveX, moveY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        { 
           gameObject.SetActive(false);
           Time.timeScale = 0f;
           GameManager.Instance.GameOver();
        }
        else if(collision.CompareTag("Finish"))
        {
            Debug.Log("게임 클리어");
        }
    }
}
