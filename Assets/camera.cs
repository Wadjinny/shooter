using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    bool hadtouch = false;
    public GameObject origin;
    public GameObject target;
    public Color col;
    RaycastHit vis;
    public AnimationCurve curve;
    void Start()
    {
        Input.gyro.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 directions = origin.transform.position - target.transform.position;
        Quaternion rot = GetComponent<Transform>().rotation;
        float rotation = (curve.Evaluate(4*Input.gyro.attitude.y/Mathf.PI+1/2)-1/2)*Mathf.PI/4;
        GetComponent<Transform>().rotation = new Quaternion( rot.x, rotation, rot.z, rot.w);
        if (Input.touchCount > 0 && !hadtouch)
        {
            Debug.Log( Physics.Raycast(origin.transform.position,directions,out vis));
            vis.collider.gameObject.GetComponent<MeshRenderer>().material.color=col;  
            hadtouch = true;
        }
        if(Input.touchCount==0)
        {
            hadtouch = false;
        }
    }

}
