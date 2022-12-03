using UnityEditor.Animations;
using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Nightmare Variant", menuName = "Nightmare Variant")]
    public class NightmareVariant : ScriptableObject
    {
        new public string name = "New Item";

        //public Sprite icon = null;
        //public AnimatorController animController = null;
        public EnemyBrain enemyBrain;
        public NightmareType nightmareType;

        //public NightmareClass nclass;

        public float timeMultiplyer = 0.005f;
        public float animatorMultiplyer = 1.25f;

        public float health = 1;
        public float speed = 1;
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