using System;
using PersonagemApp.Services;

namespace PersonagemApp
{
    public class PersonagemService : ServiceBase<Personagem>
    {
        public void DisplayAll()
        {
            foreach (var personagem in GetAll())
            {
                personagem.DisplayInfo();
            }
        }
    }
}
