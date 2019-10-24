using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        private IList<string> targets;

        private BaseMachine()
        {
            this.targets = new List<string>();
        }

        protected BaseMachine(string name, double attackPoints,
            double defensePoints, double healthPoints)
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidMachineName);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidPilot);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            double attack = Math.Abs(AttackPoints - target.DefensePoints);

            target.HealthPoints -= attack;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:f2}")
                .AppendLine($" *Attack: {this.AttackPoints:f2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}");

            if (this.Targets.Count == 0)
            {
                result.AppendLine(" *Targets: None");
            }

            result.AppendLine($" *Targets: {string.Join(", ", this.Targets)}");

            return result.ToString().TrimEnd();
        }
    }
}
