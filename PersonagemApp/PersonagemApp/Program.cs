using System;
using PersonagemApp.Services;

namespace PersonagemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonagemService personagemService = new PersonagemService();

            Personagem myCharacter = new Personagem();

            // Coletando os dados do personagem pelo usuário
            myCharacter.CollectCharacterData();

            // Escolhendo a habilidade especial
            myCharacter.ChooseSpecialSkill();

            // Ajuste para definir o nível inicial do personagem
            myCharacter.Level = 1;

            // Distribuição inicial dos pontos do personagem
            myCharacter.DistributePoints();

            // Coletando e validando a idade
            myCharacter.SetCharacterAge();

            // Adicionando o personagem ao serviço
            personagemService.Add(myCharacter);

            // Adicionando itens ao inventário
            Console.WriteLine("Deseja adicionar itens ao inventário do seu personagem? (s/n)");
            string response = Console.ReadLine().ToLower();
            while (response == "s")
            {
                Console.Clear();

                Console.Write("Nome do item: ");
                string itemName = Console.ReadLine();

                Console.WriteLine("Tipo do item:");
                Console.WriteLine("1. Arma");
                Console.WriteLine("2. Armadura");
                int itemTypeChoice = int.Parse(Console.ReadLine());

                Console.Write("Quantidade do item: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                // Solicitando bônus dos itens
                Console.Write("Bônus de Ataque: ");
                int attackBonus = int.Parse(Console.ReadLine());

                Console.Write("Bônus Crítico: ");
                int criticalBonus = int.Parse(Console.ReadLine());

                Console.Write("Bônus de Vida: ");
                int healthBonus = int.Parse(Console.ReadLine());

                Console.Write("Bônus de Agilidade: ");
                int agilityBonus = int.Parse(Console.ReadLine());

                Console.Write("Bônus de Velocidade: ");
                int speedBonus = int.Parse(Console.ReadLine());

                Item newItem;
                if (itemTypeChoice == 1)
                {
                    newItem = new Arma(itemName, itemQuantity, attackBonus, criticalBonus, healthBonus, agilityBonus, speedBonus);
                }
                else
                {
                    newItem = new Armadura(itemName, itemQuantity, attackBonus, criticalBonus, healthBonus, agilityBonus, speedBonus);
                }

                myCharacter.AddItemToInventory(newItem);

                Console.WriteLine("Item adicionado ao inventário.");
                myCharacter.DisplayInventory();

                Console.WriteLine("Deseja adicionar outro item? (s/n)");
                response = Console.ReadLine().ToLower();
            }

            // Exibindo informações finais do personagem
            personagemService.DisplayAll();
        }
    }
}
