namespace FightGame.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Lives { get; set; }
        public int Power { get; set; }
        public int Gems { get; set; }
        public Gender Gender { get; set; }

        public string Status()
        {
            var genderDisplay = (Gender == Gender.Male)
                ? "Hombre"
                : "Mujer";

            return $"{Name.PadRight(20)}\t\t{Id}\t{Lives}\t{Power}\t{Gems}\t{genderDisplay}";
        }
    }
}
