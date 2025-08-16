using System;
using System.Collections;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public enum FarmState { NONE, SEED, HARVEST };
    public FarmState farmState;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2 fieldSize = new Vector2(10,10);
    [SerializeField] private float tileSize = 2f;

    [SerializeField] private int currentPlant;
    [SerializeField] private GameObject[] plants;
    [SerializeField] private GameObject[] crops;
   
    private GameObject[,] plantArray;

    private Camera mainCamera;

    [SerializeField] private LayerMask fieldLayerMask;

    void Awake()
    {
        mainCamera = Camera.main;
        plantArray  = new GameObject[(int)fieldSize.x, (int)fieldSize.y];

        CreateField();
    }

    void Update()
    {
        if (farmState != FarmState.NONE)
        {
            switch (farmState)
            {
                case FarmState.SEED:
                    OnSeed();
                    break;
                case FarmState.HARVEST:
                    OnHarvest();
                    break;
            }
        }
    }


    private void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2;
        float offsetZ = (fieldSize.y - 1) * tileSize / 2;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetZ;

                GameObject tileObj = Instantiate(tilePrefab, transform.GetChild(0));

                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, posZ);

                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }
        }
    }

    private void OnSeed()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (plantArray[tileX, tileY] == null)
                {
                    GameObject plant = Instantiate(plants[currentPlant], transform.GetChild(1));

                    plant.transform.position = hit.transform.position;

                    plantArray[tileX, tileY] = plant;
                }
            }
        }
    }
    private void OnHarvest()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayerMask))
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                int tileX = tile.arrayPos.x;
                int tileY = tile.arrayPos.y;

                if (plantArray[tileX, tileY] != null)
                {
                    Plant plant = plantArray[tileX, tileY].GetComponent<Plant>();

                    if (plant.isHarvest)
                    {
                        plantArray[tileX, tileY].SetActive(false);
                        plantArray[tileX, tileY] = null;

                        StartCoroutine(HarvestRout(plant.plantIndex, hit.transform.position));
                    }
                }


            }
        }
    }

    IEnumerator HarvestRout(int index, Vector3 pos)
    {
        int ranAmount = UnityEngine.Random.Range(1, 4);

        for (int i = 0; i < ranAmount; i++)
        {
            GameObject crop = Instantiate(crops[index]);
            crop.transform.position = pos + new Vector3 (0f, 0.4f, 0f);
            Rigidbody cropRb = crop.GetComponent<Rigidbody>();

            float ranX = UnityEngine.Random.Range(-2f, 2f);
            float ranZ = UnityEngine.Random.Range(-2f, 2f);

            var forceDir = new Vector3(ranX, 5f, ranZ);

            cropRb.AddForce(forceDir, ForceMode.Impulse);

            yield return new WaitForSeconds(0.15f);
        }
    }


    public void SetPlant(int index)
    {
        currentPlant = index;
    }

    public void SetFarmState(FarmState state)
    {
        if (farmState != state)
        {
            farmState = state;
        }
    }
}
