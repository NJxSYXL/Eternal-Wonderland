using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Fog : MonoBehaviour
{
    public ImageSet[] sets;
    public Image imageObject;

    [System.Serializable]
    public class ImageSet
    {
        public string imageName;
        public Sprite imageSprite;
    }

    public void ChangeImage(string name)
    {
        Sprite img = sets.FirstOrDefault(e => e.imageName == name).imageSprite;

        imageObject.sprite = img;
    }
}
