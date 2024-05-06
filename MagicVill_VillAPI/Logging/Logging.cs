namespace MagicVill_VillAPI.Logging
{
    public class Logging: ILogging
    {
        public void Log(string message, string type)
        {
            if(type == "error")
            {
                Console.WriteLine("ERROR_" + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
