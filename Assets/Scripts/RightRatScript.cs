using UnityEngine;

public class RightRatScript : MonoBehaviour {
    public float speed = 10.0f;
    private Rigidbody2D _rb;
    private Vector2 _screenBounds;


    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(-speed, 0);
        if (!(Camera.main is null))
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * -1, Screen.height * -1,
                Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x < _screenBounds.x){
            Destroy(gameObject);
        }
    }
}
