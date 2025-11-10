using UnityEngine;

public class GridMoverScript : MonoBehaviour
{

    public float lerpSpeed = 15f;
    [HideInInspector] public Vector3Int gridPosition;

    [SerializeField] private Grid grid;
    private Vector3 targetWorldPosition;

    void Start()
    {
        gridPosition = grid.WorldToCell(transform.position);
        targetWorldPosition = grid.GetCellCenterWorld(gridPosition);
    }

    public void Move(Vector3Int direction)
    {
        gridPosition += direction;
        targetWorldPosition = grid.GetCellCenterWorld(gridPosition);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetWorldPosition, lerpSpeed * Time.deltaTime);
    }
}
