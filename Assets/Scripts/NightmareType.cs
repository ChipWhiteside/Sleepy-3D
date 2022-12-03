using UnityEditor.Animations;
using UnityEngine;

namespace Silence
{
    [CreateAssetMenu(fileName = "New Nightmare Type", menuName = "Nightmare Type")]
    public class NightmareType : ScriptableObject
    {
        public NightmareClass nightmareClass;
        public AnimatorController nightmareController;
    }
}