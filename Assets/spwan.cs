using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan : MonoBehaviour
{   
    public GameObject go;
    public float respawnTime;
    private Transform transform;
    private Vector3 coor;
    private Vector3 bound;
    void Start()
    {

        transform = GetComponent<Transform>();
        StartCoroutine(timeIntervel());
        coor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bound = go.GetComponent<Renderer>().bounds.size;
    }

    IEnumerator timeIntervel()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(respawnTime);
            GameObject a = Instantiate(go) as GameObject;
            a.transform.position = new Vector3(Random.Range(bound.x+coor.x,-coor.x-bound.y),-coor.y, a.transform.position.z);
               
        }
    }
}
