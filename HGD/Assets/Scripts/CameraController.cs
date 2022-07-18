using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        Vector3 smooth = Vector3.Lerp(transform.position, targetPos, 3 * Time.fixedDeltaTime);
        transform.position = smooth;
    }
}
