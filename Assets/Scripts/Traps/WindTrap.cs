using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrap : MonoBehaviour {

    [Header("Wind propeties")]
    [SerializeField] private List<Rigidbody> RigidbodiesInWindZoneList = new List<Rigidbody>();
    [SerializeField] private Vector3 windDirection = Vector3.right;
    [SerializeField] private float windStrength = 5;
    [SerializeField] private GameObject windFX;
    [Header("Trap cooldown")]
    [SerializeField] private float changeCD = 2;
    [SerializeField] private float timeToChange = 0;

    private void Start()
    {
        timeToChange = changeCD;
        windFX.transform.rotation = Quaternion.LookRotation(windDirection, Vector3.up);

    }

    private void Update()
    {
        if (timeToChange > 0)
        {
            timeToChange -= Time.deltaTime;
        } else if (timeToChange <= 0) 
        {
            windDirection = Random.insideUnitSphere.normalized;
            windDirection.y = 0;
            windFX.transform.rotation = Quaternion.LookRotation(windDirection, Vector3.up); 
            timeToChange = changeCD;
        }   
    }

    private void OnTriggerEnter(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
        if(objectRigid != null)
            RigidbodiesInWindZoneList.Add(objectRigid);
    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();
		if (objectRigid != null)
			RigidbodiesInWindZoneList.Remove(objectRigid);
    }

    private void FixedUpdate()
    {
        if(RigidbodiesInWindZoneList.Count > 0) {
            foreach (Rigidbody rigid in RigidbodiesInWindZoneList)
            {
                rigid.AddForce(windDirection * windStrength);
            }
        }
    }
}
