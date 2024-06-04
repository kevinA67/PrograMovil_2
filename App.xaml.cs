namespace PrimerProyectoMovil2
{
    public partial class App : Application
    {
        static Controllers.PersonasControllers dbPersons;

        public static Controllers.PersonasControllers DataBase
        {
            get
            {
                if (dbPersons == null)
                {
                    dbPersons=new Controllers.PersonasControllers();
                }
                return dbPersons;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.PageListPerson());
        }
    }
}
