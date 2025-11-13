using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int flowers = 0;
    [HideInInspector] public Vector3Int roomPosition;

    [SerializeField] private GridMover playerMover;
    [SerializeField] private GridMover cameraMover;
    private Vector3Int lastRoomPosition;

    // Start is called before the first frame update
    void Start()
    {
        roomPosition = new(0, 0);
        cameraMover.SetPositionAtomic(roomPosition * new Vector3Int(GameUtils.ROOM_WIDTH, GameUtils.ROOM_HEIGHT));
    }

    // Update is called once per frame
    void Update()
    {
        lastRoomPosition = roomPosition;
        roomPosition = GameUtils.TileRoomPosition(playerMover.gridPosition);
        if (roomPosition != lastRoomPosition)
        {
            // Reset boxes in just-entered room
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameUtils.BOX_TAG))
            {
                GridMover boxMover = gameObject.GetComponent<GridMover>();
                if (GameUtils.TileRoomPosition(boxMover.gridPosition) == lastRoomPosition) boxMover.ResetPosition();
            }
            playerMover.initalPosition = playerMover.gridPosition;
        }

        if (Input.GetKeyDown(KeyCode.R)) ResetCurrentRoom();

        cameraMover.SetPositionAtomic(roomPosition * new Vector3Int(GameUtils.ROOM_WIDTH, GameUtils.ROOM_HEIGHT));
    }

    void ResetCurrentRoom()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameUtils.BOX_TAG))
        {
            GridMover boxMover = gameObject.GetComponent<GridMover>();
            if (GameUtils.TileRoomPosition(boxMover.gridPosition) == roomPosition) boxMover.ResetPosition();
        }
        playerMover.ResetPosition();
    }
}
