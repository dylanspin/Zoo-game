using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour
{   
    [Header("Scripts")]
    [SerializeField] private CollectController collecScript;

    [Header("Track data")]
    [SerializeField] private Vector3 spawnOffset = new Vector3(0,0,10);
    [SerializeField] private int lengthInfront = 10;
    [SerializeField] private GameObject startTrack;
    [SerializeField] private List<TrackPart> partTracks;

    private void Start()
    {
        spawnNewPart(transform.position,startTrack,false);
        for(int i=0; i<lengthInfront-2; i++)
        {
            partTracks[i].createNewPart();
        }
    }

    public void spawnNewPart(Vector3 lastPos,GameObject newPart,bool offset)
    {
        Vector3 spawnPos = spawnOffset;
        if(offset)
        {
            spawnPos += lastPos;
        }

        TrackPart partScript = Instantiate(newPart, spawnPos, Quaternion.Euler(0,0,0),transform).GetComponent<TrackPart>(); 
        partScript.setStart(this,collecScript);
        partTracks.Add(partScript);
        if(partTracks.Count-4 > lengthInfront)
        {
            Destroy(partTracks[0].gameObject);
            partTracks.RemoveAt(0);
            Debug.Log("Destroyed behind");
        }
    }

    public void createEnd()
    {
        partTracks[partTracks.Count-1].createNewPart();
        Debug.Log("added at end");
    }
}