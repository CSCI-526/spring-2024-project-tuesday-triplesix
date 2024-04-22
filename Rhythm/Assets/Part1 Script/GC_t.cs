using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_t : MonoBehaviour
{
    public GameObject beatBar;
    public BallController ballControl;
    public Platform Platform;
    public TurretControl_t TurretControl_t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBeat()
    {
        TurretControl_t.startFight();
        Platform.ShowBeatsBar();
        ballControl.DisableMovement();
    }


}
