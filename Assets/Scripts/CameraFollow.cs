using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate(){
            Vector3 temp = transform.position;
            {temp.x = target.position.x;}
            {temp.y = target.position.y;}
            transform.position = temp;
    }
}
