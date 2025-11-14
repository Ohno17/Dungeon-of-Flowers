using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void ChangeRoomEventHandler(object sender, Vector3Int newRoomPosition);
    public static event ChangeRoomEventHandler ChangeRoomEvent;
    public delegate void PuzzleResetEventHandler(object sender);
    public static event PuzzleResetEventHandler PuzzleResetEvent;

    [HideInInspector] public static int flowers = 0;
    [HideInInspector] public Vector3Int roomPosition;

    private Vector3Int lastRoomPosition;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.AfterMoveEvent += AfterMove;
        roomPosition = Vector3Int.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) PuzzleResetEvent?.Invoke(this);
    }

    void AfterMove(object sender, Vector3Int newPosition)
    {
        lastRoomPosition = roomPosition;
        roomPosition = GameUtils.TileRoomPosition(newPosition);
        if (roomPosition != lastRoomPosition)
        {
            ChangeRoomEvent?.Invoke(this, roomPosition);
        }
    }
}
