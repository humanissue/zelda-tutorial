using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private cameraMovement cam;
    public bool namedPlace;
    public string placeName;
    public GameObject text;
    public Text placeText;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if(namedPlace)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
