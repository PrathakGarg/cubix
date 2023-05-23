using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private Vector3 offset = new(0f, 2f, -4f);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player) return;

        transform.position = player.position + offset;
    }
}
