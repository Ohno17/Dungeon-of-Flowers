using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    [Header("Puzzle Element Tiles")]
    [SerializeField] private Tile openDoorType;
    [SerializeField] private Tile redDoorType;
    [SerializeField] private Tile redButtonType;
    [SerializeField] private Tile blueDoorType;
    [SerializeField] private Tile blueButtonType;
    [SerializeField] private Tile greenDoorType;
    [SerializeField] private Tile greenButtonType;

    private bool redActivated = false;
    private bool blueActivated = false;
    private bool greenActivated = false;
    private Vector3Int redCurrentPosition;
    private Vector3Int blueCurrentPosition;
    private Vector3Int greenCurrentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerController.AfterMoveEvent += AfterMove;
        GameManager.ChangeRoomEvent += ChangeRoom;
        GameManager.PuzzleResetEvent += PuzzleReset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        PlayerController.AfterMoveEvent -= AfterMove;
        GameManager.ChangeRoomEvent -= ChangeRoom;
        GameManager.PuzzleResetEvent -= PuzzleReset;
    }

    void AfterMove(object sender, Vector3Int newPosition)
    {
        TryActivateTile(newPosition);
    }

    void ChangeRoom(object sender, Vector3Int newRoomPosition)
    {
        PuzzleReset(sender);
    }

    void PuzzleReset(object sender)
    {
        if (redActivated)
        {
            redActivated = false;
            tilemap.SetTile(redCurrentPosition, redDoorType);
        }

        if (blueActivated)
        {
            blueActivated = false;
            tilemap.SetTile(blueCurrentPosition, blueDoorType);
        }

        if (greenActivated)
        {
            greenActivated = false;
            tilemap.SetTile(greenCurrentPosition, greenDoorType);
        }
    }

    void ActivateButton(Vector3Int tilePosition, Tile doorType, ref bool activatedFlag, ref Vector3Int doorPosition)
    {
        if (activatedFlag) return;

        Vector3Int roomOrigin = GameUtils.RoomTilePosition(GameUtils.TileRoomPosition(tilePosition));
        for (int x = 0; x < GameUtils.ROOM_WIDTH; x++)
        {
            for (int y = 0; y < GameUtils.ROOM_HEIGHT; y++)
            {
                Vector3Int pos = new(
                    roomOrigin.x + x - GameUtils.ROOM_WIDTH,
                    roomOrigin.y + y - GameUtils.ROOM_HEIGHT,
                    tilePosition.z
                );

                Tile tile = (Tile)tilemap.GetTile(pos);

                if (tile == doorType)
                {
                    tilemap.SetTile(pos, openDoorType);

                    activatedFlag = true;
                    doorPosition = pos;
                    return;
                }
            }
        }

        Debug.LogError("Button placed in room without door");
    }

    public void TryActivateTile(Vector3Int tilePosition)
    {
        Tile tile = (Tile)tilemap.GetTile(tilePosition);

        if (tile == redButtonType)
            ActivateButton(tilePosition, redDoorType, ref redActivated, ref redCurrentPosition);
        if (tile == blueButtonType)
            ActivateButton(tilePosition, blueDoorType, ref blueActivated, ref blueCurrentPosition);
        if (tile == greenButtonType)
            ActivateButton(tilePosition, greenDoorType, ref greenActivated, ref greenCurrentPosition);
    }
}
