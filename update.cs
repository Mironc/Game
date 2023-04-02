using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update : MonoBehaviour
{
    private List<IUpdate> Updates = new List<IUpdate>(100);
    private List<ILateupdate> LateUpdates = new List<ILateupdate>(100);
    private List<IFixedUpdate> FixedUpdates = new List<IFixedUpdate>(100);
    private void Awake() 
    {
        GetComponents<IUpdate>(this.Updates);
        GetComponents<ILateupdate>(this.LateUpdates);
        GetComponents<IFixedUpdate>(this.FixedUpdates);
    }
    private void Update()
    {
        for (int i = 0; i < this.Updates.Count; i++)
        {
            this.Updates[i].Tick();
        }
    }
    private void LateUpdate()
    {
        
        for (int i = 0; i < this.LateUpdates.Count; i++)
        {
            this.LateUpdates[i].LateTick();
        }
    }
    private void FixedUpdate()
    {
        
        for (int i = 0; i < this.Updates.Count; i++)
        {
            this.FixedUpdates[i].FixedTick();
        }
    }
}
