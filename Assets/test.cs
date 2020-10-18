using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody rb;
    private Transform transform;
    private Camera cam;
    private Vector3 coor;
    public float speed = 10f;
    // Start is called before the first frame update



    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * speed;
        coor = cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,cam.transform.position.z));
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.y < coor.y)
        {
             Destroy(this.gameObject);
        }
    }

}