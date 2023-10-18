using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform goal;
    public float speed = 3.0f;
    float distanceLimit;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(goal.position);
        distanceLimit = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position;
        if (direction.magnitude >= distanceLimit)
        {
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
