using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 screenMin;
    [SerializeField] Vector2 screenMax;
    [SerializeField] float objectWidth;
    [SerializeField] float objectHeight;


    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 8;

        camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x==(screenMax.x - objectWidth)||transform.position.x==(screenMin.x + objectWidth)){
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        screenMin = camera.ViewportToWorldPoint(Vector2.zero);
        screenMax = camera.ViewportToWorldPoint(Vector2.one);
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenMin.x + objectWidth, screenMax.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenMin.y + objectHeight, screenMax.y - objectHeight);
        transform.position = viewPos;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "target"){
            Destroy(gameObject, (float)0.1);
        }
    }

}
