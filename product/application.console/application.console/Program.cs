using gorilla.migrations.console.infrastructure;
using gorilla.migrations.utility;

namespace gorilla.migrations.console
{
    class Program
    {
        static void Main(string[] args)
        {
			try{
				foreach( var arg in args) 
					System.Console.Out.WriteLine("Recieved: {0}", arg);

				new WireUpContainer()
					.then(new RegisterConsoleCommands())
					.run();

				System.Console.Out.WriteLine("starting app");
				Ioc.get_a<Console>().run_against(args);
			}
			catch (System.Exception ex){
				System.Console.Out.WriteLine(ex);
			}
        }
    }
}
