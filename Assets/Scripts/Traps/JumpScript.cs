using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpPadForce;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Get smth");
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().getRb().AddForce(transform.up * jumpPadForce, ForceMode.Impulse);
        }
    }
}
