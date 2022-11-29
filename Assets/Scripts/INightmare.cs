using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    public enum NightmareClass { Physical, Spiritual, Pyro }


    public class INightmare
    {
        // Eventually change this to a queue or stack of nightmareClasses so Json can be wearing a ghost sheet (thus is a ghost class THEN a physical class)
        public NightmareClass nightmareClass;
        public float health; // Health starts at a base health and increases based on time


        public void HauntSleepy()
        {

        }

        public void Hit()
        {

        }

        public void AttackPlayer()
        {

        }

        public void AttackSleepy()
        {

        }

    }
}