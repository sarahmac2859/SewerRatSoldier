using UnityEngine;

public class LeftRatScript : MonoBehaviour {
    public float lspeed = 10.0f;
    private Rigidbody2D rigid;
    private Vector2 leftBounds;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(lspeed, 0);
        leftBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x > leftBounds.x){
            Destroy(gameObject);
        }
    }
}

