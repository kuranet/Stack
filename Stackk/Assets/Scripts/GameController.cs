using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public MovePlatform lastPlatform;
    static public MovePlatform currentPlatform;

    [SerializeField] GameObject platformPrefab;
    [SerializeField] MovePlatform starterPlatform;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastPlatform = starterPlatform;
        CreateNewPlatform(platformPrefab.transform.position);
    }

    void CreateNewPlatform(Vector3 newPosition)
    {
        score++;

        GameObject platform = Instantiate(platformPrefab);
        
        newPosition.y += platform.transform.localScale.y;

        MovePlatform mover = platform.GetComponent<MovePlatform>();

        mover.platformStops += ChangeLocalScale;
        mover.platformStops += CreateNewPlatform;

        int randomStart = Random.Range(0, 4);
        switch (randomStart)
        {
            case 0:
                mover.end = SpawnPositiontData.leftFather;
                mover.start = SpawnPositiontData.rightCloser;
                break;
            case 1:
                mover.end = SpawnPositiontData.rightFather;
                mover.start = SpawnPositiontData.leftCloser;
                break;
            case 2:
                mover.end = SpawnPositiontData.leftCloser;
                mover.start = SpawnPositiontData.rightFather;
                break;
            case 3:
                mover.end = SpawnPositiontData.rightCloser;
                mover.start = SpawnPositiontData.leftFather;
                break;
        }
        mover.end.y = newPosition.y;
        mover.start.y = newPosition.y;

        platform.transform.position = mover.start;

        if (currentPlatform != null)
            lastPlatform = currentPlatform;
        currentPlatform = mover;

        platform.transform.localScale = new Vector3(lastPlatform.transform.localScale.x, platformPrefab.transform.localScale.y, lastPlatform.transform.localScale.z);
    }

    void ChangeLocalScale(Vector3 currentPosition)
    {
        SplitCubeZ();
        SplitCubeX();
    }

    void SplitCubeZ()
    {
        float hangoverZ = currentPlatform.transform.position.z - lastPlatform.transform.position.z;
        float newZSize = lastPlatform.transform.localScale.z - Mathf.Abs(hangoverZ);
        float newZPosition = lastPlatform.transform.position.z + (hangoverZ) / 2;

        currentPlatform.transform.localScale = new Vector3(currentPlatform.transform.localScale.x, currentPlatform.transform.localScale.y, newZSize);
        currentPlatform.transform.position = new Vector3(currentPlatform.transform.position.x, currentPlatform.transform.position.y, newZPosition);

        if (hangoverZ != 0)
            Debug.Log("CHANGED Z");

        SpawnPositiontData.leftCloser.z = newZPosition;
        SpawnPositiontData.rightFather.z = newZPosition;

    }
    void SplitCubeX()
    {
        float hangoverX = currentPlatform.transform.position.x - lastPlatform.transform.position.x;
        float newXSize = lastPlatform.transform.localScale.x - Mathf.Abs(hangoverX);
        float newXPosition = lastPlatform.transform.position.x + (hangoverX) / 2;

        currentPlatform.transform.localScale = new Vector3(newXSize, currentPlatform.transform.localScale.y, currentPlatform.transform.localScale.z);
        currentPlatform.transform.position = new Vector3(newXPosition, currentPlatform.transform.position.y, currentPlatform.transform.position.z);

        if (hangoverX != 0)
            Debug.Log("CHANGED X");
        SpawnPositiontData.leftFather.x = newXPosition;
        SpawnPositiontData.rightCloser.x = newXPosition;

    }
}
