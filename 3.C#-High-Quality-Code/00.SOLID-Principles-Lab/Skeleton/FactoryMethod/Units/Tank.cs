namespace FactoryMethod.Units
{
    public class Tank
    {
        public Tank(string model, double speed, int attackDamage)
        {
            this.Model = model;
            this.Speed = speed;
            this.AttackDamage = attackDamage;
        }

        public string Model { get; set; }

        public double Speed { get; set; }

        public int AttackDamage { get; set; }

        public override string ToString()
        {
            return $"-Tank\n...Model: {this.Model}\n...Speed: {this.Speed:F2}\n...Damage: {this.AttackDamage}";
        }
    }
}
