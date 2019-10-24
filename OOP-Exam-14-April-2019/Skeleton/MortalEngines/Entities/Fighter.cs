using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine , IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }
        
        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            if (AggressiveMode == true)
            {
                return base.ToString() +
                    Environment.NewLine +
                    " *Aggressive: ON";
            }
            else
            {
                return base.ToString() +
                    Environment.NewLine +
                    " *Aggressive: OFF";
            }
        }
    }
}
