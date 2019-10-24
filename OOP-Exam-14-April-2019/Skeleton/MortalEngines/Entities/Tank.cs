using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            if (DefenseMode)
            {
                return base.ToString() +
                    Environment.NewLine +
                    " *Defense: ON";
            }
            else
            {
                return base.ToString() +
                    Environment.NewLine +
                    " *Defense: OFF";
            }
        }
    }
}
