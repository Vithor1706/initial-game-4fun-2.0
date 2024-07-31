namespace PersonagemApp
{
    public class Armadura : Item
    {
        public Armadura(string name, int quantity = 1, int attackBonus = 0, int criticalBonus = 0, int healthBonus = 0, int agilityBonus = 0, int speedBonus = 0)
            : base(name, quantity, attackBonus, criticalBonus, healthBonus, agilityBonus, speedBonus)
        {
        }

        public override void ApplyBonus(Personagem personagem)
        {
            personagem.Health += HealthBonus;
            personagem.Agility += AgilityBonus;
            personagem.Speed += SpeedBonus;
        }
    }
}
