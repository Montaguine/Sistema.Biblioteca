using UI.LogicaMenu;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Login do sistema");
            Console.WriteLine("Usuario");
            var usuario = Console.ReadLine();
            Console.WriteLine("Senha");
            var senha = Console.ReadLine();
            Usuario user = SistemaBiblioteca.AutenticarUsuario(usuario, senha);
            
            if(user != null)
            {
                if(user.NivelAcesso == 1)
                {
                    MenuDiretor.Menu(user);
                }
                if(user.NivelAcesso == 2)
                {
                    MenuAtendente.Menu(user);
                }
                if(user.NivelAcesso == 3)
                {
                    MenuProfessor.Menu(user);
                }
                if(user.NivelAcesso == 4)
                {
                    MenuEstudante.Menu(user);
                }
            }
            else
            {
                Console.WriteLine("Usuario ou senha invalidos");
            }

        }
    }
}
