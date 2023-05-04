using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject iconPrefab;
    public RawImage compassImage;
    public Transform player;
    List<FruitMarker> fruitMarkers = new List<FruitMarker>();
    List<FruitMarker> deleteFruits = new List<FruitMarker>();
    List<GameObject> icons = new List<GameObject>();
    FruitMarker[] aux;
    float compassUnit;
    public float maxDistance = 200f;

    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
        aux = FindObjectsOfType<FruitMarker>();
        foreach (FruitMarker item in aux)
        {
            AddFruitMarker(item);
        }
        Debug.Log("FruitMarker:" + fruitMarkers.Count);
    }

    private void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);
        if (fruitMarkers.Count > 0)
        {
            foreach (FruitMarker marker in fruitMarkers)
            {
                if (marker == null)
                {
                    RemoveFruitMarker(marker);
                }
                else
                {
                    marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
                    float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
                    float scale = 0f;
                    if (dst < maxDistance)
                    {
                        scale = 1f - (dst / maxDistance);
                    }
                    //marker.image.rectTransform.localScale = Vector3.one * scale;
                }
            }
            foreach (FruitMarker marker in deleteFruits)
            {
                fruitMarkers.Remove(marker);
            }
        }
    }

    public void AddFruitMarker(FruitMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;
        icons.Add(newMarker);
        fruitMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(FruitMarker marker)
    {
        if (marker != null)
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
            Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

            float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
            return new Vector2(compassUnit * angle, 0f);
        }
        else
        {
            return Vector2.zero;
        }
    }

    public void RemoveFruitMarker(FruitMarker marker)
    {
        foreach (GameObject item in icons)
        {
            if (item != null)
            {
                if (item.GetComponent<Image>() == marker.image)
                {
                    Destroy(item);
                }
            }
        }

        deleteFruits.Add(marker);
    }
}
