using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] float movementHorizontal;
    [SerializeField] float movementVertical;
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
        speed = 15;

        camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        movementVertical = Input.GetAxis("Vertical");

        if (movementHorizontal < 0 && isFacingRight || movementHorizontal > 0 && !isFacingRight)
            Flip();

    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movementHorizontal * speed, rigid.velocity.y);
        rigid.velocity = new Vector2(rigid.velocity.x, movementVertical * speed);
        if (movementHorizontal < 0 && isFacingRight || movementHorizontal > 0 && !isFacingRight)
            Flip();
    }

    void LateUpdate()
    {
        screenMin = camera.ViewportToWorldPoint(Vector2.zero);
        screenMax = camera.ViewportToWorldPoint(Vector2.one);
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenMin.x + objectWidth, screenMax.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenMin.y + objectHeight, screenMax.y - objectHeight);
        transform.position = viewPos;
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
 
}
