using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
[ExecuteInEditMode]
public class Tentacle : MonoBehaviour
{
    private NativeArray<Vector3> verticesNative;
    [SerializeField]
    private Transform targetTrans;
    private JobHandle handle;
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private float speed;
    [SerializeField]
    [Min(2)]
    private int jointLength;
    private TentacleProcessingJob tenJob;
    [SerializeField]
    private float distBetween;
    
    void Start()
    {
        verticesNative = new NativeArray<Vector3>(jointLength, Allocator.TempJob);
        line.SetPositions(verticesNative.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        verticesNative[0] = targetTrans.position;
        tenJob = new TentacleProcessingJob
        {
            lineVertices = verticesNative,
            deltaTime = Time.deltaTime,
            speed = this.speed,
            dist = distBetween,
            targetDir = -targetTrans.up
        };
        handle = tenJob.Schedule(jointLength, 64);
       
        
    }
    private void LateUpdate()
    {
        handle.Complete();
        verticesNative = tenJob.lineVertices;
        line.SetPositions(verticesNative.ToArray());
    }
}
