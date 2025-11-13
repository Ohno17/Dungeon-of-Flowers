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
        
    }

    // Update is called once per frame
    void Update()
    {
        TryActivateTile(playerMover.gridPosition);
    }

    public void NewRoom()
    {
        redActivated = false;
        ResetState();
    }

    void ResetState()
    {
        // TODO: Reset removed door tiles
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
