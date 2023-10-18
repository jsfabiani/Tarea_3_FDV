using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController5 : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 1.0f;
    public float maxSpeed = 3.0f;
    Vector3 maxVelocityHoriz;
    Vector3 maxVelocityVert;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        maxVelocityHoriz = new Vector3 (0, 0, 1.0f) * maxSpeed;
        maxVelocityVert = new Vector3(1.0f, 0, 0.0f) * maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 VelocityVert = new Vector3(m_Rigidbody.velocity.x, 0, 0);
        Vector3 VelocityHoriz = new Vector3(0, 0, m_Rigidbody.velocity.z);
       

        if (Input.GetAxis("Vertical") != 0)
        {
            if (VelocityVert.magnitude < maxSpeed)
            {
                m_Rigidbody.AddForce(m_Thrust * Input.GetAxis("Vertical"), 0, 0);
            }
        }
        else
        {
            m_Rigidbody.velocity = new Vector3 (0, m_Rigidbody.velocity.y, m_Rigidbody.velocity.z);
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            if (VelocityHoriz.magnitude < maxSpeed)
            {
                m_Rigidbody.AddForce(0, 0, -m_Thrust * Input.GetAxis("Horizontal"));
            }
        }
        else
        {
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y, 0);
        }

    }
}
