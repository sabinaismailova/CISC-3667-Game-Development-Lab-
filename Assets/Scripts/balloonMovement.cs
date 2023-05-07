using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloonMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 screenMin;
    [SerializeField] Vector2 screenMax;
    [SerializeField] float objectWidth;
    [SerializeField] float objectHeight;
    [SerializeField] Sprite balloonPopDone;
    [SerializeField] double size;
    [SerializeField] int points;
    [SerializeField] int level;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float randomY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        gameObject.transform.position = randomPosition;

        size = transform.localScale.x;
        level = SceneManager.GetActiveScene().buildIndex;

        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 4*level;

        camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        rigid.velocity = new Vector2(speed, speed);
        //rigid.velocity = new Vector2(rigid.velocity.x, speed);

        InvokeRepeating("Grow", (float)1.0, (float)1.0);

        animator = GetComponent<Animator>();

        points = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>(screenMax.x - objectWidth)||transform.position.x<(screenMin.x + objectWidth)){
            speed = speed*(-1);
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
            Flip();
        }
        if(transform.position.y>(screenMax.y - objectHeight)||transform.position.y<(screenMin.y + objectHeight)){
            speed = speed*(-1);
            rigid.velocity = new Vector2(rigid.velocity.x, speed);
            Flip();
        }
        if(transform.localScale.x>2){
            Destroy(gameObject, (float)0.1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        if(other.gameObject.tag == "pin"){
            PersistentData.Instance.GetAudio().Play();
            GameObject.Find("Scorekeeper").GetComponent<Scorekeeper>().AddPoints(points);
            GameObject.Find("dragonfly").GetComponent<DragonflyMovement>().chasingRate = 0;
            animator.Play("balloonPop");
            Destroy(gameObject, (float)0.5);
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Grow()
    {
        size += 0.2;
        transform.localScale = new Vector3((float)size, (float)size, transform.localScale.z);
        points -= 1;
    }
}
