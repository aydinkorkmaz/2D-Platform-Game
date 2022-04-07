using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   Transform playertransform;
    [SerializeField]float minx,maxx;
    void Start()
    {
        playertransform=GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(Mathf.Clamp(playertransform.position.x,minx,maxx),transform.position.y,transform.position.z);
    }
}
