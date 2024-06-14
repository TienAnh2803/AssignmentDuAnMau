using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target; // The target object to follow
    Vector3 velocity = Vector3.zero;

    [Range(0,1)]
    public float smoothSpeed; 

    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit;
    public Vector2 yLimit;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
       
            Vector3 targetPosition = target.position + positionOffset ;
            targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y)
            ,Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

          
     
    }
}