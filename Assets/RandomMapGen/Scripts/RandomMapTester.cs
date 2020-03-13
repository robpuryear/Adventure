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
    [Range(0, .9f)]
    public float randomBattleOdds = .3f;


    [Space]
    [Header("Actor Templates")]
    public Actor playerTemplate;
    public Actor monsterTemplate;

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
    private Actor playerActor;

    private BattleWindow battleWindow;
    private StatsWindow statsWindow;

    public WindowManager windowManager
    {
        get
        {
            return GenericWindow.manager;
        }
    }

    public void Reset()
    {
        islandTilesSprites = Resources.LoadAll<Sprite>(islandTexture.name);
        fowTilesSprites = Resources.LoadAll<Sprite>(fowTexture.name);
        map = new Map();
        MakeMap();
        // delay adding the player until the map is created
        StartCoroutine(AddPlayer());
    }

    public void Shutdown()
    {
        ClearMapContainer();
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

        playerActor = playerTemplate.Clone<Actor>();
        playerActor.ResetHealth();

        statsWindow = windowManager.Open((int)Windows.StatsWindow - 1, false) as StatsWindow;
        statsWindow.target = playerActor;
        statsWindow.UpdateStats();

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

        switch (type)
        {
            // town tile
            case 19:
                DisplayMessage("You have entered a town");
                break;
            // castle tile
            case 20:
                DisplayMessage("You have entered a castle");
                break;
            // whenever we walk on top of a dungeon, we trigger a battle
            case 21:
                StartBattle();
                break;
            default:
                var chance = Random.Range(0, 1f);
                if(chance < randomBattleOdds)
                {
                    StartBattle();
                }
                break;
        }

        // opens the messagewindow
        // always need to subtract 1 from the enum because the first one is none
        //var messageWindow = windowManager.Open((int)Windows.MessageWindow - 1, false) as MessageWindow;
        //messageWindow.text = "On tileType " + type;

    }

    private void DisplayMessage(string text)
    {
        var messageWindow = windowManager.Open((int)Windows.MessageWindow - 1, false) as MessageWindow;
        messageWindow.text = text;
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

        for (int i = 0; i < total; i++)
        {

            column = i % distance;

            newX = column + tmpX;
            newY = row + tmpY;

            PosUtil.CalculateIndex(newX, newY, map.columns, out index);

            if (index > -1 && index < map.tiles.Length)
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

    public void StartBattle()
    {
        var monsterActor = monsterTemplate.Clone<Actor>();
        monsterActor.ResetHealth();

        battleWindow = windowManager.Open((int)Windows.BattleWindow - 1, false) as BattleWindow;
        battleWindow.battleOverCallback += BattleOver;
        battleWindow.StartBattle(playerActor, monsterActor);
        TogglePlayerMovement(false);
    }

    public void EndBattle()
    {
        battleWindow.Close();
        TogglePlayerMovement(true);
    }

    private void TogglePlayerMovement(bool value)
    {
        player.GetComponent<MapMovementController>().enabled = value;
        Camera.main.GetComponent<MoveCamera>().enabled = value;
    }

    private void BattleOver(bool playerWin)
    {
        EndBattle();

        if (!playerWin)
        {
            Destroy(player);
            playerActor = null;
            StartCoroutine(ExitGame());

            //var messageWindow = windowManager.Open((int)Windows.MessageWindow - 1, false) as MessageWindow;
            //messageWindow.text = "The game is over";
        }
        else
        {
            var tileID = player.GetComponent<MapMovementController>().currentTile;
            var tile = map.tiles[tileID];

            // if you won a battle in a dungeon
            if(tile.autotileID == 21)
            {   // change the tile from a dungeon to a skull
                tile.autotileID = 22;
                // re-draw the tile on the map
                DecorateTile(tileID);
            }
        }
    }

    IEnumerator ExitGame()
    {
        DisplayMessage("The game is over");

        yield return new WaitForSeconds(2);

        windowManager.Open((int)Windows.GameOverWindow - 1);
    }
}
