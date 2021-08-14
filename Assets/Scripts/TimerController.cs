using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TimerController : MonoBehaviour
{
    static private Dictionary<string,TimerAction> timers = new Dictionary<string, TimerAction>();

    private void Update()
    {
        for(int i = 0; i <timers.Count;i++)
        {
            KeyValuePair<string,TimerAction> item = timers.ElementAt(i);
            item.Value.Tick();
        }
    }

    public static void AddTimer(TimerAction timer,string name)
    {
        timers.Add(name,timer);
    }
    public static TimerAction Get(string name)
    {
        return timers[name];
    }
    public static void RemoveTimer(string name)
    {
        timers.Remove(name);
    }    

}
