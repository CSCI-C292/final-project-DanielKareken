using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    [SerializeField] GameObject ShelfParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ShelfParent.GetComponent<MoveableShelf>().HandleMouseDown();
        print("clicked");
    }
}
