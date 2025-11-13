using UnityEngine;

static class GameUtils
{
    public const string TILEMAP_TAG = "MainTilemap";
    public const string BOX_TAG = "Box";
    public const int ROOM_WIDTH = 18;
    public const int ROOM_HEIGHT = 10;

    // Convert tile position to a room position
    public static Vector3Int TileRoomPosition(Vector3Int tilePosition)
    {
        int roomX = Mathf.FloorToInt((float)(tilePosition.x + (ROOM_WIDTH / 2)) / ROOM_WIDTH);
        int roomY = Mathf.FloorToInt((float)(tilePosition.y + (ROOM_HEIGHT / 2)) / ROOM_HEIGHT);
        return new(roomX, roomY);
    }
}