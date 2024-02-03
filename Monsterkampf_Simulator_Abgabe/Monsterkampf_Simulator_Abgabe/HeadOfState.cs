using System;

namespace Monsterkampf_Simulator_Abgabe
{
    public class HeadOfState
    {
        private float hp;
        private float ap;
        private float dp;
        private float speed;
        private string race;

        public HeadOfState(float hp, float ap, float dp, float speed, string race)
        {
            this.hp = hp;
            this.ap = ap;
            this.dp = dp;
            this.speed = speed;
            this.race = race;
        }

        public void Attack(HeadOfState target)
        {
            float damage = this.ap - target.dp;
            damage = Math.Max(0, damage);
            target.hp -= damage;
            Console.WriteLine($"{this.race} attacks {target.race} for {damage} damage.");
        }

        public bool IsAlive()
        {
            return hp > 0;
        }

        public string GetRace()
        {
            return race;
        }

        public float GetSpeed()
        {
            return speed;
        }
    }
}

