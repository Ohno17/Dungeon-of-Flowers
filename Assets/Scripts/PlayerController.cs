using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GridMover gridMover;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            gridMover.Move(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D))
            gridMover.Move(Vector3Int.right);
        if (Input.GetKeyDown(KeyCode.W))
            gridMover.Move(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S))
            gridMover.Move(Vector3Int.down);
    }
}
