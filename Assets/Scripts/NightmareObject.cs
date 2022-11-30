using UnityEditor.Animations;
using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Nightmare", menuName = "Nightmare")]
    public class NightmareObject : ScriptableObject
    {
        new public string name = "New Item";

        public Sprite icon = null;
        public AnimatorController animController = null;
        public EnemyBrain enemyBrain;
        
        public NightmareClass nclass;

        public float health = 1;
        public float speed = 2;
        public float damage = 1;

        //public void HauntSleepy()
        //{
        //    Debug.Log(nclass + " nightmare haunted Sleepy");

        //    //player hauting animation
        //}

        //public bool PlayerClickedMe(ItemClass iclass)
        //{
        //    if (((int)iclass).Equals((int)nclass))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }

    //public enum NightmareClass { Physical, Demonic, Pyro }
}