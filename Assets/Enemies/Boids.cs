using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    public float avoidDistance;
    public float avoidFactor;
    public float targetFactor;
     
    // Start is called before the first frame update
    public Vector3 CalculateBoid(List<GameObject> obstacleList, List<GameObject> neighborList, Transform targetPosition)
    {
        GameObject boid = this.gameObject;
        Vector3 finalVector, centerVector, avoidVector, targetVector = new Vector3(0,0,0);
        centerVector = CalculateCenterVector(neighborList, boid);
        avoidVector = CalculateAvoidVector(neighborList, boid);
        targetVector = CalculateTargetVector(targetPosition, boid);
        finalVector = avoidVector + targetVector;
        return finalVector;
    }

    private Vector3 CalculateCenterVector(List<GameObject> neighborList, GameObject boid)
    {
        Vector3 centerVector = Vector3.zero; 
        if (neighborList.Count == 0)
            return Vector3.zero;
        foreach (GameObject gameObject in neighborList)
        {
            centerVector = centerVector + gameObject.transform.position;
        }
        centerVector = centerVector / (neighborList.Count);
        return (centerVector - transform.position).normalized;
    }
    private Vector3 CalculateAvoidVector(List<GameObject> obstacleList, GameObject boid)
    {
        Vector3 avoidVector = Vector3.zero;
        int nAvoid = 0;

        if (obstacleList.Count == 0)
            return Vector3.zero;
        foreach (GameObject gameObject in obstacleList)
        {
            if(gameObject != boid && Vector3.SqrMagnitude(boid.transform.position - gameObject.transform.position) < avoidDistance)
            {
                nAvoid++;
                avoidVector +=  (boid.transform.position - gameObject.transform.position);
            }
        }
        if (nAvoid > 0)
            avoidVector /= nAvoid;
        return avoidVector.normalized*avoidFactor;

    }
    private Vector3 CalculateTargetVector(Transform targetPosition, GameObject boid)
    {
        return (targetPosition.position - boid.transform.position).normalized * targetFactor;
    }
}
