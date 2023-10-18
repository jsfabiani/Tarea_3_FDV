using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtoRectilinioQuaternions2 : MonoBehaviour
{
    public Transform goal;
    public float speed = 3.0f;
    public float rotationSpeed = 1.5f;
    public float distanceLimit = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * rotationSpeed);
        if (direction.magnitude >= distanceLimit)
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
