using UnityEngine;

public class PlataformFollowCamera : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    //public Vector3 offset;

    void Awake()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, followSpeed * Time.deltaTime);
    }
}
