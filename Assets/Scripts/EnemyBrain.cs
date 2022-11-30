using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    public enum EnemyBrainStates { ChaseSleepy, AvoidPlayer, AttackPlayer, DefendAgainstPlayer }

    public abstract class EnemyBrain : ScriptableObject
    {
        //public EnemyBrainStates currentState;
        public abstract void Think(Nightmare nightmare);
    }
}