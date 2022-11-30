using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        new public string name = "New Item";
        public NightmareClass nightmareClass;
        public Sprite icon = null;

        public void Use(Collider2D collider)
        {
            Debug.Log("Used " + name + " (" + nightmareClass + " class)");

            //check if itemclass matches nightmare class
        }
    }
}