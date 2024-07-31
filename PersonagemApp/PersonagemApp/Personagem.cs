﻿using System;
using System.Collections.Generic;

namespace PersonagemApp
{
    public class Personagem
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; } = 1;
        public int Health { get; set; } = 100;
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Age { get; set; }
        public string SpecialSkill { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();

        public void ApplyItemBonuses()
        {
            foreach (Item item in Inventory)
            {
                item.ApplyBonus(this);
            }
        }

        public void DisplayInfo()
        {
            ApplyItemBonuses(); // Aplica os bônus dos itens

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Race: {Race}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Age: {Age}");
            if (!string.IsNullOrEmpty(SpecialSkill))
            {
                Console.WriteLine($"Special Skill: {SpecialSkill}");
            }
            DisplayInventory();
        }

        public void DistributePoints()
        {
            int totalPoints = 20;

            Console.Clear();
            Console.WriteLine("Você terá apenas 20 pontos para distribuir entre Força, Agilidade e Velocidade.");

            while (true)
            {
                try
                {
                    Console.Write("Pontos para Força: ");
                    Strength = int.Parse(Console.ReadLine());

                    Console.Write("Pontos para Agilidade: ");
                    Agility = int.Parse(Console.ReadLine());

                    Console.Write("Pontos para Velocidade: ");
                    Speed = int.Parse(Console.ReadLine());

                    if (Strength + Agility + Speed == totalPoints)
                        break;

                    Console.WriteLine($"O total dos pontos distribuídos deve ser {totalPoints}. Tente novamente.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }
        }

        public void CollectCharacterData()
        {
            Console.Clear();

            Console.Write("Qual será o nome do seu personagem? ");
            Name = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Escolha a raça do seu personagem:");
            for (int i = 0; i < AvailableRaces.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableRaces[i]}");
            }

            int raceChoice;
            while (true)
            {
                Console.Write("Digite o número correspondente à raça: ");
                if (int.TryParse(Console.ReadLine(), out raceChoice) && raceChoice >= 1 && raceChoice <= AvailableRaces.Count)
                {
                    Race = AvailableRaces[raceChoice - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }

            Console.Clear();

            Console.WriteLine("Escolha a classe do seu personagem:");
            for (int i = 0; i < AvailableClasses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableClasses[i]}");
            }

            int classChoice;
            while (true)
            {
                Console.Write("Digite o número correspondente à classe: ");
                if (int.TryParse(Console.ReadLine(), out classChoice) && classChoice >= 1 && classChoice <= AvailableClasses.Count)
                {
                    Class = AvailableClasses[classChoice - 1];
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }

            Console.Clear();
        }

        public void SetCharacterAge()
        {
            Console.Clear();

            int age;
            do
            {
                Console.Write("Qual será a idade de seu personagem? (ela deve ser entre 15 e 80): ");
                age = int.Parse(Console.ReadLine());
                if (age < 15 || age > 80)
                {
                    Console.WriteLine("A idade deve ser entre 15 e 80. Tente de novo.");
                }
            } while (age < 15 || age > 80);

            Age = age;
        }

        public void ChooseSpecialSkill()
        {
            Console.Clear();

            Console.WriteLine("Escolha uma habilidade especial com base na classe do seu personagem:");

            switch (Class.ToLower())
            {
                case "guerreiro":
                    Console.WriteLine("1. Ataque Poderoso");
                    Console.WriteLine("2. Defesa Implacável");
                    break;
                case "arqueiro":
                    Console.WriteLine("1. Tiro Preciso");
                    Console.WriteLine("2. Esquiva Ágil");
                    break;
                case "mago":
                    Console.WriteLine("1. Bola de Fogo");
                    Console.WriteLine("2. Escudo Mágico");
                    break;
                default:
                    Console.WriteLine("Classe não reconhecida. Habilidade especial não pode ser escolhida.");
                    return;
            }

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }

            switch (Class.ToLower())
            {
                case "guerreiro":
                    SpecialSkill = choice == 1 ? "Ataque Poderoso" : "Defesa Implacável";
                    break;
                case "arqueiro":
                    SpecialSkill = choice == 1 ? "Tiro Preciso" : "Esquiva Ágil";
                    break;
                case "mago":
                    SpecialSkill = choice == 1 ? "Bola de Fogo" : "Escudo Mágico";
                    break;
            }
        }

        public void AddItemToInventory(Item item)
        {
            Item existingItem = Inventory.Find(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Inventory.Add(item);
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventário:");
            if (Inventory.Count == 0)
            {
                Console.WriteLine("O inventário está vazio.");
            }
            else
            {
                foreach (Item item in Inventory)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        // Listas estáticas de opções disponíveis
        public static List<string> AvailableRaces { get; } = new List<string> { "Humano", "Elfo", "Anão", "Orc" };
        public static List<string> AvailableClasses { get; } = new List<string> { "Guerreiro", "Arqueiro", "Mago" };
    }
}
