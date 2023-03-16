using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPins : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject pin;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            SpawnPin();
        }
    }

    void FixedUpdate(){
        
    }

    void SpawnPin(){
        Vector2 position = rigid.position;
        Instantiate(pin, position, Quaternion.identity);
    }
}
