using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInitiate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.MenuManager.InitiateDialogueMenu(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
