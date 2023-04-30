using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonflyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Camera camera;
    [SerializeField] Vector2 screenMin;
    [SerializeField] Vector2 screenMax;
    [SerializeField] float objectWidth;
    [SerializeField] float objectHeight;
    [SerializeField] float chasingRate;
    [SerializeField] float level;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float randomY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        gameObject.transform.position = randomPosition;

        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        level = (float)SceneManager.GetActiveScene().buildIndex;
        chasingRate = level*0.002f;
        if(chasingRate>0.008f){
            chasingRate = 0.008f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x==(screenMax.x - objectWidth)||transform.position.x==(screenMin.x + objectWidth)){
            Flip();
        }
        if(Time.timeScale==1)
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, chasingRate);
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

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //restart scene if the bee makes contact with the dragonfly 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
