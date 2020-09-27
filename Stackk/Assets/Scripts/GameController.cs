using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public GameController Instance { get; private set; }
    #endregion
    
    [SerializeField] GameObject platformPrefab;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        MovePlatform.platformStops += CreateNewPlatform;
    }

    void CreateNewPlatform(Vector3 newScale, Vector3 newPosition)
    {
        score++;

        GameObject platform = Instantiate(platformPrefab);

        platform.transform.localScale = newScale;

        newPosition.y += newScale.y;
        
        MovePlatform mover = platform.GetComponent<MovePlatform>();
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
