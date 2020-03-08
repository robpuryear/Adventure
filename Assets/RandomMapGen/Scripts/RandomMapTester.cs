using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// can remove 1 tile islands by identifying tiles that has autotileid == 0
// or remove anything that doesn't have a 15 tile in it

public class RandomMapTester : MonoBehaviour
{
    [Header("Map Dimensions")]

    public int mapWidth = 20;
    public int mapHeight = 20;

    [Space]
    [Header("Visualize Map")]

    public GameObject mapContainer;
    public GameObject tilePrefab;
    public Vector2 tileSize = new Vector2(16, 16);

    [Space]
    [Header("Map Sprites")]

    public Texture2D islandTexture;
    public Texture2D fowTexture;

    [Space]
    [Header("Player")]
    public GameObject playerPrefab;
    public GameObject player;
    public int distance = 3;    // needs to be an odd number

    [Space]

    [Header("Decorate Map")]
    [Range(0, .9f)]
    public float erodePercent = .5f;
    [Range(0, .9f)]
    public float treePercent = .3f;
    [Range(0, .9f)]
    public float hillPercent = .2f;
    [Range(0, .9f)]
    public float mountainPercent = .1f;
    [Range(0, .9f)]
    public float townPercent = .05f;
    [Range(0, .9f)]
    public float monsterPercent = .1f;
    [Range(0, .9f)]
    public float lakePercent = .05f;

    public int erodeIterations = 2;

    public Map map;

    private int tmpX;
    private int tmpY;
    private Sprite[] islandTilesSprites;
    private Sprite[] fowTilesSprites;


    // Start is called before the first frame update
    void Start()
    {
        islandTilesSprites = Resources.LoadAll<Sprite>(islandTexture.name);
        fowTilesSprites = Resources.LoadAll<Sprite>(fowTexture.name);

        Reset();
    }

    public void Reset()
    {
        map = new Map();
        MakeMap();
        // delay adding the player until the map is created
        StartCoroutine(AddPlayer());
    }

    IEnumerator AddPlayer()
    {
        yield return new WaitForEndOfFrame();
        CreatePlayer();
    }

    public void MakeMap()
    {
        map.NewMap(mapWidth, mapHeight);

        map.CreateIsland(
            erodePercent,
            erodeIterations,
            treePercent,
            hillPercent,
            mountainPercent,
            townPercent,
            monsterPercent,
            lakePercent
            );

        CreateGrid();
        // focus on castle tile
        CenterMap(map.castleTile.id);
    }

    void CreateGrid()
    {
        ClearMapContainer();
        // read the sprites out from the island texture

        var total = map.tiles.Length;
        var maxColumns = map.columns;
        var column = 0;
        var row = 0;

        for(var i = 0; i < total; i++)
        {
            column = i % maxColumns;

            var newX = column * tileSize.x;
            var newY = -row * tileSize.y;

            var go = Instantiate(tilePrefab);
            go.name = "Tile " + i;
            go.transform.SetParent(mapContainer.transform);
            go.transform.position = new Vector3(newX, newY, 0);

            DecorateTile(i);

            if(column == (maxColumns - 1))
            {
                row++;
            }
        }
    }

    private void DecorateTile(int tileId)
    {
        var tile = map.tiles[tileId];

        var spriteID = tile.autotileID;

        var go = mapContainer.transform.GetChild(tileId).gameObject;

        if (spriteID >= 0)
        {
            var sr = go.GetComponent<SpriteRenderer>();
            if (tile.visited)
            {
                sr.sprite = islandTilesSprites[spriteID];
            }
            else
            {
                tile.CalculateFOWAutotileID();
                sr.sprite = fowTilesSprites[Mathf.Min(tile.fowAutotileID, fowTilesSprites.Length - 1)];

            }
        }
    }

    public void CreatePlayer()
    {
        // Instantiate player
        player = Instantiate(playerPrefab);
        // Name player
        player.name = "Player";
        // Set player parent
        player.transform.SetParent(mapContainer.transform);

        var controller = player.GetComponent<MapMovementController>();
        controller.map = map;
        controller.tileSize = tileSize;
        controller.tileActionCallback += TileActionCallback;

        var moveScript = Camera.main.GetComponent<MoveCamera>();
        moveScript.target = player;

        controller.MoveTo(map.castleTile.id);

        //// get position of the castle tile
        //PosUtil.CalculatePos(map.castleTile.id, map.columns, out tmpX, out tmpY);

        //tmpX *= (int)tileSize.x;
        //tmpY *= -(int)tileSize.y;

        //// set player position on the map on top of the castle tile
        //player.transform.position = new Vector3(tmpX,tmpY, 0);
    }

    void TileActionCallback(int type)
    {
        // can tell the type of tile the player lands on
        //Debug.Log("On tile type: " + type);

        var tileID = player.GetComponent<MapMovementController>().currentTile;
        VisitTile(tileID);
    }

    void ClearMapContainer()
    {
        var children = mapContainer.transform.GetComponentsInChildren<Transform>();
        for(var i = children.Length-1;i > 0; i--)
        {
            Destroy(children[i].gameObject);
        }
    }

    void CenterMap(int index)
    {
        var camPos = Camera.main.transform.position;
        var width = map.columns;

        PosUtil.CalculatePos(index, width, out tmpX, out tmpY);

        camPos.x = tmpX * tileSize.x;
        camPos.y = -tmpY * tileSize.y;
        Camera.main.transform.position = camPos;
    }

    void VisitTile(int index)
    {
        int column, newX, newY, row = 0;

        PosUtil.CalculatePos(index, map.columns, out tmpX, out tmpY);

        var half = Mathf.FloorToInt(distance / 2f);

        tmpX -= half;
        tmpY -= half;

        var total = distance * distance;
        var maxColumns = distance - 1;

        for(int i =0; i < total; i++)
        {
            column = i % distance;
            newX = column + tmpX;
            newY = row + tmpY;

            PosUtil.CalculateIndex(newX, newY, map.columns, out index);

            if(index > -1 && index < map.tiles.Length)
            {
                var tile = map.tiles[index];
                tile.visited = true;

                DecorateTile(index);

                foreach (var neighbor in tile.neighbors)
                {
                    if (neighbor != null)
                    {
                        if (!neighbor.visited)
                        {
                            neighbor.CalculateFOWAutotileID();
                            DecorateTile(neighbor.id);
                        }
                    }

                }
            }

            if (column == maxColumns)
            {
                row++;
            }
        }

    }

}
