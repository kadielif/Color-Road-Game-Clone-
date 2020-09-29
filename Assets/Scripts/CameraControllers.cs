using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraControllers : MonoBehaviour
{
    public Transform target;
    Vector3 distance;

    void Start()
    {
        distance.z = transform.position.z - target.transform.position.z;
    }
    #region Singleton
    public static CameraControllers instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Update()
    {
        if (target == null) return;
        transform.position =new Vector3(0,transform.position.y,target.transform.position.z + distance.z);
        //Vector3 pos = target.position + (target.forward * -5f) + (target.up * 10f);
        //transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
        //Vector3 dir = target.position - transform.position;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 3f);
    }
}