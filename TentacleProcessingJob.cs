using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines.Interpolators;

public struct TentacleProcessingJob : IJobParallelFor
{
    public NativeArray<Vector3> lineVertices;
    public float deltaTime;
    public float speed;
    public float dist;
    public Vector3 targetDir;
    public void Execute(int index)
    {
        if (index == 0)
            return;
        lineVertices[index] = Vector3.Lerp(lineVertices[index], lineVertices[index - 1]+targetDir*dist, speed * deltaTime);
    }
}
