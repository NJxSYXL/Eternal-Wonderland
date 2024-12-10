using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private static NPCController _instance;
    public static NPCController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("NPC Controller is null");
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private GameObject FindNPC(string name)
    {
        GameObject npc = GameObject.Find(name).gameObject;
        if (npc == null)
        {
            Debug.LogErrorFormat("NPC {0} is not valid", name);
            return null;
        }

        return npc;
    }

    public void MoveNPC(string name, Vector2 newLocation, bool flipSprite)
    {
        GameObject npc = FindNPC(name);
        if (npc == null) return;

        npc.transform.position = newLocation;
        npc.GetComponent<SpriteRenderer>().flipX = flipSprite;
    }

    public void ToggleNPC(string name, bool active)
    {
        GameObject npc = FindNPC(name);

        float newAlpha = active ? 1f : 0f;

        Color color = npc.GetComponent<SpriteRenderer>().color;
        npc.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, newAlpha);
    }

    #region UnityEvents compatible functions
    public void HideNPC(string name)
    {
        ToggleNPC(name, false);
    }

    public void ShowNPC(string name)
    {
        ToggleNPC(name, true);
    }
    #endregion
}