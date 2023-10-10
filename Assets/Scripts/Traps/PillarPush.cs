using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPush : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float pushForce;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.transform.position - transform.position;

            //Vector2 knockbackVelocity = new Vector2((transform.position.x - collision.transform.position.x) * pushForce, (transform.position.y - collision.transform.position.y) * pushForce);
            //collision.gameObject.GetComponent<Rigidbody>().velocity = -knockbackVelocity;

            //Debug.DrawLine(transform.position, transform.position + pushDirection.normalized * 10, Color.red, Mathf.Infinity);

            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
            
        }
    }
}
