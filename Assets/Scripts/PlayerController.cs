using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float holdDelay = 0.5f;
    public float repeatRate = 0.13f;

    [SerializeField] private GridMover mover;
    [SerializeField] private Tilemap tilemap;
    private float nextMoveTime = 0f;
    private bool isHolding = false;
    private KeyCode currentKey;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) StartHold(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.D)) StartHold(KeyCode.D);
        if (Input.GetKeyDown(KeyCode.W)) StartHold(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.S)) StartHold(KeyCode.S);

        if (Input.GetKeyUp(KeyCode.A)) StopHold(KeyCode.A);
        if (Input.GetKeyUp(KeyCode.D)) StopHold(KeyCode.D);
        if (Input.GetKeyUp(KeyCode.W)) StopHold(KeyCode.W);
        if (Input.GetKeyUp(KeyCode.S)) StopHold(KeyCode.S);

        if (isHolding && Time.time >= nextMoveTime)
        {
            PerformMove(currentKey);
            nextMoveTime = Time.time + repeatRate;
        }
    }

    void StartHold(KeyCode key)
    {
        PerformMove(key);
        isHolding = true;
        currentKey = key;
        nextMoveTime = Time.time + holdDelay;
    }

    void StopHold(KeyCode key)
    {
        if (currentKey == key)
            isHolding = false;
    }

    void PerformMove(KeyCode key)
    {
        if (key == KeyCode.A) TryMove(Vector3Int.left);
        if (key == KeyCode.D) TryMove(Vector3Int.right);
        if (key == KeyCode.W) TryMove(Vector3Int.up);
        if (key == KeyCode.S) TryMove(Vector3Int.down);
    }

    void TryMove(Vector3Int direction)
    {
        if (tilemap.GetColliderType(mover.gridPosition + direction) != Tile.ColliderType.None) return;
        mover.Move(direction);
    }
}
