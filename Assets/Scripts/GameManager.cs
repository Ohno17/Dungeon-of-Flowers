using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const string TILEMAP_TAG = "MainTilemap";
    public const string BOX_TAG = "Box";
    public const int ROOM_WIDTH = 18;
    public const int ROOM_HEIGHT = 10;
    [HideInInspector] public int flowers = 0;
    [HideInInspector] public Vector3Int roomPosition;

    [SerializeField] private GridMover playerMover;
    [SerializeField] private GridMover cameraMover;
    private Vector3Int lastRoomPosition;

    // Start is called before the first frame update
    void Start()
    {
        roomPosition = new(0, 0);
        cameraMover.SetPositionAtomic(roomPosition * new Vector3Int(ROOM_WIDTH, ROOM_HEIGHT));
    }

    // Update is called once per frame
    void Update()
    {
        lastRoomPosition = roomPosition;
        roomPosition = TileRoomPosition(playerMover.gridPosition);
        if (roomPosition != lastRoomPosition)
        {
            // Reset boxes in just-entered room
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameManager.BOX_TAG))
            {
                GridMover boxMover = gameObject.GetComponent<GridMover>();
                if (TileRoomPosition(boxMover.gridPosition) == roomPosition) boxMover.ResetPosition();
            }
            playerMover.initalPosition = playerMover.gridPosition;
        }

        if (Input.GetKeyDown(KeyCode.R)) ResetCurrentRoom();

        cameraMover.SetPosition(roomPosition * new Vector3Int(ROOM_WIDTH, ROOM_HEIGHT));
    }

    void ResetCurrentRoom()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameManager.BOX_TAG))
        {
            GridMover boxMover = gameObject.GetComponent<GridMover>();
            if (TileRoomPosition(boxMover.gridPosition) == roomPosition) boxMover.ResetPosition();
        }
        playerMover.ResetPosition();
    }

    // Convert tile position to a room position
    public static Vector3Int TileRoomPosition(Vector3Int tilePosition)
    {
        int roomX = Mathf.FloorToInt((float)(tilePosition.x + (ROOM_WIDTH / 2)) / ROOM_WIDTH);
        int roomY = Mathf.FloorToInt((float)(tilePosition.y + (ROOM_HEIGHT / 2)) / ROOM_HEIGHT);
        return new(roomX, roomY);
    }
}
