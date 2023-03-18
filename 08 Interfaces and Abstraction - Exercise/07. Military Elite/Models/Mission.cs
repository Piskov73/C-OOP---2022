namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    internal class Mission : IMissions
    {
        public Mission(string cogeName,State state )
        { 
            this.CodeName = cogeName;
            this.State = state;

        }
        public string CodeName { get;private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }
        public override string ToString()
        {
            //Code Name: Freedom State: inProgress
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
