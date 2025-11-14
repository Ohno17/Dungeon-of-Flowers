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

    // Convert room position to tile position of center-top-right tile
    public static Vector3Int RoomTilePosition(Vector3Int roomPosition)
    {
        int tileX = (roomPosition.x * ROOM_WIDTH) + (ROOM_WIDTH  / 2);
        int tileY = (roomPosition.y * ROOM_HEIGHT) + (ROOM_HEIGHT / 2);
        return new Vector3Int(tileX, tileY);
    }
}