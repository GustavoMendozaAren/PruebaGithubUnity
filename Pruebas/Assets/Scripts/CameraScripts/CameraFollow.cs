using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset, rotationVector = new Vector3(22,0 , 0);

    private void Start()
    {
        //Quaternion rotation = Quaternion.Euler(rotationVector);
    }
    void LateUpdate()
    {

        transform.position = target.position + offset;
        transform.rotation = target.rotation;
    }

}
