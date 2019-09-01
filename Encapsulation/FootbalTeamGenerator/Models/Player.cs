using System;

using FootbalTeamGenerator.Exceptions;

namespace FootbalTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public double OverallSkills => this.Stat.OverallStat;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionsMessages.EmptyNameException);
                }

                this.name = value;
            }
        }

        public Stat Stat { get; private set; }
        

    }
}
