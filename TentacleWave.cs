using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
[ExecuteInEditMode]
public class TentacleWave : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    [Max(360)]
    private float angle = 0;
    [SerializeField]
    private float mul = 1;
    private Transform cacheTrans;
    private float activeSpeed;

    void Start()
    {
        cacheTrans = transform;
        activeSpeed =speed* Random.Range(0.7f, 1f + 0.1f);
    }


    void Update()
    {
        cacheTrans.localRotation = Quaternion.Euler(Vector3.forward * mul * Mathf.Sin(activeSpeed * Time.time) * angle);
    }
}
