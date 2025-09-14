using MauiAppMinhasCompras.Helpers;
using System.Globalization;
using System.IO; // necessário para Path.Combine
using Microsoft.Maui.Storage; // necessário para FileSystem.AppDataDirectory

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // declarar um campo estático para instanciar a classe databasehelper no app inteiro
        static SQLiteDatabaseHelper _db;

        // para eu chegar nesse campo db, vou precisar passar por uma propriedade publica
        public static SQLiteDatabaseHelper Db // propriedade começa com a letra maíscula...
        // o _db é um campo e o DB seria uma propriedade
        {
            // sempre q eu chamar o DB, vou dar um return no campo _db e esse
            // campo precisa conter uma instancia da classe DatabaseHelper
            get
            {
                if (_db == null)
                {
                    // declarando o caminho, esse combine faz um encapsulamento para encontrar caminhos absolutos
                    string path = Path.Combine(
                        // o FileSystem.AppDataDirectory é o local onde ele vai conter os arquivos da minha aplicação
                        FileSystem.AppDataDirectory,
                        "banco_sqlite_compras.db3"
                    );

                    // partir para explicar o front 
                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            // MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProdutos());
        }
    }
}
