namespace PersonagemApp
{
    public class Arma : Item
    {
        public Arma(string name, int quantity = 1, int attackBonus = 0, int criticalBonus = 0, int healthBonus = 0, int agilityBonus = 0, int speedBonus = 0)
            : base(name, quantity, attackBonus, criticalBonus, healthBonus, agilityBonus, speedBonus)
        {
        }

        public override void ApplyBonus(Personagem personagem)
        {
            personagem.Strength += AttackBonus;
            personagem.Agility += AgilityBonus;
            personagem.Speed += SpeedBonus;
        }
    }
}
