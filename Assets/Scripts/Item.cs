using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        new public string name = "New Item";
        public ItemClass iclass;
        public Sprite icon = null;

        public void Use(Collider2D collider)
        {
            Debug.Log("Used " + name + " (" + iclass + " class)");

            //check if itemclass matches nightmare class
        }
    }

    public enum ItemClass { Physical, Spiritual, Pyro }
}