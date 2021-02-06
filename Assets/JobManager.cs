using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public static int job;
    
    public void Select_Shooter()
    {
        job = 1;
    }
    public void Select_Deliverer()
    {
        job = 2;
    }
    public void Select_Raderer()
    {
        job = 3;
    }
    public void Select_Healer()
    {
        job = 4;
    }
    public void Select_Bomber()
    {
        job = 5;
    }
}
