using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GridMover playerMover;
    [SerializeField] private Tile redDoorType;
    [SerializeField] private Tile redButtonType;

    private bool redActivated = false;
    private Vector3Int redDoorCurrentPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerController.AfterMoveEvent += AfterMove;
        GameManager.ChangeRoomEvent += ChangeRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AfterMove(object sender, Vector3Int newPosition)
    {
        TryActivateTile(newPosition);
    }

    void ChangeRoom(object sender, Vector3Int newRoomPosition)
    {
        redActivated = false;
        Debug.Log("TODO reset doors");
    }

    void ActivateRed()
    {
        if (redActivated) return;
        Debug.Log("Button Pressed");
        redActivated = true;
    }

    public void TryActivateTile(Vector3Int tilePosition)
    {
        Tile tile = (Tile)tilemap.GetTile(tilePosition);

        if (tile == redButtonType)
        {
            ActivateRed();
        }
    }
}
