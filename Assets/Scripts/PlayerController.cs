using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GridMover mover;
    [SerializeField] private Tilemap tilemap;

    void Start()
    {

    }

    void TryMove(Vector3Int direction)
    {
        if (tilemap.GetColliderType(mover.gridPosition + direction) != Tile.ColliderType.None) return;
        mover.Move(direction);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            TryMove(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D))
            TryMove(Vector3Int.right);
        if (Input.GetKeyDown(KeyCode.W))
            TryMove(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S))
            TryMove(Vector3Int.down);
    }
}
