using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Nightmare", menuName = "Nightmare")]
    public class NightmareObject : ScriptableObject
    {
        new public string name = "New Item";
        public NightmareClass nclass;
        public Sprite icon = null;
        public Animation anim = null;

        public void HauntSleepy()
        {
            Debug.Log(nclass + " nightmare haunted Sleepy");

            //player hauting animation
        }

        public bool PlayerClickedMe(ItemClass iclass)
        {
            if (((int)iclass).Equals((int)nclass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //public enum NightmareClass { Physical, Spiritual, Pyro }
}