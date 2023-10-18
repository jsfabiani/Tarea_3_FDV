using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement3 : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html

    private GameObject currentWaypoint;
    private GameObject previousWaypoint;
    private GameObject nextWaypoint;

    public float speed = 3.0f;
    public float rotationSpeed = 1.5f;
    
    GameObject FindClosestWaypoint()
    //Encuentra el Waypoint más cercano al jugador (código basado en documentación de "FindGameObjectsWithTag")
    {
        GameObject[] allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        GameObject closestWaypoint = null;
        float distance = float.PositiveInfinity;

        foreach (GameObject waypoint in allWaypoints)
        {
            Vector3 currentDistance = waypoint.transform.position - this.transform.position;
            if (currentDistance.sqrMagnitude < distance)
            {
                distance = currentDistance.sqrMagnitude;
                closestWaypoint = waypoint;
            }
        }


        return closestWaypoint;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = FindClosestWaypoint();
        previousWaypoint = null;    
        nextWaypoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = currentWaypoint.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * rotationSpeed);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);

        //Cambia el Tag del waypoint actual para que no vuelva a seleccionarlo como objetivo, y busca un nuevo objetivo.
        
        currentWaypoint.tag = "DepletedWp";
        nextWaypoint = FindClosestWaypoint();

        //Restaura el waypoint anterior para que vuelva a ser un objetivo posible.
        if (previousWaypoint != null) 
        {
            previousWaypoint.tag = "Waypoint";
        }

        //Almacena el waypoint actual como waypoint anterior, y cambia el waypoint actual al próximo waypoint. Después, borra el próximo waypoint.
        previousWaypoint = currentWaypoint;
        currentWaypoint = nextWaypoint;
        nextWaypoint = null;
        
    }
}