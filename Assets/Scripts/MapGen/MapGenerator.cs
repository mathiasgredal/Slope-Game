using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    public Transform player;//transform for the player
    public Transform parent;// the parent which the mapPieces go in

    public List<MapPieceData> mapPieceSchematic = new List<MapPieceData>();// list for the standard mapPiece properties
    public List<GameObject> gameObjectSchematic = new List<GameObject>();//list of the default mapPieces that will be spawned

    public List<MapPieceData> mapPieceLst = new List<MapPieceData>();// list for all the mapPieces in the scene

    Vector3 lastMapPiecePos;// the position of the last mapPiece



    public int renderDst;// the render distance how many mapPiece we will spawn ahead of ourselves
    public float lengthBetweenMapPieces = 1.75f;// the length between the mapPieces
    public int mapPieceNum;// the number of mapPieces that have been spawned
    [HideInInspector]// hides the varieble in the unity inspector
    public int playerPositionInMapPieces;// the mapPieces number we are on now a.k.a the score
    public Text playerScore;// the score stored as a text varieble


    void Start()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap += RestartMap;
        lastMapPiecePos = new Vector3(5, -1, 0);// defining the last position of the mapPiece that never existed is
        AddFirstMapPiece();// spawning the first mapPiece as it needs special spawning properties
    }

    public void AddFirstMapPiece()
    {
        int whichMapPiece = Random.Range(0, mapPieceSchematic.Count);//Randomly picking the mapPiece to spawn
        int whichMapPieceNum = mapPieceLst.Count;// setting how many variebles have been spawned
        Vector3 pos;// empty vector
        GameObject mapPieceObject;// empty Gameobject
        switch (whichMapPiece)//hard to explain
        {
            case 1:// straight map piece
                StandardMapPieceSpawnStart(whichMapPiece, whichMapPieceNum);// if whichmapPiece is 1 spawn this
                break;

            case 2://tunnel map piece
                StandardMapPieceSpawnStart(whichMapPiece, whichMapPieceNum);// if whichmapPiece is 2 spawn this
                break;
            case 3://straight with Object
                StandardMapPieceSpawnStart(whichMapPiece, whichMapPieceNum);// if whichmapPiece is 3 spawn this
                break;
            case 4://Side to side
                StandardMapPieceSpawnStart(whichMapPiece, whichMapPieceNum);// if whichmapPiece is 4 spawn this
                break;
            case 5://Up and Down
                StandardMapPieceSpawnStart(whichMapPiece, whichMapPieceNum);// if whichmapPiece is 5 spawn this
                break;
        }
    }

    void StandardMapPieceSpawnStart(int whichMapPiece, int whichMapPieceNum)
    {
        Vector3 pos;
        GameObject mapPieceObject;
        pos = new Vector3(mapPieceSchematic[whichMapPiece].lenghtToBack + lastMapPiecePos.x, lastMapPiecePos.y - 1.7f, Random.Range(-mapPieceSchematic[whichMapPiece].sideMovement, mapPieceSchematic[whichMapPiece].sideMovement));
        mapPieceObject = Instantiate(gameObjectSchematic[whichMapPiece], pos, gameObjectSchematic[whichMapPiece].transform.rotation, parent) as GameObject;
        mapPieceObject.transform.name = "Map Piece nr." + whichMapPieceNum;
        lastMapPiecePos = new Vector3(pos.x + mapPieceSchematic[whichMapPiece].lengthToFront, pos.y, pos.z);
        mapPieceLst.Insert(whichMapPieceNum, mapPieceSchematic[whichMapPiece]);
        mapPieceLst[whichMapPieceNum].pos = pos;
    }


    void Update()
    {
        mapPieceNum = mapPieceLst.Count;// setting the number of mapPieces to the length of the list containing our mapPieces
        CalculatePlayerPosition();// calculating the player position see method "CalculatePlayerPosition"

        playerScore.text = (playerPositionInMapPieces == 0) ? "1" : playerPositionInMapPieces.ToString();// setting the playerscore

        if (mapPieceNum - renderDst < playerPositionInMapPieces)// checking if we should spawn more mapPieces
        {
            AddMapPiece();// adding a mapPiece if the line above is true
        }
        if (Input.GetButtonDown("Restart"))// checking if "R" is pressed
        {
            RestartMap();// calling restart map if line above is true
        }
    }


    public void AddMapPiece()
    {
        int whichMapPiece = Random.Range(1, mapPieceSchematic.Count);
        bool powerup = (Random.Range(0.00f, 1.00f) > FindObjectOfType<PowerUp_Manager>().powerupSpawnFrequency) ? false : true;
        int whichMapPieceNum = mapPieceLst.Count;
        Vector3 pos;
        GameObject mapPieceObject;
        switch (whichMapPiece)
        {
            case 1: //straight map piece
                StandardMapPieceSpawn(whichMapPiece, whichMapPieceNum, powerup);
                break;

            case 2:// tunnel map piece
                StandardMapPieceSpawn(whichMapPiece, whichMapPieceNum, powerup);
                break;
            case 3://straight with Object
                StandardMapPieceSpawn(whichMapPiece, whichMapPieceNum, powerup);
                break;
            case 4://Side to Side
                StandardMapPieceSpawn(whichMapPiece, whichMapPieceNum, powerup);
                break;
            case 5://Up and Down
                StandardMapPieceSpawn(whichMapPiece, whichMapPieceNum, powerup);// if whichmapPiece is 5 spawn this
                break;

        }
    }



    void StandardMapPieceSpawn(int whichMapPiece, int whichMapPieceNum, bool powerup)
    {
        Vector3 pos;
        GameObject mapPieceObject;
        pos = new Vector3(mapPieceSchematic[whichMapPiece].lenghtToBack + lastMapPiecePos.x + lengthBetweenMapPieces, lastMapPiecePos.y - 1.7f, Random.Range(-mapPieceSchematic[whichMapPiece].sideMovement, mapPieceSchematic[whichMapPiece].sideMovement));
        mapPieceObject = Instantiate(gameObjectSchematic[whichMapPiece], pos, gameObjectSchematic[whichMapPiece].transform.rotation, parent) as GameObject;
        mapPieceObject.transform.name = "Map Piece nr." + whichMapPieceNum;
        lastMapPiecePos = new Vector3(pos.x + mapPieceSchematic[whichMapPiece].lengthToFront, pos.y, pos.z);
        mapPieceLst.Insert(whichMapPieceNum, mapPieceSchematic[whichMapPiece]);
        mapPieceLst[whichMapPieceNum].pos = pos;

        if (powerup)
            AddPowerupToMapPiece(mapPieceSchematic[whichMapPiece], mapPieceObject);

        RemoveMapPiece();
    }

    void AddPowerupToMapPiece(MapPieceData mapPieceData, GameObject mapPieceObject)
    {
        int whichPowerUp = PowerupPicker();
        GameObject powerup = Instantiate(FindObjectOfType<PowerUp_Manager>().powerUps[whichPowerUp].powerUpObject, Vector3.zero, FindObjectOfType<PowerUp_Manager>().powerUps[whichPowerUp].powerUpObject.transform.rotation, mapPieceObject.transform) as GameObject;
        powerup.transform.localPosition = mapPieceData.powerUpPos;
    }

    int PowerupPicker()
    {
        PowerUp_Manager manager = FindObjectOfType<PowerUp_Manager>();

        float totalSpawnrate = 0;

        for (int i = 0; i < manager.powerUps.Length; i++)
        {
            totalSpawnrate += manager.powerUps[i].spawnRate;
        }

        float randomSpawn = Random.Range(0f, totalSpawnrate);

        float[] spawnRates = new float[manager.powerUps.Length];
        for (int i = 0; i < spawnRates.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                spawnRates[i] += manager.powerUps[j].spawnRate;
            }
        }


        for (int i = 0; i < spawnRates.Length; i++)
        {
            if (spawnRates[i] > randomSpawn)
                return i;
        }

        return 5;

    }

    void RemoveMapPiece()
    {
        for (int i = playerPositionInMapPieces - 4; i >= 0; i--)
        {
            Destroy(GameObject.Find("Map Piece nr." + i));
        }
    }

    public void RestartMap()
    {
        player.transform.position = new Vector3(0f, 4.3f, 0);

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        mapPieceLst.Clear();
        mapPieceNum = 0;
        playerPositionInMapPieces = 0;
        lastMapPiecePos = new Vector3(5, -1, 0);
        AddFirstMapPiece();
    }

    void CalculatePlayerPosition()
    {
        RaycastHit hitInfo;

        Ray ray = new Ray(player.position, Vector3.down);

        if (Physics.Raycast(ray, out hitInfo, 100))//cast a ray and we hit
        {
            if (hitInfo.collider.transform.parent.parent == parent)
            {
                string mapPieceNumString = hitInfo.transform.parent.name.Substring(13);
                int oldPlayerPosInMapPieces = playerPositionInMapPieces;
                playerPositionInMapPieces = int.Parse(mapPieceNumString) + (1 * ScoreMultiplier_Effect.ScoreMultiplication);

                if (oldPlayerPosInMapPieces != playerPositionInMapPieces)
                    FindObjectOfType<Player_Mover>().IncreaseSpeed();
            }
        }
        else//if we didnt hit anything
        {
            if (player.position.y < lastMapPiecePos.y)
            {
                if (!Killscreen_Manager.KillscreenOn)
                {
                    Player_Killer.fallenOutOfMap = true;
                }
                //print("Dead");
            }
        }
    }

    void OnDisable()
    {
        FindObjectOfType<Player_Killer>().OnRetryMap -= RestartMap;
    }
}
