using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GridMover mover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.ChangeRoomEvent += ChangeRoom;
        mover.SetPositionAtomic(Vector3Int.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameManager.ChangeRoomEvent -= ChangeRoom;
    }

    void ChangeRoom(object sender, Vector3Int newRoomPosition)
    {
        mover.SetPositionAtomic(newRoomPosition * new Vector3Int(GameUtils.ROOM_WIDTH, GameUtils.ROOM_HEIGHT));
    }
}
