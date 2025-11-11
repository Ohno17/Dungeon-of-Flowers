using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(target.position);
        if (viewportPoint.x < 0) gameObject.transform.position += Vector3.left;
    }
}
