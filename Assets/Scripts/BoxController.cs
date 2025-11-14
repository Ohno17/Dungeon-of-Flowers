using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    public GridMover mover;

    private Tilemap tilemap;

    void Start()
    {
        GameManager.PuzzleResetEvent += PuzzleReset;
        GameManager.ChangeRoomEvent += ChangeRoom;
        tilemap = GameObject.FindGameObjectWithTag(GameUtils.TILEMAP_TAG).GetComponent<Tilemap>();
    }

    void Update()
    {

    }

    void ChangeRoom(object sender, Vector3Int newRoomPosition)
    {
        PuzzleReset(sender);
    }

    void PuzzleReset(object sender)
    {
        mover.ResetPosition();
    }
    
    public bool TryMove(Vector3Int direction)
    {
        Vector3Int newPosition = mover.gridPosition + direction;

        // If a wall is in the way
        if (tilemap.GetColliderType(newPosition) != Tile.ColliderType.None) return false;

        // If another box is in the way
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(GameUtils.BOX_TAG))
        {
            BoxController box = gameObject.GetComponent<BoxController>();
            if (box.mover.gridPosition == newPosition) return false;
        }

        // If box will leave room as a result of this
        if (GameUtils.TileRoomPosition(mover.gridPosition) != GameUtils.TileRoomPosition(newPosition)) return false;

        mover.Move(direction);
        return true;
    }
}
